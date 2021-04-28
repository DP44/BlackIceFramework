using System;
using System.Text;
using HarmonyLib;
using UnityEngine;
using Assets.Scripts.Systems.Bounty;

namespace BlackIceFramework.Hooks
{
    class BountyManagerHook
    {
        private class BountyChoice
        {
            public string Choice = "DestroyBounty";
            public int MinLevel;
            public float Rarity = 1f;
        }

        private readonly BountyChoice[] Choices = new BountyChoice[]
        {
            // Existing bounties in the game.
            new BountyChoice { Choice = "DestroyBounty" },
            new BountyChoice { Choice = "HackBounty" },
            new BountyChoice { Choice = "ExploitBounty", MinLevel = 20, Rarity = 0.25f },
            new BountyChoice { Choice = "MineBounty", MinLevel = 10, Rarity = 0.5f },
            new BountyChoice { Choice = "LevelUpBounty", Rarity = 0.5f },
            new BountyChoice { Choice = "MetaBounty", MinLevel = 10, Rarity = 0.25f },
            new BountyChoice { Choice = "BuyBounty", MinLevel = 15, Rarity = 0.5f }, 
            new BountyChoice { Choice = "SpendBounty", MinLevel = 15, Rarity = 0.5f }, 
            new BountyChoice { Choice = "DamageBounty" },
            new BountyChoice { Choice = "DestroyWithTimerBounty", MinLevel = 10 },
            new BountyChoice { Choice = "WorldEventBounty", MinLevel = 10, Rarity = 0.25f }
        };

        // Reimplementation of BountyManager.SelectBountyType().
        string SelectBountyType(CustomRandom rng, int level)
        {
            float[] chances = new float[Choices.Length];

            for (int i = 0; i < Choices.Length; i++)
            {
                chances[i] = Choices[i].Rarity;
               
                if (Choices[i].MinLevel > level)
                {
                    // The bounty's minimum level is higher than the player's level,
                    // so don't give them that bounty.
                    chances[i] = 0f;
                }
                else if (!string.IsNullOrEmpty(BountyManager.instance.LastRecycledBountyType) && BountyManager.instance.LastRecycledBountyType.Contains(Choices[i].Choice))
                {
                    // Don't give the player the same bounty twice in a row.
                    chances[i] = 0f;
                }
                else
                {
                    // Loop through all of the active bounties.
                    foreach (Bounty bounty in BountyManager.instance.Bounties)
                    {
                        // This is to ensure that we don't get the same bounty twice in a row.
                        if (bounty != null && bounty.GetType().ToString().Contains(Choices[i].Choice))
                        {
                            chances[i] = 0f;
                            break;
                        }
                    }
                }
            }

            BountyManager.instance.LastRecycledBountyType = "";
            
            // Choose the bounty we want to select.
            int chosenIndex = Randomizer.Choose(chances, rng);

            // Return the bounty that was chosen.
            return Choices[chosenIndex].Choice;
        }

        private string GetFullBountyClassName(string name)
        {
            return new StringBuilder("Assets.Scripts.Systems.Bounty.").Append(name).ToString();
        }

        // ==============================================================================================

        // Our CreateNewBounties hook.
        [HarmonyPatch(typeof(BountyManager), "CreateNewBounties")]
        [HarmonyPrefix]
        static bool CreateNewBounties()
        {
            Debug.Log("[BountyManagerHook] CreateNewBounties(): Function called.");

            // Get an instance of the hook class.
            BountyManagerHook classHook = new BountyManagerHook();

            InventoryControl inventory = GameStateMachine.instance.GetInventory();
            int playerLevel = inventory.Level;
            int highestHackedLevel = inventory.GetHighestServerHacked();

            // Bounty level here is the reward level.
            int bountyLevel = highestHackedLevel + 3;

            if (playerLevel < InventoryControl.LEVEL_SOFT_CAP)
            {
                // so they can still use any items they get from this.
                bountyLevel = Mathf.Min(playerLevel + 10, bountyLevel);
            }

            // We don't want negative level bounties.
            bountyLevel = Mathf.Max(1, bountyLevel);

            // Create 3 new bounties.
            for (int i = 0; i < 3; i++)
            {
                bool track = true;

                // Don't replace a bounty that's still valid.
                if (BountyManager.instance.Bounties[i] != null)
                {
                    // Keep track of this so we can reuse it later.
                    track = BountyManager.instance.Bounties[i].Track;

                    if (BountyManager.instance.Bounties[i].CurrentState == Bounty.State.Complete)
                    {
                        continue;
                    }

                    if (BountyManager.instance.Bounties[i].CurrentState != Bounty.State.Redeemed && (BountyManager.instance.Bounties[i].ExpireTime > DateTime.Now || BountyManager.instance.Bounties[i].ExpireTime == DateTime.MinValue))
                    {
                        continue;
                    }
                }
                else if (playerLevel < 5)
                {
                    // No bounties before level MINLEVEL, unless they had some from before.
                    switch (i)
                    {
                        case 0:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Pulse(RarityType.Rare, 5));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;
                        case 1:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Heal("Heal", RarityType.Rare, 5));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;
                        case 2:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Mine("Mine", RarityType.Rare, 5));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;
                    }

                    continue;
                }

                // At this point, we're creating new bounties.
                if (BountyManager.instance.Bounties[i] != null) 
                {
                    // Just to be sure.
                    BountyManager.instance.Bounties[i].Remove(); 
                }

                // Forcing this null so it shouldn't be in memory anymore.
                BountyManager.instance.Bounties[i] = null;

                CustomRandom bountyRandom = new CustomRandom(DateTime.Now.Ticks + i);

                // Determine which bounty based on the level and the RNG.
                String choice = classHook.SelectBountyType(bountyRandom, bountyLevel);
                Type t = Type.GetType(classHook.GetFullBountyClassName(choice));

                // Create an object of type t.
                BountyManager.instance.Bounties[i] = (Bounty)Activator.CreateInstance(t, bountyRandom, bountyLevel, i);

                // Maybe add fun names later?
                BountyManager.instance.Bounties[i].Title = "Bounty #" + (i + 1).ToString();

                BountyManager.instance.Bounties[i].Track = true;
            }

            // We don't want to call the original function.
            return false;
        }
    }
}

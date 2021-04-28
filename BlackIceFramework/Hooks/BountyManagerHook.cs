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

            // This was here when it was decompiled, we can remove this.
            // DateTime today = DateTime.Today;

            // Get the player's inventory.
            InventoryControl inventory = GameStateMachine.instance.GetInventory();

            // Get the player's level.
            int level = inventory.Level;

            // Count the offset (highestServerHacked + 3).
            int offset = inventory.GetHighestServerHacked() + 3;

            // Check if our level is below 50.
            if (level < 50)
            {
                offset = Mathf.Min(level + 10, offset);
            }

            offset = Mathf.Max(1, offset);

            /*
            // TODO: Finish this.
            foreach (Bounty activeBounty in BountyManager.instance.Bounties)
            {
                if (activeBounty != null)
                {
                    bool track = activeBounty.Track;

                    if (activeBounty.CurrentState != Bounty.State.Complete)
                    {
                        if (activeBounty.CurrentState == Bounty.State.Redeemed)
                        {
                            // Move to the next active bounty in the array.
                            continue;
                        }

                        if (!(activeBounty.ExpireTime > DateTime.Now) && !(activeBounty.ExpireTime == DateTime.MinValue))
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    // Bounties become available when we reach level 5.
                    if (level >= 5)
                    {
                        continue;
                    }
                }
            }
            */

            // NOTE: Right now it's just a rewrite of the decompiled output.

            // Our iterator.
            int i = 0;
            
            // While loop.
            while (i < 3)
            {
                if (BountyManager.instance.Bounties[i] != null)
                {
                    bool track = BountyManager.instance.Bounties[i].Track;

                    if (BountyManager.instance.Bounties[i].CurrentState != Bounty.State.Complete)
                    {
                        if (BountyManager.instance.Bounties[i].CurrentState == Bounty.State.Redeemed)
                        {
                            goto GET_NEW_BOUNTY;
                        }

                        if (!(BountyManager.instance.Bounties[i].ExpireTime > DateTime.Now))
                        {
                            if (!(BountyManager.instance.Bounties[i].ExpireTime == DateTime.MinValue))
                            {
                                goto GET_NEW_BOUNTY;
                            }
                        }
                    }
                }
                else
                {
                    // Bounties become available when we reach level 5.
                    if (level >= 5)
                    {
                        goto GET_NEW_BOUNTY;
                    }

                    switch (i)
                    {
                        case 0:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Pulse(RarityType.Rare, 5, Brand.None));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;

                        case 1:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Heal("Heal", RarityType.Rare, 5, Brand.None));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;

                        case 2:
                            BountyManager.instance.Bounties[i] = new LevelUpBounty(new Mine("Mine", RarityType.Rare, 5, Brand.None));
                            BountyManager.instance.Bounties[i].Track = false;
                            break;
                    }
                }

            ITERATE:
                i++;

            GET_NEW_BOUNTY:
                // Remove the bounty if it still exists.
                if (BountyManager.instance.Bounties[i] != null)
                {
                    BountyManager.instance.Bounties[i].Remove();
                }

                BountyManager.instance.Bounties[i] = null;

                // Create a new CustomRandom object.
                CustomRandom random = new CustomRandom(DateTime.Now.Ticks + (long)i);

                // Call our custom SelectBountyType method.
                string name = classHook.SelectBountyType(random, offset);

                // Get the bounty datatype.
                Type bountyType = Type.GetType(classHook.GetFullBountyClassName(name));

                if (bountyType == null)
                {
                    Debug.LogError("[BountyManagerHook] CreateNewBounties(): bountyType was null! running original function.");
                    
                    // Run the original function.
                    return true;
                }

                // Add the randomly selected bounty to the list of active bounties.
                BountyManager.instance.Bounties[i] = (Bounty)Activator.CreateInstance(bountyType, new object[] { random, offset, i });
                BountyManager.instance.Bounties[i].Title = "Bounty #" + (i + 1).ToString();
                BountyManager.instance.Bounties[i].Track = true;

                goto ITERATE;
            }

            // We don't want to run the original code.
            return false;
        }
    }
}

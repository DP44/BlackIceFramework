# InventoryControl
---
Responsible for working with the player's inventory.

### API Reference:
---
```cs
public Item[] MainInventory;
```
A list of [Item](Item.md)s that are present in the player's inventory.

---
```cs
public bool GodMode;
```
Used to check if the player is in godmode.

---
```cs
public ProjectileManager projectileManager;
```
A [ProjectileManager](ProjectileManager.md) instance for the player.

---
```cs
public int MaxHealth { get; }
```
The player's max health.

---
```cs
public int CurrentHealth { get; }
```
The player's current health.

---
```cs
public int MaxRAM { get; set; }
```
The player's max RAM.

---
```cs
public float CurrentRAM { get; }
```
The player's current RAM.

---
```cs
public float UsedRAM { get; set; }
```
The amount of RAM that the player has used.

---
```cs
public int XP { get; set; }
```
The player's current XP count.

---
```cs
public int Level { get; set; }
```
The player's current level.

---
```cs
public int TalentPoints { get; set; }
```
The amount of talent points that the player has.

---
```cs
public int PerkPoints { get; set; }
```
The amount of perk points that the player has.

---
```cs
public FirstPersonController FPSController { get; }
```
The [FirstPersonController](FirstPersonController.md) for the player.

---
```cs
public Factions Faction { get; }
```
The player's faction.

---
```cs
public bool InCombat { get; }
```
Used to check if the player is in combat.

---
#### Methods
---
```cs
public void SaveCharacter()
```
Saves the player's character data.

---
```cs
public void LoadCharacter()
```
Loads the player's data.

---
```cs
public bool TakeDamage(DamagePacket packet, AffixPacket affixes = null)
```
Handles damage for the player.

---
```cs
public void AddTempHP(int amount)
```
description

---
```cs
public bool IsFullHealth()
```
Returns if the player is at full health or not.

---
```cs
public float GetHealthPercentage()
```
Gets the player's health percentage.

---
```cs
public void Die(bool loseCredits)
```
Kills the player.

---
```cs
public void CheckDesaturationAndHP()
```
Calculates the player's HP and how desaturated the screen should be.

---
```cs
public Vector3 GetCenter()
```
Gets the player's center position.

---
```cs
public static int GetMaxHealthScaling(int level)
```
Gets the player's max health with scaling.

---
```cs
public void AddRAM(float add_RAM)
```
Adds the specified amount of RAM to the player.

---
```cs
public bool SubRAM(float sub_RAM)
```
Subtracts the specified amount of RAM from the player.

---
```cs
public bool SubRAMInstant(float value)
```
Sets the player's transform.

---
```cs
public void SetLocalPlayer(Transform player)
```
description

---
```cs
public void AddXP(int value)
```
Gives the player XP.

---
```cs
public bool IsHacking()
```
Returns if the player is hacking a building.

---
```cs
public bool IsHacking(BuildingManager targetBuilding)
```
Returns if the player is hacking the building specified. Check [BuildingManager](BuildingManager.md) for more details.

---
```cs
public bool IsOutOfRange()
```
Returns if the player is out of reach from the hack link.

---
```cs
public int GetHighestServerHacked()
```
Gets the highest server level that the player has hacked.

---
```cs
public void AddHackLink(LinkController hackLink)
```
Adds a hack link. See [LinkController](LinkController.md) for more details.

---
```cs
public void RemoveHackLink(LinkController hackLink)
```
Removes a hack link. See [LinkController](LinkController.md) for more details.

---
```cs
public LinkController GetHackLink()
```
Returns the [LinkController](LinkController.md) for the first active hack link.

---
```cs
public List<LinkController> GetHackLinks()
```
Returns a list of all current hack links.

---
```cs
public void RespawnPlayer()
```
Respawns the player.

---
```cs
public void Teleport(Vector3 spawnPoint, Quaternion rotation)
```
Teleports the player to a given location.

---
```cs
public bool AddItem(Item item)
```
Adds an item to the player's inventory, returns if the operation was successful.

---
```cs
public bool AddCredits(int creds)
```
Gives the player a specified amount of credits, returns if the operation was successful.

---
```cs
public int GetCredits()
```
Returns the amount of credits the player has.

---
```cs
public int GetXP()
```
Returns the player's current XP.

---
```cs
public Player GetNetworkPlayer()
```
Returns the Photon.Realtime.Player object for the player.

---
```cs
public bool IsCheater()
```
Returns if the player has the cheater tag.

---
```cs
public Ray GetAim()
```
Returns a ray to the position where the player is aiming.

---
```cs
public bool IsGrounded()
```
Returns if the player is on the ground.

---
```cs
public bool IsDead()
```
Returns if the player is dead.

---
```cs
public string GetName()
```
Returns the player's name.

---
```cs
public void SetName(string value)
```
Sets the player's name.

---
```cs
public void LevelUpOnce()
```
Levels up the player.

---
```cs
public int GetNextLevelXP()
```
Returns how much XP is needed in order to reach the next level.

---
```cs
public int GetLevel()
```
Returns the player's current level.

---
```cs
public Color GetColor()
```
Returns the player's faction color. If PVP is turned off then this will return Color.white.

---
```cs
public float GetCritChance(Item item, bool useCompare)
```
Returns the player's chance of getting a critical hit.

---
```cs
public float GetCritMultiplier(Item item, bool useCompare)
```
Returns the critical hit multiplier.

---
```cs
public float GetMovementSpeed()
```
Returns the player's movement speed.

---
```cs
public Item GetEquippedItem(EquipmentSlot index)
```
Returns the equipped item in the given slot.

---
```cs
public float GetRAMPerSecond(bool useCompare = false)
```
Returns the amount of RAM that is gained per second.

---
```cs
public BuffManager GetBuffManager()
```
Gets an instance of [BuffManager](BuffManager.md) for the player.

---
```cs
public bool IsHoldingDownJump()
```
Returns if the player is holding down the jump key.

---
```cs
public bool IsHoldingDownActiveWeapon()
```
Returns if the player is holding down the active weapon.

---
```cs
public float GetGearScore()
```
description

---
```cs
public Item GetActiveWeapon()
```
Returns the player's active weapon.

---
```cs
public int GetActiveWeaponIndex()
```
Returns the index of the active weapon.

---
```cs
public float GetDPS()
```
Returns the active weapon's DPS.

---
```cs
public void TryHack()
```
Attempts to hack whatever the player is looking at.

---
```cs
public bool IsEquipped(Item item)
```
Returns if an item is currently equipped.

---
```cs
public Icebreaker GetIcebreaker()
```
Returns an instance of the player's [Icebreaker](Icebreaker.md)

---
```cs
public bool CanGrapple()
```
Returns if the player can grapple or not.

---
```cs
public CharacterController GetCharacterController()
```
Returns a [CharacterController](CharacterController.md) instance for the player.

---
```cs
public bool IsHardcore()
```
Returns if the player is playing hardcore.

---
```cs
public float GetAimAngle()
```
Returns the aim angle.

---
```cs
public float GetBaseAimAngle()
```
description

---
```cs
public string GetWorldStateAsString()
```
Returns the world state as a string.

---
```cs
public void RefreshModel()
```
Refreshes the player's model.
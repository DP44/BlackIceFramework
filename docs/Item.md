# Item
---
A class representing items such as weapons, icebreakers, and others.

### API Reference:
---
```cs
public Item()
```
Constructor for an item.

---
```cs
public string getName()
```
Returns the item name.

---
```cs
public void setName(string value)
```
Sets the item name.

---
```cs
public int getValue()
```
Returns the item's value.

---
```cs
public void setValue(int value)
```
Sets the item's value.

---
```cs
public RarityType getRarity()
```
Gets the item's [RarityType](RarityType.md).

---
```cs
public void setRarity(RarityType value)
```
Sets the item's [RarityType](RarityType.md).

---
```cs
public Sprite getIcon()
```
Returns the item's icon.

---
```cs
public void setIcon(IconIndex newIcon)
```
Sets the item's icon. See [IconIndex](IconIndex.md) for more info.

---
```cs
public virtual int getRamConsumed()
```
Returns the amount of RAM that the item has consumed.

---
```cs
public virtual float getRamPerSecond()
```
Returns the amount of RAM used per second.

---
```cs
public virtual bool isActive()
```
Returns if the item is active.

---
```cs
public virtual float getCooldown(bool inItemGeneration = false)
```
Returns the item's cooldown.

---
```cs
public virtual float getCooldownRemaining()
```
Returns the item's remaining cooldown time.

---
```cs
public virtual float getDPS()
```
Returns the item's DPS.

---
```cs
public virtual float getMinDamage()
```
Returns the minimum damage done by the item.

---
```cs
public virtual float getMaxDamage()
```
Returns the maximum damage done by the item.

---
```cs
public int getLevelRequirement()
```
Returns the level required in order to use the item.

---
```cs
public int getItemLevel()
```
Returns the item level.

---
```cs
public virtual bool canUnequip()
```
Returns if the player can unequip the item.

---
```cs
public InventoryControl getInventory()
```
Gets the [InventoryControl](InventoryControl.md) instance for the inventory that the item is in.

---
```cs
public virtual int GetProjectileType()
```
Returns the projectile type.

---
```cs
public virtual float getProjectileSpeed()
```
Returns the projectile speed.

---
```cs
public virtual int getProjectileCount(bool inItemGeneration = false)
```
Returns the projectile count.

---
```cs
public virtual void setItemLevel(int level)
```
Sets the item's level.

---
```cs
public Dictionary<Affix, float> getAffixes()
```
Returns all the [Affix](Affix.md)es on the item.

---
```cs
public virtual List<Affix> getAffixKeys()
```
Returns all the [Affix](Affix.md) keys on the item.

---
```cs
public virtual float getAffix(Affix affix)
```
Gets an affix on the item.

---
```cs
public bool HasPerkAffix(Affix perk)
```
Returns whether an item has a perk affix.

---
```cs
public void AddAffix(Affix affix, float value)
```
Adds an affix to the item.

---
```cs
public virtual string GetItemType()
```
Returns the item type.

---
```cs
public virtual string GetFlavorText()
```
Returns the item's flavor text.

---
```cs
public void SetFlavorText(string newText)
```
Sets the item's flavor text.

---
```cs
public virtual bool HasPerk(Affix perk)
```
Returns if the item has a specific perk.

---
```cs
public virtual bool UsesStaticRAM()
```
Returns if the item uses static RAM.

---
```cs
public virtual bool CanEquip()
```
Returns if the item can be equipped.

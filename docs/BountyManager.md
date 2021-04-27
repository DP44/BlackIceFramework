# BountyManager
---
The global manager for bounties.

### API Reference:
---
```cs
public static BountyManager instance { get; }
```
Used to grab the BountyManager instance.

---
```cs
public Bounty[] Bounties { get; set; }
```
A list of the current bounties.

---
```cs
public int Ouros { get; }
```
The amount of Ouros that the player has.

---
```cs
public int LifetimeOuros { get; }
```
TODO: Description.

---
```cs
public int LifetimeBounties { get; }
```
TODO: Description.

---
```cs
public int CurrentDailyStreak { get; }
```
TODO: Description.

---
```cs
public int LongestDailyStreak { get; }
```
The longest daily streak that the player has achieved.

---
```cs
public int CompleteBountiesCount { get; }
```
Returns the amount of complete bounties.

---
```cs
public Bounty[] Bounties { get; set; }
```
A list containing the current bounties that the player has. See [Bounty](Bounty.md) for more info.

---
#### Methods
---
```cs
public void CreateNewBounties()
```
Creates a new set of bounties.

---
```cs
public void BountyComplete()
```
Called when a bounty is completed.

---
```cs
public bool HasCompleteBounties()
```
Returns true if any of the 3 current bounties are complete, otherwise it returns false.

---
```cs
public BountyManagerProxy GetProxy()
```
Returns the [BountyManagerProxy](BountyManagerProxy.md) instance for the class.

---
```cs
public void LoadFromProxy(BountyManagerProxy proxy)
```
Loads the BountyManager instance from the given proxy.

---
```cs
public bool SpendOuros(int amount)
```
Removes the specified amount of Ouros that the player has, returns true if successful.
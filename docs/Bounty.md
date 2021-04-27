# Bounty
---
A class representing bounties that the player must achieve.

---
##### Example
This is an example of the bounty class. This example keeps track of how many mines there are and will complete when a certain amount of those mines are destroyed.

```cs
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;

namespace Bounties
{
	// Example usage of the Bounty class.
	// This is the class used for the MineBounty class ingame.
	[JsonObject(MemberSerialization.OptIn), Serializable]
	public class MineBounty : Bounty
	{
		// This is our bounty type.
		public override Bounty.BaseTypes BaseType { get { return Bounty.BaseTypes.Mine; }}

		// The available conditions for the bounty.
		protected override List<Bounty.BountyConditionChoice> AvailableConditions
		{
			get
			{
				return new List<Bounty.BountyConditionChoice>();
			}
		}

		// Constructor.
		public MineBounty()
		{
			// Make sure our event container is initialized.
			if (EventContainer.instance != null)
			{
				// Add our MineKilled function to the event itself.
				EventContainer.instance.MineKilled += this.MineKilled;
			}
		}

		// Constructor.
		public MineBounty(CustomRandom rng, int level, int difficulty)
		{
			// Call the original Initalize function.
			base.Initialize(level, difficulty, rng, 1);

			// Add our MineKilled function to the event itself.
			// 
			// NOTE: This should be checked just like the first constructor, otherwise
			//       this will break if EventContainer is null!
			EventContainer.instance.MineKilled += this.MineKilled;
		}

		// This is where we would set our target progress.
		protected override void SetTargetProgress(int difficulty)
		{
			// Set the target progress that we want to achieve.
			base.TargetProgress = 5 + difficulty * 2;
		}

		protected override void SetDescriptionText()
		{
			// Create our description string builder.
			// 
			// NOTE: I'm pretty sure you can use format strings here, but I don't know.
			//
			StringBuilder description = new StringBuilder("Destroy ").Append(base.TargetProgress);
			description.Append(" mines");

			// Turn it into a string type and set it as the description.
			base.Description = description.ToString();
		}

		// This is called when a mine is destroyed.
		private void MineKilled(int level)
		{
			if (level >= base.Level)
			{
				// NOTE: All this code is doing is the same as doing base.CurrentProgress++ then
				//       proceeding to check if the bounty is completed.

				// Get our current progress.
				int progress = base.CurrentProgress;

				// Increment the progress by 1.
				base.CurrentProgress = currentProgress + 1;

				// Check if the bounty is completed.
				base.CheckCompletion();
			}
		}

		// Called when the bounty is completed.
		public override void Remove()
		{
			// Remove our function from the event listener.
			EventContainer.instance.MineKilled -= this.MineKilled;
		}
	}
}
```

---

### API Reference:
---
```cs
public virtual Bounty.BaseTypes BaseType { get; }
```
The bounty type.

---
```cs
public Bounty.State CurrentState { get; }
```
The bounty's current state.

---
```cs
public string Title { get; set; }
```
The bounty's title.

---
```cs
public string Description { get; }
```
The description for the bounty.

---
```cs
public int Level { get; }
```
The bounty's level.

---
```cs
public int CurrentProgress { get; }
```
The bounty's current progress.

---
```cs
public float CurrentProgressPercent { get; }
```
The bounty's current progress in percentage from 0 to 100.

---
```cs
public int TargetProgress { get; }
```
The progress level needed to complete the bounty.

---
```cs
public Item ItemReward { get; }
```
The [item](Item.md) that the player will be rewarded when the bounty is completed.

---
```cs
public BountyFrameController BountyFrame { get; set; }
```
The bounty's frame. See [BountyFrameController](BountyFrameController.md) for more info.

---
#### Methods
---
```cs
protected virtual void SetDescriptionText()
```
Used to change the description text. See the example above.

---
```cs
protected virtual void SetTargetProgress(int difficulty)
```
Used to change the target progress needed to complete the bounty. See the example above.

---
```cs
public virtual void Remove()
```
Called when the bounty is completed and when the item is accepted. This is usually where you will clean up stuff. See the example above.

# GameStateMachine
---
This is the main heart of all the scripts, with it you can gain access to all sorts of stuff relating to the game itself.

### API Reference:
---
```cs
public void SetLocalPlayer(Transform player)
```
Sets the player's transform.

---
```cs
public Transform GetPlayer()
```
Get the player transform.

---
```cs
public Camera GetUICamera()
```
Get the UnityEngine.Camera object used for UI elements.

---
```cs
public InventoryControl GetInventory()
```
Returns an [InventoryControl](InventoryControl.md) class for the player.

---
```cs
public Transform GetTemporaryObjectsCategory()
```
Description here

---
```cs
public Transform GetEnemiesCategory()
```
Description here

---
```cs
public Transform GetPlayersCategory()
```
Description here

---
```cs
public MouseLook GetMouseX()
```
Description here

---
```cs
public MouseLook GetMouseY()
```
Description here

---
```cs
public void SetState(GameState newState)
```
Sets the game state. Check [GameState](GameState.md) for available options.
Keep note that this does call a private method called pause() which does call PauseInput.

---
```cs
public void PauseInput()
```
Pauses all input in the game, this is called for example when you open the pause screen while playing a singleplayer game.

---
```cs
public void ResumeInput()
```
Unlocks player input.

---
```cs
public void LockCursorAppropriately()
```
Description here

---
```cs
public void StartSpeedrunningTimer()
```
Description here

---
```cs
public void PrintSpeedrunningLog(string log)
```
Description here

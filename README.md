# Mission Demolition

A slingshot demolition game built from the Mission Demolition tutorial (Bond, *Introduction to Game Design, Prototyping, and Development*, Chapter 30), with the enhancements listed below. Fire projectiles at each castle and hit the goal block to advance.

**Unity version:** 2021.3.45f2

## How to play
- Hover over the slingshot, click and drag back to aim, and release to fire.
- Hit the goal block in the castle to finish the level.
- Use the button at the top to switch the camera between the slingshot, the castle, or both.

## Enhancements

### Game Over screen
After the goal is hit on the final level, a Game Over screen appears with the total stars earned and a **Play Again** button that restarts the game from level 1.

### Four custom castles
The game has four castles, ordered from easy to difficult:
1. **Level 1:** a simple castle with an easily reachable goal.
2. **Level 2:** a two story castle with the goal on the second floor.
3. **Level 3:** a pyramid with three rooms on the first floor and one room in the middle of the second floor. The goal is in the middle first floor room.
4. **Level 4 (The Great Wall):** a tall, thick, heavy wall stands in front of the goal, so the player has to lob the projectile over it or smash through it.

### Rubber band
The slingshot's rubber band is drawn with a Line Renderer running from the left arm to the right arm. The middle of the band follows the projectile while aiming and snaps back to rest on release.

### Sound
A rubber band snap sound plays when the projectile is launched.

### Star rating (the "cooler" feature)
Each level awards up to 3 stars, shown at the top of the screen and filled in one at a time after the goal is hit:
- **1 star:** completed the level.
- **1 star:** hit the goal with a single shot.
- **1 star:** the shot that hit the goal did not touch the ground first.

The Game Over screen shows the total number of stars earned out of 12.

## Scripts
- `Slingshot.cs`: aiming, launching, and the launch sound.
- `SlingshotBand.cs`: draws the rubber band.
- `FollowCam.cs`: camera follow.
- `ProjectileLine.cs`: projectile trail.
- `Projectile.cs`: records whether a projectile touched the ground.
- `Goal.cs`: detects the goal being hit.
- `MissionDemolition.cs`: game state, levels, star rating, and the Game Over screen.

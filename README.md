# Asteroids (2D)

> Asteroids is a space-themed multidirectional shooter arcade game designed by Lyle Rains, Ed Logg, and Dominic Walsh and released in November 1979 by Atari, Inc. The player controls a single spaceship in an asteroid field which is periodically traversed by flying saucers. The object of the game is to shoot and destroy the asteroids and saucers, while not colliding with either, or being hit by the saucers' counter-fire. The game becomes harder as the number of asteroids increases.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------

This project is forked to for a technical assignment for Paladin Studios.
I will be adding and improving on the project within a 4 hour time limit with the focus on game feel.

## Gameplay ideas
**Screen Wrapping:**
- When the player reaches the edge of the screen, the player will reappear in the edge which is parallel to the player's direction.

**Decision:**
- After watching pro astroids players and seeing them use the ships momentum to keep crusing across the screen edges seemed really fun. I will try to implement this if I have time left after the power ups and game feel.
---

**New enemy:**
- An enemy which spawn a lot less frequently but has the ability to shoot at the direction of the player.

**Decision:**
- Seems like a great addition, but not a priority focus. I'll put it in the same category as the Screen Wrapping feature and add it when there is time left.
---

**Power ups:**
- Simular to the upgrades idea.
- Certain astroids will drop a power up to the player.
- Power up could include a one time shield as protection. Different shooting behavior. Extra life.

**Decision:**
- I will focus on implementing this as the main gameplay feature to add. It gives player not just a reason to avoid astroids, but to steer in the danger and to pickup an upgrade which will benefit in the long run.
---

**Upgrades:**
- Every X amount of destroyed astroids give the player the options to select one of 3 permanent upgrades to the ship.
- These upgrades could include increased movement and or rotation speed, bigger bullets, or a downgrade to the asteroids.

**Decision:**
- Sounds fun to implement however I think it will involve more of a design challenge as this changes the flow of the game abruplty for the player to select one of 3 upgrades. I think it would be better to use powerups instead.
---

## Game Feel plan

Overal I think the best starting point would be to implement feedback from any action thats happening.
This includes player shooting, moving, crashing and scoring.

- Audio
- Camera shake
- Post Processing
- Particle effects/trails
- Show gained score.

**Version**: Unity 2020.3.11f1

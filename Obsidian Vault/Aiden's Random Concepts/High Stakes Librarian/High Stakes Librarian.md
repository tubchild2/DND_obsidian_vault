You work in a library in a high-fantasy adventuring town, but all the books have been stolen by Mr. Bad Man and his goons. You must go on a quest throughout the world (world map like Super Mario World but more open-ended) to recollect all of the lost books. The combat is akin to castle crashers, being a side-scroller beat-em-up game. However, the major difference comes from the emphasis on synergy and power progression.

### Player Power Progression
**Synergizing**
There are 6 ways to synergize your character:
- How you spend your skill points
- Your elemental ability
- Your choice of weapon and armor
- Your choice of pet
- Your use of modifier books
- Your use of items

**The Primary Stats**
- Strength. 
	- +2.5 melee damage per level.
	- +0.1 to the number of enemies you can hit at once per level.
- Constitution. 
	- +25hp per level.
	- +1 flat damage reduction per level.
- Dexterity. 
	- +0.5m/s move speed per level
	- +0.1 attacks per second per level
	- -0.01m/s gravity per level
	- +1.5 throwing knife damage per level
- Intelligence.
	- +2 elemental damage per level
	- +0.5% elemental power recharged per second
	- +10 total elemental power
- Luck.
	- +0.5% critical hit chance per level
	- +0.1% rare item luck per level 
	- +0.1% dodge chance per level

Levelling up means:
1. You gain 2 new combos at levels 5, 15, 25, and 45
2. You gain a new elemental ability at levels 10, 20, 30, 40, 50, and 60.
3. You gain an additional modifier book slot at levels 7, 14, 21, 28, 35, 42, 49, and 56.
4. You gain 2 skill points per level to spend on each stat to a maximum of 100.
5. Every 10 levels, all 5 stats receive an invisible 1 skill point, this includes at level 0.

Each level takes 1% more experience than the previous. To find the amount of EXP required to reach a level, use this equation:
$$
Total = 100 * \frac{(1.01)^n-1)}{0.10}​
$$

**Character Abilities**
Whenever you start the game, you can create your character. Your character starts with 1 chosen elemental ability
- Fire (unlocks bombs and lightning upon completion)
- Water (unlocks poison and ice upon completion)
- Earth (unlocks metal and gems upon completion)
- Air (unlocks light and dark upon completion)
- Life (unlocks growth and death upon completion)

**Weapons and Armor**
You can equip one weapon and one set of armor. These armors can be hidden around the game, and there are many more of them than the modifier books. For balancing reasons, each weapon and armor has a number of points it can spend equal to the level required to use it. These points are spent on these things:
- Skill point increase. Can invisibly increase the amount of skill points you have in STR, CON, INT, DEX, or LCK. Costs 5 points per increase. Costs -5 points per 2 decreases. You can deplete each stat a maximum of -50 for an additional 125 spendable points.
- Modifier Book Slots. Adds a free modifier slot. Costs 25 points per additional modifier slot.
- Infusion. Can imbue the weapon with an elemental ability. Costs 25 points per added ability. Exclusive to weapons. Deals extra damage equal to your elemental damage. Can only be added once. 
- Immunity. Can grant immunity to an elemental damage type. Costs 50 points per immunity. Exclusive to armors.

**Pets**
You can equip one pet. These pets are hidden around the game. For balancing reasons, they also use a point system, but they can be equipped regardless of your character's level. They have 30 points to spend, and they typically spend them all in one category.
- Skill point increase. Can invisibly increase the amount of skill points you have in STR, CON, INT, DEX, or LCK. Costs 5 points per increase. Costs -5 points per 2 decreases. You can deplete each stat a maximum of -10 for an additional 25 spendable points.
- Attack. They can shoot projectiles at enemies, maul enemies, knock enemies over, stun enemies, etc. It costs 1 point per 5 damage done (base of 5, maximum 155). 3 points = +0.5 attacks per second (base of 0.5 attacks per second, maximum of 5.5 attacks per second)
- Bonus ability. A unique functionality like preventing slipperiness, healing over time, moving faster in water, etc. These cost 20 points each. 

**Modifier Books**
These are the bulk of the game! The main thing you're out looking for! These books contain instructions to modify weapons and armor, and they can be stacked to work with one another to increase their power. They function like the enchantments from Minecraft, but there's more of them and they do much more. Each book has a special effect like knocking enemies back, increasing hit range, stealing enemy life, etc. By the end of the game, you can have 8 modifier books equipped on your weapons and armor at once, allowing you to do some crazy synergies. These books are unlocked at the end of each level, and they get more powerful the further into the game you get. 

**Items**
There are only a few items. Healing flask (heals to full hp 3 times per stage), throwing knives (can store up to 999), magnet (used to find secret items, and to grab items from afar). 

### Combat
It's designed for combos, juggling, and to reward mastery. 

**Melee Combat**
Basics
- Light attack. Fast low damage.
- Heavy attack. Slow high damage.
- Throw (heavy attack up close). Grabs and throws enemies.
- Push (light attack up close). Pushes enemies behind you and launches you up.
- Airborne light attack. Pushes forward and maintains air.
- Airborne heavy attack. Bounces enemies off the ground, and pushes you up.
- Airborne throw (heavy attack up close). Grabs and throws enemies.
- Airborne push (light attack up close). Pushes enemies behind you and launches you up.
- Blocking. Triples your flat damage reduction
- Perfect blocking. Completely blocks the incoming damage
- Side Stepping. Perfect blocking with a directional input lets you get an opportunity attack.
Basic combos
- L, L, L. Low damage, but fast.
- H, H, H. High damage, but slow.
The 8 Unlocked combos and their opposites
- L, H. Upper cut combo. Launches enemies up to set up a juggle.
- H, L. Root combo. Pins enemies to the ground temporarily.
- L, T. Side bash. Laterally launches enemies.
- H, T. Angle bash. Launches enemies diagonally.
- L, H, P. Flurry. Rising multi-hit combo.
- H, L, P. Bind. Ground based flurry of attacks. 
- L, H, L, H, T. Whirlwind. Strikes all enemies in your immediate area for good damage.
- L, H, L, H, P. Catapult. Launches you towards another enemy after dealing high damage.

**Elemental Combat**
6 elemental abilities + the one you start with
- Splash. Shoots a low damage but large area attack in front of you.
- Projectile. Shoots a high damage, medium speed, small area bullet in front of you.
- Bash. Shoots a low distance, high damage burst of damage that knocks enemies back.
- Area. Knocks back all enemies in your immediate area for low damage. Takes a second.
- Pull. Launches an enemy in front of you towards you.
- Storm. Shoots out a flurry of bullets in all directions that do average damage but knock people back.
- Meteor. Shoots a powerful meteor projectile that costs all of your elemental power.

### Game Design Info
Core Loop
1. Travel
2. Fight
3. Find
4. Upgrade

Difficulty Curve per chapter
1. Easy, introduces the game
2. First real test
3. All skills are assumed, ups difficulty
4. Halfway point. Mid-way climax of difficulty
5. Temporary difficulty drop to introduce new mechanics
6. Second test of all mechanics
7. All skills are assumed, greatly ups difficulty
8. Climax. 
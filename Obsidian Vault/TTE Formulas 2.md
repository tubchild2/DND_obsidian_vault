# Overview
Goal:
- Create a list of mathematical formulas for balancing the numbers of TTE

Core Formulas
- Stat Leveling Logic
- Skill Leveling Logic
- Maximum HP Logic

Balancing Formulas
- Player
	- Stat Range by Level
	- Skill Range by Level
	- HP Range by Level
- Item
	- Suggested Damage by Level, Difficulty
	- Suggested Defense by Level, Difficulty
	- Suggested Value by Level, Difficulty, Use Stats, Uses, Consume-ability, Damage, Defense
- Class / Species / Background
	- Suggested HP Range
- Encounter
	- Total HP Pool by Level, Difficulty
	- Total Damage Per Turn by Level, Difficulty


# Reference
Item Rarities by Level
	1 = Poor (Brown)
	2 = Common (Gray)
	3 = Uncommon (White)
	4 = Rare (Light Blue)
	5 = Very Rare (Blue)
	6 = Epic (Green)
	7 = Mythical (Yellow)
	8 = Legendary (Orange)
	9 = Ancient (Red)
	10 = Relic (Black)

Difficulties
	1 = Baby Mode
	2 = Casual
	3 = Beginner
	4 = Easy
	5 = Normal
	6 = Hard
	7 = Brutal
	8 = Expert
	9 = Extreme
	10 = Hell

Stat Levelling Logic
- Standard Array (-1, -1, 0, 0, 1, 1)
- Background potential +1 to any/all core stats
- Species potential +1 to any/all core stats
- Class potential +1 to any/all core stats
- Level up potential +1 to any core stat (repeating)

Skill Levelling Logic
- Standard potential +1 to 3 skills
- Background potential +1 to 3 skills
- Species potential +1 to 3 skills
- Class potential +1 to 3 skills
- Level up potential +1 to any skill (repeating)

Maximum HP Logic
Each Level:
- HP += CON
- HP += Species HP
- HP += Class HP
- HP += Level
Equation
- L = Level
- C = Constitution
- S = Species HP
- H = Class HP
$$
\sum_{n=1}^l n + l(c + s + h)
$$


# Balancing
### Players
Stat Range by Level (L)
- Minimum: -1
- Average: (L + 2) / 6
- Maximum: L + 3

Skill Range by Level (L)
- Minimum: 0
- Average: 
- Maximum: 4 + (L - 1)

HP Range by Level
- Minimum: 
- Average: 
- Maximum: 

### Items
### Encounters
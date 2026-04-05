### Datapack Objects
A datapack object is going to contain the following properties
- (overview)
	- Name
	- Description
	- Tone
	- Genre
	- Difficulty (1-20)
- (content)
	- species
	- backgrounds
	- classes
	- items
	- features
	- tags / properties
	- skills
	- player conditions

This page is entirely based on the creation of a datapack object, which has a list of properties that can be edited from the website through importing and exporting.

Most of the content properties are complex objects of their own.

Some parts of the datapack content reference other parts of the datapack. For example, if an item has custom tags, instead of containing a full copy of that tag, it'll contain the name of the tag so the computer can find and retrieve it's data once. References make things challenging, because if some piece of content is referenced and then removed, all of those references will point to something that no longer exists. That's why it's important to track if a piece of content is referenced somewhere else before removing it.

References will function based on the name on the piece of content. When creating a piece of content, a check must be run to verify that no two pieces of content exist with the same name. If they do, a number will be added such as (1), (2), etc.

Some content properties are going to contain default values that the game requires to function. These can't be removed.


### Default Datapack
This datapack is always included and cannot be modified. It contains all of the default, immutable pieces of content that cannot be removed without breaking the game.

Default Tags
- Is Armor
- Is Augment
- Is Currency
- Is Consumed
- Is Weapon
- Is Tool
- Is Skill

Default Skills
- Athletics (STR)
- Endurance (CON)
- Acrobatics (DEX)
- Sleight of Hand (DEX)
- Stealth (DEX)
- Deception (CHA)
- Intimidation (CHA)
- Performance (CHA)
- Persuasion (CHA)
- Insight (WIS)
- Perception (WIS)
- Investigation (WIS)
- History (INT)
- Medicine (INT)
- Engineering (INT)
- Arcana (INT)
- Art (INT)
- Nature (INT)

Stats
- Strength (STR)
- Dexterity (DEX)
- Constitution (CON)
- Intelligence (INT)
- Wisdom (WIS)
- Charisma (CHA)

Actions
- Action
- Bonus Action
- Free Action


### Content Objects
Species / Background / Classes
- Name
- Description
- HP
- Stat Boost Options
- Skill Boost Options (reference)
- Speed
- Features (reference)

Items
- Name
- Description
- Level
- Rarity
- Value
- Tags (references)
- Damage Equation
- Use Range
- Action Cost
- Use Stats
- Imbued Condition (reference)
- Defense Equation
- Slot Cost
- Imbedded Features (reference)

Custom Tags / Properties
- Name
- Function

Features
- Name
- Description
- Granted Skill Levels (reference)
- Granted Stat Levels
- Player Accessible
- Required Skill Levels (reference)
- Required Stat Levels

Skills
- Name
- Description
- Use Stats

Player Conditions
- Name
- Function
- Trigger
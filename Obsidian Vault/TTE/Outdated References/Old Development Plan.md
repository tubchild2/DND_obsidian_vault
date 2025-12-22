# MISSION
Allow users to develop fleshed out and balanced tabletop role playing games (or TTRPGs) of any genre and tone as fast as possible

# RELEASE
### Maker Mode
Feature Constructor UI

Stats as Enum
- Everything that takes a stat input
	- Item Use Stats
	- Skill Use Stats
	- Feature
		- Req Stats
		- Add Stats
- Checker to see if stat exists
- Stat dropdown menus change
- Null Stat is an option

Sections as Enum
- Add functions use section\[i]+1
- Preferences iterates through sections instead
- Get Section

Option for N/A Stat

Species HP calculator for complex HP
Class HP calculator for complex HP

Dropdown List Labels

Edit Content
- Closes manage library
- Opens related panel
- Loads information from item into editor
- Sets "overwriting" to true
	- "overwriting" is set to false whenever a panel is opened or closed
	- "overwriting" can be toggled in editor panels
	- While overwriting, any items with identical names will be deleted and replaced

Balancing
- Libraries
	- INT Difficulty
		- 1-10
- Expert Mode
	- Numeric input fields change from sliders to calculators
	- HP per level capped at 0-5 for species and classes
- Suggestions
	- When designing items, based off the difficulty and level of the item, the computer will create suggested values
- Background Species Class +1 stats and skills

Balancing Damage
Input
- Level
- Difficulty

### Console
- Opened with F1
- Allows you to create, delete, and browse content quickly but isn't user friendly
- Direct interface with the library
- Entirely Text Based

### Player Mode
- Main Menu
	- Import
	- Export as File
	- Export as Character Sheet
	- New
	- Edit
	- Copy
	- 2-Step Delete
- Creator
	- Select Library
	- Name, Traits, Flaws, Backstory, Goals
	- Starting Level
	- Core Stat Assignment
	- Starter Skill Assignment
	- Species, Background
	- Class / Multiclassing
	- Equip Armors and Augments
	- Feature Acquisition. (one per two levels)
	- Create a list of actions the player can take

### How To Mode
- Organized by section panel
- Update Rules
	- Items costs
	- Item rarities
	- Repeating bonus features
	- Augments
	- Augment Slots
- Tutorial
	- Fast
	- Covers
		- TTE Rules / How to Play
		- Maker Mode
		- Player Mode
		- Sharing

### Polish
- Hover button sound
- Text input char limit to prevent overflow
- Easter eggs
	- Entering 5318008 into the defense or damage maker returns an error message of nice
	- Entering 1987 into the defense or damage maker jumpscares you with golden Freddy and closes the app
	- Trying to set your username to tubchild, tubbs, unholytoothpaste, meatybutt3000, mb3, Aiden Warren, AKW, Cugel, tubchild2, or tubchild560 returns the error message, "impotstor"
- Donation link / Maybe charge $4.99
- Testing and patches
	- 5 creators
	- 5 players in unfamiliar library
	- 5 players in content they made
	- Feedback form


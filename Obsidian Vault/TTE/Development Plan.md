# MISSION
Allow users to develop fleshed out and balanced tabletop role playing games (or TTRPGs) of any genre and tone as fast as possible


IDEAS FOR SPEEDING UP COMBAT
- Control the conversation. It's your job to keep things moving. Make things fast.
- Stand up. If you stand up, you'll make players want to match your energy subconsciously. 
- Have players move their own minis.
- Timed combat.
- Visible initiative. Keep initiative on the DM screen so they can plan for their turn.
- Say who's on deck. Tell people who's next. 
- Rush players to make it keep the combat going. Punish them a little bit for not thinking ahead.
- Stack Turns. Let players take turns while other things are being tallied.
- Keep combat fresh.
- Keep a notepad. Keep a simple tool to make it so you can track enemy AC and HP easily. 
- Share features. Cut out redundancy so that they don't have to ask for enemy AC and stuff. Announce relevant stats when they discover them. Repeat it to them until they get it. 
- When players make informed decisions, they can make decisions faster.
- Mook wrangler. If there are a ton of basic goblins, have one of the players run them. Keep minions simple.
- Don't roll attack and then damage, roll them at the same time.
- Don't spend time looking up rules. If you need to, ahve ap layer do it or make a player leaning ruling
- Use bottlecap rings to mark conditions
- Use AOE markers
- Roll in front of the players because they can help with big math and it's engaging.
- Maybe, just maybe, your combat isn't long, it's just boring. Don't run identical combat. 
	- Mix up combat objectives
	- Mix up stakes

# RELEASE
### Maker Mode
Check prices on items in [[To-Do]]
Finish [[TTE Formulas]] for balancing (incredibly important for ruleset)

Feature Constructor UI
Stats as Enum
Sections as Enum
Option for N/A Stat

Species HP calculator
Class HP calculator

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
	- Makes numeric input fields infinite
	- Removes caps
	- HP per level capped at 0-5 for species and classes
- Suggestions
	- When designing items, based off the difficulty and level of the item, the computer will create suggested values
- Background Species Class +1 stats and skills

Balancing Damage
Input
- Level
- Difficulty

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





# UPDATE 1 - Worldbuilding and Community Support
### Maker Mode
- Stats 
	- Swapping stats for a new stat enum
	- Custom stats
- Library
	- Libraries have tone, genre, and style options.
	- Custom tone, genre, and style support.
	- Doesn't affect balancing, merely aesthetic. 
- Loot Tables
	- List of items tied to values ranging from a minimum to a maximum
	- Function to request a random item
- Complex Skills
	- Multiple Inherited Stats
	- No Inherited Stat
- Enemy
	- CR is replaced with Level. Suggestions balance enemies to match players of that level.
	- Created characters can be used as enemies.
	- Name, Description, Core Stats, HP, Defense, Speed, Features, Attacks, Loot Table
	- Give Weapon, Tool, or Consumable
	- Export as PNG
	- Export as Text File
	- Import Pictures
- GM Tools
	- Prosopography (add Enemies, mostly NPCs and historical figures, Import Pictures)
	- Bestiary (add Enemies, mostly land, air, water animals, etc., Import Pictures)
	- Herbarium (add Items, mostly plants, fungi, crops, etc., Import Pictures)
	- Atlas (add factions, add maps)
	- Narrative (add history, add events)
- Maps
	- Map Link Tool
	- Map Randomizers
	- Location Notes
	- Battle Map
	- Town Map
	- World Map
	- Export
	- Import

### Workshop / Marketplace
- Account 
	- Scoring system (1 coin per download)
		- No microtransactions
	- Rewards tied to scoring system
		- Achievements
		- Trophies
		- High Rollers Club (1000+ coins)
		- Leaderboards
	- Community guidelines and enforcement
	- Account strikes and bans
- Reporting system
- Post / browse / download

### How To Mode
- Update Tutorial for complex skills, loot tables, GM tools, maps, and the workshop / marketplace

### Polish
- Push light marketing on YouTube
- Reach out to influencers
- Easter Eggs
- Testing and patches
	- 5 creators
	- 5 players in unfamiliar library
	- 5 players in content they made
	- Feedback form





# UPDATE 2 - VIRTUAL TABLETOP

### Maker Mode
- Export privacy library. Cuts all potential spoilers and provides only content important to character creation.

### Player Mode
- Peak Esc Character Miniature Maker
	- Color
	- Face
	- Presets
	- Cosmetics
		- Unlocked with experience
		- No microtransactions
		- No marketplace
	- Goofy, Simplistic, Colorful. Landfall Esc.

### GM Mode
- Campaign Notes
- Players
- Session Prepper
	- Notes
		- Presets
		- Guides
	- Maps
	- Music Player
		- Custom Playlists
		- Playlist Hotkey
		- Custom SFX
		- SFX Hotkey
	- Encounter Maker
		- Battlemap
		- Enemies
		- Loot
		- Lock and Key
		- Special Objectives
	- Room
		- Preset
		- Lighting
		- Weather
		- Goofy, Simplistic, Colorful. Landfall Esc
- Session Runner
	- Host / Join (IP / Invite by Username / Open to World / Password)
	- Player Avatar Seating
	- Proximity Chat
	- GM Options
		- Edit player characters information
			- HP (attack / heal)
			- Conditions
			- Inventory
			- Levels
			- Skill Levels
			- Stat Points
		- View a GM screen
			- Session Notes
			- Maps
			- Music
			- Room Options
			- Library Content
		- Form Teams for Combat
		- Control non-player teams
	- Player Options
		- Move character miniature on map
		- Make a skill check
		- Make an attack roll
		- Take notes

### Workshop / Marketplace
- Peak Esc Avatar Maker
	- Color
	- Face
	- Presets
	- Cosmetics
		- Unlocked with experience
		- No microtransactions
		- No marketplace
	- Goofy, Simplistic, Colorful. Landfall Esc.

### How To Mode
- Teach GM Mode
- Update for changes

### Polish
- Advertise
- Reach out to TTRPG creator for feedback and publicity
- Testing and patches
	- 5 creators
	- 5 players in unfamiliar library
	- 5 players in content they made
	- Feedback form
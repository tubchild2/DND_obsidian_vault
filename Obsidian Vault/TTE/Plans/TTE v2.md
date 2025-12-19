### **PHASE 0: RULES AND PREPERATION**
**Combat Rules Ideation**
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

### **PHASE 1: CONSOLE BACKEND**
**CONSOLE**
- Create a Console that can be opened with "F1" that commands can be typed into
- Create an interpreter that can break commands up into parts using "Split()"

**FILE MANAGEMENT PREPERATION**
- Constant library, preference, and character folders
- Create, destroy, import, and export library, preference, and character files
- Generate readable format library, character
- Datatypes and Enums
	- Core Stats
	- Statblock (core stats + SPD, DEF, LVL, MHP)
	- Item
	- Item Property
	- Skill
	- Feature
	- Player Condition
	- Background
	- Species
	- Class
	- Library Information
	- User Preferences
	- Equation
		- Core Stats
		- Dice
		- + -
		- Numbers
	- **Datatype Quantities**
- Create error message handler
	- Consistent format
	- Descriptive error messages
- Create Checker for 
	- Invalid characters (? ! : ; { ) etc.
	- Invalid String
	- Invalid Stat
	- Invalid Skill
	- Invalid equations
	- Check everything up front immediately
	- Boolean "Expert Mode"
		- Removes caps

**FILE MANAGEMENT**
- JSON Preference
	- User Preferences
		- Username
		- SFX Volume
		- Music Volume

- JSON Library
	- Library Information
		- Name
		- Description
			- Tone
			- Genre
		- Difficulty
		- Size
	- Items
	- Skills
	- Item Properties
	- Features
	- Player Conditions
	- Backgrounds
	- Species
	- Classes

- JSON Character
	- Inheriting Library
	- Name
	- Traits
	- Backstory
	- Goals
	- Background
	- Species
	- Class / Levels
	- Core Stats
	- Speed
	- Defense
	- Max HP
	- Current HP
	- Skills
	- Items
	- Features

**BALANCING**
- Suggestions auto generate in console
- Use Balancing Formulas


**CONSOLE**
- Create Commands for:
	- Creating, deleting, editing, viewing, user preferences
	- Creating, deleting, editing, viewing, *all* types of library content
	- Creating, deleting, editing, viewing, character information
- Completely finish logic behind the scenes before progressing

### **PHASE 2: FRONT END**
UI
- Design UI
	- Clocky
	- Pixel Art
	- Compact and Efficient
	- Customized
	- Not overwhelming
	- Lots of breathing room
- Create UI for:
	- Creating, deleting, editing, viewing, files
	- Creating, deleting, editing, viewing, user preferences
	- Creating, deleting, editing, viewing, *all* types of library content
	- Creating, deleting, editing, viewing, character information

SOUND
- Design Sound
	- 16 Bit
	- Clunky
- Design Music
	- Synthesized
	- Ambient
	- Unintrusive

HOW TO PLAY
- Brief tutorial

### **PHASE 3: POLISH AND RELEASE**
- Easter Eggs
	- Entering 5318008 into the defense or damage maker returns an error message of nice
	- Entering 1987 into the defense or damage maker jumpscares you with golden Freddy and closes the app
	- Trying to set your username to tubchild, tubbs, unholytoothpaste, meatybutt3000, mb3, Aiden Warren, AKW, Cugel, tubchild2, or tubchild560 returns the error message, "impotstor"
	- A horror minigame can be loaded which a secret button input
- Donation link / Maybe charge $4.99
- Testing and patches
	- 5 creators
	- 5 players in unfamiliar library
	- 5 players in content they made
	- Feedback form
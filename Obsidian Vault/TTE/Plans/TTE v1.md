### Mission
Create a fun, easy way to make easily sharable content for customized TTRPGs that can involve anything the user wishes.

Summary:
- Content (skills, weapons, characters, classes, etc.) is formed into datapacks
	- This content can involve anything, be of any genre, and be of any tone
	- The game's auto balancing system speeds up content creation tenfold
- Datapacks can be sent and shared online
- Downloaded Datapacks can be used to create characters
- Rapid creation of a TTRPG, and characters for it. It's automatically balanced, and of any genre, tone, and difficulty.
- You can host it like you do any other TTRPG.

### Validation and Default Values and Constructors for AMT
preferences 
core stat amt
CoreStatBlock
Derived Stat AMT
Equation
Library Attributes
ID
ID Amt

Skill AMT
Property
Condition
Feature\*


Change Library -> Datapack
Consider Isometric VTT
IDs -> Strings
Item Set Parameters
Item Skills
Error Messages
### Data Management
Goal
- Finish by Jan 10

Design Philosophy
- Easily understood error messages
- Extensive validation and reference checking
- Clean, efficient, expandable
- JSON
- Store data with an auto incrementing ID for references instead of by name
- Disallow item features that grant the current item

Preferences File
- Create File
- Destroy File
- Edit File
	- Username
	- SFX Volume
	- Music Volume

Library File
- Create File
	- Create Null objects at ID = 0
- Destroy File
- Import File
- Export File
- ID Manager
	- IDs should not be changed at any point. Once they are assigned to content, that content ID will remain static until it is deleted. Non-dynamic ID system, no mass reordering.
	- Upon creation, in the constructor, Request ID should be called immediately for a new address.
	- Public Type Enum
		- 0 = ERR
		- 1 = Skill
		- 2 = Class
		- 3 = Item
		- etc.
	- IDs
		- Strings
		- ID look like, "0000000"
		- The first three digits indicate type (converts from type enum)
		- The last four digits indicate address 
		- Each type acts as its own list (0-100+)
		- Multiple pieces of data can have the same address if they're of different types
	- Validate ID (ID)
		- Collect all IDs of type (first three digits) (converts to type enum)
		- If IDs contains ID
		- return false
		- else
		- return true
	- Has Dependencies (ID)
		- Use ID type system to get lists of applicable content
		- Check if the item's ID is referenced anywhere
		- Return true if it is and run an error message that shows where
		- Return false if it isn't
	- Request ID (type enum)
		- Null Objects have ID = 0, so never return 0
		- It should pull up the list of content IDs, and find the earliest available ID for a new piece of content
			- If no ID = 0 exists, create null object
		- Run validate ID on new ID
		- Return New ID
	- Request Data (type, ID)
		- Returns Decompiled JSON
		- if ID = 0, return null
- Edit File
	- Name
	- Description
	- Level
- Validate Data
- Add Data
- Remove Data
	- References checker to prevent missing dependencies error
- Get Data
- Get All Data of Type
- Get All Data of Type as List of Strings
- Edit Data

Character File
- Create File
- Destroy File
- Import File
- Export File
- Get Character Data
- Overwrite Character Data

### Console
Design Philosophy
- Incorporate balancing suggestions where possible
- Validate all input
- Clean, efficient, expandable

Commands
- Input Validation
	- Strings
	- Integers
	- Floats
	- Bools
	- Lists
	- Selection from list
- Input Interpretation
	- Request Data of Type
	- Type is broken into each of its parts
	- Each part is requested from the user
	- If a part is a list, use list requesting
- Commands
	- Balancing
	- Item Rarity Interpreter
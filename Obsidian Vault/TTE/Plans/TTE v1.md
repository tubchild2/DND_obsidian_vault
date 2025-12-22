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

### Item Set Parameters
### Item Skills

### Error Messages


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
- Destroy File
- Import File
- Export File
- Data ID Manager
	- Set IDs upon creation of ID content 
	- Each type of data (skills, items, etc.) has a separated ID system
		- Null objects have ID = 0 and exist for all content that uses IDs 
		- It should pull up the list of content IDs, and find the earliest available ID for a new piece of content
			- If no ID = 0 exists, create null object
		- IDs should not be changed at any point. Once they are assigned to content, that content ID will remain static until it is deleted.
		- This is to prevent errors caused from mass ID changes from reordering.
	- This manager can get IDs, set IDs, and pull data from IDs
	- Additionally, it should check if an ID is taken
	- It should check if an ID is being used elsewhere to prevent missing dependencies error
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
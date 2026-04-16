### Plot
You are a prisoner confined to the security room. You've been awakened from cryosleep to fill responsibilities that no one else can.
You must monitor and protect the L55 or you'll be executed.
You quickly realize that you're the only person on the ship that's alive.
Your goal is to keep the ship running and survive.
Eventually, you get a chance to escape.
You must move the ship a certain distance by the end of the day
There's something on the ship that wants to kill you and becomes more active the hotter the ship is


### ART
##### Visuals
- 1990s FPS
	- 64 bit textures
- 80s retrofuturistic cyberpunk
	- No touchscreens
	- Analog everything
	- Oscilloscopes
	- Rust
- Portal Escape Sequence
	- Can't go everywhere
	- Suggested scale beyond comprehension

##### Music
- Akin to Portal 1 / Better Call Saul
- Ambient, Digital, Mechanical, and Unsettling


### GAMEPLAY
##### Overview
- You need to move the ship a certain amount by the end of the day or you lose
- The faster you go, the more aggressive enemy AI becomes, and the faster things deteriorate
- The slower you go, the less likely it is that you'll make it in time


##### Day 1
- help
	- Shows a list of commands you can access
	- Shows your mission overview and what you need to do today
- man cmd
	- man followed by a command that you'd like help with
	- Cites the manual and explains what it does and how to use it
- Quota Information
	- quota
		- Gets the amount of distance you need to move the ship, as well as how far you've moved it
	- time
		- Gets the time and date, and displays how long it'll be until you must satisfy your quota
- Monitor Engine Temperature.
	- egt
		- Gets engine temperature
	- acl +n
		- Accelerates
		- Heats engine
	- acl -n
		- Decelerates
		- Cools engine


##### Day 2
- Monitor Cameras
	- cam
		- Opens camera panel
	- +n
		- Switches forward n cameras
	- -n
		- Switches back n cameras
	- n
		- Switches to camera n
	- esc
		- Closes camera panel
- Seal Doors
	- opn_d n
		- Opens a door
		- Allows something to move through it
	- cls_d n
		- Closes a door
		- Prevents anything from moving through it
		- Only one door can be closed at a time


##### Day 3
- Enemy AI more aggressive
- More distance is required
- Radio
	- Decrypt an amount of transmissions for quota
	- They prevent you from doing anything else
	- scan
		- Lists incoming transmissions by number (n), quality, and clarity.
		- Takes 5 seconds to scan
	- scan n
		- Decrypts a transmission selected by n
		- Requires that 'scan' has already been run
		- Higher quality transmissions yield more for your quota but usually have lower clarity (percentage of successful decryption). There's a chance you have to repeat low clarity scans. 
		- Takes 5 seconds to attempt to scan
- Logs
	- log n
		- Lets you view a log of name n
		- Hints for these logs are hidden throughout the ship, and in your room


##### Day 4
- Enemy AI more aggressive
- More distance is required
- More transmissions required
- Hiding
	- If you suspect something has entered your room, you can get up from your chair and hide until it passes
	- Doing so removes your access to your terminal, but saves you from death


##### Day 5
- Enemy AI more aggressive
- More distance is required
- More transmissions required
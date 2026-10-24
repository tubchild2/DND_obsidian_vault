
TO DO
- Balance traits wealth gain, loss, and risk.
- Create an iterate wealth function to go through all of the traits and apply the balancing you made.
- Create the timeline, turn, and choice systems.
- Make it update the display live with a function.
- Update Arcohaem lore page
- Update Serendipita lore page

VILLAGE GENERATION
1. Select location in Arcohaem
2. Select founding date
3. Generate Geography
4. Simulate History by stepping through village timeline
	1. Historical Events
	2. Random Events (2)
	3. Trait Application
5. Display name, location, traits, and history

TIMELINE SYSTEM
1. Creates an integer that starts counting at the year the town was founded
2. Steps forward a number of years and triggers a random event
3. Milestone years trigger events when passed

```
const step_size = 25;
let timeline = village_birth;
let last_turn = timeline;
const random_event_count = 25;

while (timeline < current_year) {
	// Historical Events
	if (event1_year > last_turn && event1_year < timeline) {
		event1_traits = ["trait1", "trait2", "trait3"];
		if (select_traits(event1_traits, max, proc) != []) {
			history.push("event1 happened");
		}
		else {
			history.push("event1 didn't happen");
		}
	}
	last_turn = timeline; 

	// Random Events
	
	// Trait Application
	
	// Timeline Progression
	timeline += Math.floor(Math.random() \* setp_size);
}

```


const step_size = 25;
const num_events = 5;
let timeline = village_birth;
while (timeline < current_year) { 
	let event = Math.floor(Math.random() * num_events)
	switch (event) {
		case (0):
			event1_traits = \[e1trait1, e1trait2, e1trait3];
			if (select_traits(event1_traits, max, proc)) {
				history.push("event 1 happened in " + timeline);
			}
			break;
	};
	timeline += Math.floor(Math.random() * step_size);
}

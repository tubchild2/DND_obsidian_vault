Immersion, Ambience, and Exploration
- Far fewer structures
- Much better structure loot
- Lonelier
- Bigger biomes
- Cubic chunks
- Much greater render distance with sprite descaling
- More cave noises
- Darker
- Rare, naturally occurring mobs that are much bigger and scarier but yield some good loot
- Dungeons are bigger and require skill to overcome
- Oceans are bigger
- Continents generate
- Wind, fog, ambience
- Make each world genuinely unique. Not more of the same. There are things that can happen in some worlds that won't in others. Each world has unique traits like these.

Balancing
- Phantoms should spawn if you sleep too much, but they're disabled by default.
- Add a "knife," which functions identically to a pre 1.9 sword but does less damage
- Mobs are generally smarter and tougher to compensate for more player power

Systemic Design Philosophy
Minecraft is at its best when its adding systems that can synergize with each other and with the rest of the game, rather than adding one-and-done content that loses flavor quickly. The greatest example of this is redstone. So, if I were making an update, I'd focus on expanding on three systems: redstone, villagers, and magic.

Redstone
- Timer block
- Clock block
- Conveyor belt
- Logic gates
- Double pistons
- Triple pistons
- Block rotator
- Drill: breaks block in front of it and stores it (up to 9 stacks of blocks)
- Placer: places a block in front of it
- Grinder 
	- Deals chip damage and moves items forward
- Bin: expandable massive storage

Villagers
- Matches your progression and scales with it.
- All items use an emerald standard to balance their values around to prevent unbalanced or unrealistic trades. You can sell items of values based off this emerald standard.
- Villagers can accomplish in-game tasks like mining, building, farming, guarding, fighting, and sorting. 
- Village salesman can sell many more items using the emerald standard
- Villagers need food, and housing to survive, and emeralds to work. You can assign homes to villagers as well as where they should get their food and pay from.
- You can have one villager tell another villager what to do with a basic front-end scripting language.
- Raiders are smarter, can break blocks, can cooperate, and require building defenses and armies to defeat. They scale with your village size. The final raid defeats them for good, or you can find their hideout and kill the pillager king.
- Incentivizes building kingdoms and taking care of the villagers, who are smarter but much more powerful
- Wandering traders can sell many more things, and have catalogues instead of a small list of trades

Magic
- Overview
	- Much more expansive, much more powerful
	- Requires a lot of lapis, books, knowledge, and monster parts
	- Lapis should yield much more per vein and be more common
- Potions
	- You can mix potion effects like enchanted books
	- Potion of Aggression causes mobs to attack whatever is near them given it's not the same type of creature. If used on a player, all nearby living entities look like monsters.
	- Potion effects are much stronger and last longer to justify their expanded cost
	- A bigger focus on brewing custom potions
- Enchanted Books
	- Enchanted potions
	- Enchanted saddles
	- Enchanted explosives
	- Enchanted storage
	- Enchanted arrows
	- You can craft enchanted books of a specific type, but you need to follow a recipe that you don't always know, like with potion brewing
	- Enchanted books have the enchantment they have. For example, a book with sharpness deals more damage, a book with fire aspect lights people on fire. 
	- Some enchantments provide direct application without enchanting an item. With a lot of lapis, and through following a recipe (like with potion brewing) you can craft these types of enchantments. They're much more powerful and expensive. Fireball, water bolt, lightning, explosive, wind gust, vacuum, pillar, pit, etc. Actual spell books. 
	- Higher level enchantments like spell books expend lapis in your inventory, then your health. Some cost more than others.
	- You can apply spell books to items. So, you can make a sword that shoots fire or a mace that summons lightning.
- Alchemy
	- You can summon animals, mobs, and resources, but you need to expend something of greater value
	- Calculates how valuable what you're asking for is based off the emerald standard, multiplies its value by 1.5, and then adds an additional lapis cost
	- This is very powerful, so it's incredibly expensive. The deals are designed to not be very good, and to for sure be worse than just 
	- Lets you summon an eldritch boss
- Cursing
	- You can curse potions, and enchanted books to make them multiple times more powerful, but with a serious and significant drawback.
	- You can curse them again, but each time the drawbacks will only get worse.
- Redstone components
	- Evoker: A block that can use a spell book on command like with redstone
	- Transmitter / receiver: long distance wireless redstone with varying ranges.
		- Input range in chunks (1-2-4-8-16)
		- Input channel (integer)
	- Storage Sorter: lets you automatically sort attached storage, including bins
	- Item elevator: lets you vertically move items incredibly quickly
	- Portal:
		- An endgame items
		- Allows instantaneous travel between two points in space in any dimension
		- Recipe (makes two)
			- Transmitter
			- Receiver
			- Lodestone
			- Ender pearl
			- Obsidian
			- Blaze powder
			- Nether star
			- SHULKER Shell x2
	- High-capacity redstone
		- Carries maximum signal strength of 30
	- Smart auto-crafter
		- Input a recipe
		- It outputs a comparator signal when the recipe is filled
		- Powered to craft the item
		- Stores up to 9 stacks of crafted items
		- Hoppers take only crafted items
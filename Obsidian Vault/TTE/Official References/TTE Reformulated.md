## **RULES**
### **ITEM RARITIES**
1. Poor (Black)
2. Common (Gray)
3. Uncommon (White)
4. Rare (Blue)
5. Very Rare (Green)
6. Epic (Yellow)
7. Legendary (Orange)
8. Mythical (Red)
9. Relic (Deep Red)
10. Eternal (Deep Purple)

### **DIFFICULTIES**
1. Story (Black)
2. Guided (Gray)
3. Casual (White)
4. Easy (Blue)
5. Normal (Green)
6. Hard (Yellow)
7. Expert (Orange)
8. Brutal (Red)
9. Nightmare (Deep Red)
10. Hell (Purple)
11. Abyss I
12. Abyss II
13. Abyss III
14. Abyss IV
15. Abyss V
16. Abyss VI
17. Abyss VII
18. Abyss VIII
19. Abyss IX
20. Abyss X


### **STATS**
**LOGIC**
- 6 stats (STR, DEX, CON, CHA, INT, WIS)
	- Deadlift = (STR)20 + 100
- Start with Standard Distribution (-1, -1, 0, 0, 1, 1)
- Backgrounds, classes, and species each add and remove one stat (+1, -1)
- Every following Level, add +1 to one stat

**INPUT**
- Level (l)
- Some assumptions made

**MINIMUM**
$$-4$$

**AVERAGE**
$$\frac{\left(l-1\right)}{6}$$

**MAXIMUM**
$$3+l$$


### **SKILLS**
**LOGIC**
- 18 Skills
	- ATHLETICS (STR). Jump farther, stay afloat in rough water, break something.
	- ENDURANCE (CON). Resist poison, resist exhaustion, power through a hot room.
	- ACROBATICS (DEX). Stay on your feet or perform an acrobatic stunt.
	- SLEIGHT OF HAND (DEX). Pick a pocket, conceal an object, swap items, etc.
	- STEALTH (DEX). Escape notice by moving quietly and hiding.
	- DECEPTION (CHA). Tell a convincing lie or wear a convincing disguise.
	- INTIMIDATION (CHA). Awe or threaten someone into doing what you want.
	- PERFORMANCE (CHA). Act, tell a story, perform music, or dance.
	- PERSUASION (CHA). Honestly and graciously convince someone of something.
	- INSIGHT (WIS). Discern a person’s mood or intentions.
	- PERCEPTION (WIS). Notice something that’s easy to miss.
	- INVESTIGATION (WIS). Find obscure information in books, deduce something.
	- HISTORY (INT). Recall lore about historical events, people, nations, etc.
	- MEDICINE (INT). Recall information about disease, death, health, and medicine.
	- ENGINEERING (INT). Recall information about using / making machines (if any).
	- ARCANA (INT). Recall information about your world’s unnatural elements (if any).
	- ART (INT). Recall information about art, or about creating art.
	- NATURE (INT). Recall information about nature, farming, or survival.
- Start with +1 to three skills
- Backgrounds, Classes, and Species all add +1 to 3 skills
- Every following level, add +1 to one skill

**INPUT**
- Level (l)
- Some assumptions made

**MINIMUM**
$$0$$
**AVERAGE**
$$\frac{11+l}{18}$$

**MAXIMUM**
$$3+l$$


### **ROLL MODIFIERS**
**LOGIC**
- Roll modifiers are the sum of your stat and skill levels

**INPUT**
- Level (l)

**MINIMUM**
$$-4$$

**AVERAGE**
$$\frac{2\left(l+2\right)}{9}$$

**MAXIMUM**

$$6+2l$$


### **HP**
**LOGIC**
- Every level:
- HP += CON
- HP += Species HP (ranges from 1-5) (averages 3)
- HP += Class HP (ranges from 1-5) (averages 3)
- HP += Level 
- HP += 2

**INPUT**
- Level (l)
- Constitution (c)
- Species hp (s)
- Class hp (h)

**FORMULA**
$$\frac{l\left(l+1\right)}{2}+l\left(c+s+h+2\right)$$

**MINIMUM**
$$\frac{l\left(l+1\right)}{2}$$

**AVERAGE**
$$\frac{l\left(l+1\right)}{2}+l\left(\frac{\left(l-1\right)}{6}+8\right)$$

**MAXIMUM**
$$\frac{l\left(l+1\right)}{2}+l\left(l+15\right)$$


### **DAMAGE**
**LOGIC**
- The amount of hits on average it should take to kill a player is 2 times the difficulty
- Average player health is divided by that value
- Then, rarity is added to everywhere that level appears to scale it

**INPUTS**
- Level (l)
- Difficulty (d) (see "Difficulties")
- Rarity (r) (see "Item Rarities")

**FORMULA**
$$\frac{l\left(2l+25\right)\left(1+0.5r\right)}{6d}$$
### **DEFENSE**
**LOGIC**
- Defense should be able to keep up with modifiers give or take rarity and difficulty
- hit modifier

**INPUTS**
- Level (l)
- Difficulty (d) (see "Difficulties")
- Rarity (r) (see "Item Rarities")

**FORMULA**
$$-d+l+0.5r+19.5$$

### **VALUE**
**LOGIC**
- Difficulty increases value by 5%
- Rarity increases value by 10% and adds 10 per point above 1
- Damage increases value by 11 per point
- Defense increases value by 20 per point
- Range increases value by 8 per point
- Use stats increase value by 30 per point
- Consumed on use decreases value by 50%

**INPUTS**
- Difficulty (d) (see "Difficulties")
- Rarity (r) (see "Item Rarities)
- Damage (m)
- Defense (f)
- Range (n)
- Consumed (c)
- Use Stats (u)

**FORMULA**
$$\frac{\left(1+0.05d+0.1r\right)\left(11m+20f+8n+30u+10\left(r-1\right)\right)\left(2-c\right)}{2}$$

### **ENCOUNTERS**
Total HP Pool by Level, Difficulty
Total Damage Per Turn by Level, Difficulty
Absolute Value of Loot by Level, Difficulty
- Increase at a rate in which players can afford higher tier weapons
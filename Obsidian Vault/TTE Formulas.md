**Levels**
	1 = Common
	2-3 = Uncommon
	4-5 = Rare
	6-7 = Legendary
	8-9 = Mythical
	10 = Artifact

**Difficulties**
	1 = Auto
	2-3 = Casual
	4-5 = Standard
	6-7 = Veteran
	8-9 = Expert
	10 = Hell


## Player Stats
**Average Player Stat At Level (l)**
$$(l+ 2) / 6$$
**Maximum Player Stat At Level (l)**
$$l + 3$$
**Minimum Player Stat Value**
$$-1$$
**Average Player Skill Level At Level (l)**
$$?$$

**Maximum Player Skill Level At Level (l)**
$$?$$

**Minimum Player Skill Level**
$$0$$

**HP Formula**
Inputs:
- Level (l)
- Constitution (c)
- Species HP (s)
- Class HP (h)
$$l(c+h+s)$$

**Average HP Per Level**
$$5$$
**Average Player HP At Level (l)**
$$5l+((l+2)/6)$$
**Maximum Player HP At Level (l)**
$$10l + (l+3)$$
**Minimum Player HP At Level (l)**
$$l-1$$

## Item Stats
**Average Item Damage At Level (l) By Difficulty (d)**
$$0.5l^2(20-(d-1))$$

**Average Item Defense At Level (l) By Difficulty (d)**
$$(20-d)+l$$

**Average Item Cost**
Inputs:
- Item Level (l)
	- Adds L\^6
- Difficulty (d)
	- Adds 10% per D-1
	- Hell mode doubles prices
- Number of Use Stats (0-6) (s)
	- Adds 6% per S-1
	- All use stats are 30% more valued
- Number of Uses (0-4) (u)
	- Adds 10% per U-1
	- Complete multitools are 30% more valued
- Consumable (0-1) (c)
	- Subtracts 50% per C
	- Items that are destroyed on use have half the value
- Expected Damage (m)
	- Adds 10M
- Expected Defense (f)
	- Adds 20F

Formula:
$$(l^{6}+10m+20f)\frac{\left(100+10\left(d-1\right)+6\left(s-1\right)+10\left(u-1\right)-50c\right)}{100}$$



## Encounter Stats
**Average Encounter Total HP by Encounter Level (l) and Difficulty (d)**




**Average Encounter Total Damage Per Turn at Level (l) and Difficulty (d)**
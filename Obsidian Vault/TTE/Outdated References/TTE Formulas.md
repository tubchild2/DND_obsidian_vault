# **RULES**
### **ITEM TIERS**
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

### **LIBRARY LEVELS**
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

### **STAT LOGIC**
- Standard Array (-1, -1, 0, 0, 1, 1)
- Background potential +1 to any/all core stats
- Species potential +1 to any/all core stats
- Class potential +1 to any/all core stats
- Level up potential +1 to any core stat (repeating)

### **SKILL LOGIC**
- Standard +1 to 3 skills
- Background +1 to 3 skills
- Species +1 to 3 skills
- Class +1 to 3 skills
- Level up +1 to any skill (repeating)

### **HP LOGIC**
Each Level:
- HP += CON
- HP += Species HP
- HP += Class HP
- HP += Level
Equation
- L = Level
- C = Constitution
- S = Species HP
- H = Class HP
$$
\frac{L\left(L+1\right)}{2}+L\left(C+S+H\right)
$$


# **BALANCING**
### **STATS**
**INPUT**
- Level (L)

**MINIMUM** 
$$-1$$

**AVERAGE**
$$\min\left(5,\frac{\left(L+2\right)}{6}\right)$$

**MAXIMUM** 
$$\min\left(5,\ L+3\right)$$


### **SKILLS**
**INPUT**
- Level (L)

**MINIMUM**
$$0$$

**AVERAGE**
$$\min\left(10,\frac{L+11}{18}\right)$$

**MAXIMUM**
$$\min\left(10,\ L+3\right)$$


### **MODIFIER**
**INPUT**
- Level (L)

**MINIMUM**
$$-1$$

**AVERAGE**


**MAXIMUM**

### **HP**
**INPUT**
- Level (L)

**MINIMUM**
$$\frac{L\left(L+1\right)}{2}+L$$

**AVERAGE**
$$\frac{L\left(L+1\right)}{2}+L\left(\min\left(5,\frac{\left(L+2\right)}{6}\right)+6\right)$$

**MAXIMUM**
$$\frac{L\left(L+1\right)}{2}+L\left(\min\left(5,\ L+3\right)+10\right)$$


### **DAMAGE**
**INPUT**
- Level (L)
- Difficulty (D)

**UNDERPOWERED**
$$\frac{\frac{L\left(L+1\right)}{2}+L}{2D}$$

**AVERAGE**
$$\frac{\frac{L\left(L+1\right)}{2}+L\left(\min\left(5,\frac{\left(L+2\right)}{6}\right)+6\right)}{2D}$$

**OVERPOWERED**
$$\frac{\frac{L\left(L+1\right)}{2}+L\left(\min\left(5,\ L+3\right)+10\right)}{2D}$$


### **DEFENSE**
**INPUT**
- Level (L)
- Difficulty (D)

**UNDERPOWERED**
$$\left(19+L\right)-D$$

**SUGGESTED**
$$\left(20+L\right)-D$$

**OVERPOWERED**
$$\left(21+L\right)-D$$


### **VALUE**
**INPUT**
- Difficulty (D)
- Damage (M)
- Defense (F)
- Range (R)
- Consumed (C)
- Use Stats (U)

**FORMULA**
$$\left(1+0.05D\right)\left(11M+20F+8R+30U\right)\left(\frac{2-C}{2}\right)$$

### **ENCOUNTERS**
Total HP Pool by Level, Difficulty
Total Damage Per Turn by Level, Difficulty
Absolute Value of Loot by Level, Difficulty
- Increase at a rate in which players can afford higher tier weapons
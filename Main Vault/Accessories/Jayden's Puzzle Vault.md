### Overview

The Paper
1. Find hidden piece of paper taped to the bottom of the safe
2. The paper says "73 65 63 72 65 74 6C 61 6E 64 69 6E 67 2E 68 74 6D 6C"
3. Convert hexadecimal on paper into string to yield "secretlanding.html"
4. Use the string to access a hidden page on tabletopengine.net/secretlanding.html

The Login (make sure inspect element won't reveal the password, obscure JS code)
1. Username
	1. Find invisible text on the page
	2. Copy + paste to see it, "losmkhgkewwswkhgloh"
	3. Use the string to access tabletopengine.net/losmkhgkewwswkhgloh.html
	4. The page contains the hints
		1. First word of the key is a weapon that was instrumental to us becoming friends.
			1. "shotgun" because we became friends by playing Shotgun Farmers of all things
		2. Second word of the key is the last name of the protagonist in the biggest flop of 1988
			1. "cruise" from Mac and Me, because we watched it and had a blast
	5. Decrypting the string with a vignere cipher key of "shotguncruise" yields the username, "thetentincoassassin"
2. Password
	1. Click "Forgot Password" to go to another page
		1. Security question: what is the 42nd number in a famous math sequence?
			1. "267914296"
		2. Security question: My daddy's got a gun.
			1. "Hayloft"
		3. Security question: The numbers are missing, astray, gone, \_\_\_.
			1. "4815162342"
	2. Your password is "FamousPilot2001"


The Landing
1. Digit A
	1. The last digit to the solution of the Reinmann Hypothesis
	2. Must be brute forced
2. Digit B
	1. Start with the number 125298
	2. If the number is odd, add all of the numbers together
	3. If the number is even, square it and subtract 1
	4. Repeat until one digit remains
	5. Solution
		1. 125298
		2. 15699588803
		3. 62
		4. 3843
		5. 18
		6. 323
		7. 8
	6. Digit B is 8
3. Digit C
	1. "..-. --- ..- .-."
	2. "FOUR"
	3. Digit C is 4
4. Digit D
	1. Hint
		1. 1 + 2 = 3
		2. 2 + 3 = 11
		3. 12 + 12 = 30
		4. 10 - 2 = ?
	2. Digit D is 2

The Safe
1. Enter the digits 6, 8, 4, 2
2. Inside the safe is a puzzle box that must be solved
3. Inside the puzzle box is a note that says, "gotcha"

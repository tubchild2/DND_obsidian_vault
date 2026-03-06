### Legislation
- The SOX act was passed in response to public scandals like Enron and WorldCom. 
	- It establishes strict rules specifying what data should be kept and how it should be stored
- The HIPAA was enacted to protect the privacy of people's medical records
	- Lets you transfer and continue health insurance coverage when you lose your job
	- Reduces health care fraud and abuse
	- Mandates industry-wide standards for health care information on electric billing and other processes
	- Requires the protection and confidential handling of protected medical records
- FERPA protects the privacy of student education records
	- Parents can inspect. Schools don't have to provide these, and they can charge for it.
	- Parents and eligible students have the right to request that school records be corrected. If the correction isn't accepted by the school, the student can place a statement with the record setting forth his or her view about the contested information.
	- Generally, schools must have written permission from the parents or eligible student to release any information from a schools record. But, FERPA allows schools to disclose the records without consent under certain circumstances.
- GLBA act allows banks to also act as investment companies
	- Likely caused the 2007 housing crisis
- CERT
	- Computer Emergency Response Team
	- The CERT Coordination Center is a nonprofit organization from Carnegie Mellon University
	- They research internet security vulnerabilities and coordinate responses to major threats
	- Companies typically have their own CERT

### Value of a Company is in its Data
- Investment trading companies' value is in its data
- A car dealership's value is not in its data

### Confidentiality, Integrity, and Accessibility
- Confidentiality: providing data only to those who are authorized to view it
- Integrity: making sure data is not altered
- Availability: making the data available when needed

### Malware
- Viruses and Worms
	- A virus is a software program capable of reproducing itself and usually capable of causing great harm to files or other programs on the same computer
	- A worm is a self-replicating virus that resides in active memory and duplicates itself from computer to computer without any action by a human. They often cause problems when they reproduce so much that they consume all available resources.
	- Anti-virus software builds profiles of what viruses look like and detect and destroy them. It has its tentacles all throughout the operating system once installed, and can be difficult to remove completely.
- Zero Day Attack
	- When a virus first appears, before virus protection software engineers have seen the virus.
	- This is when the virus is the greatest threat
- Spyware
	- Computer software that obtains information from a user's computer without the user's knowledge or consent.
- Trojan Horse
	- Malicious program that misrepresents itself as useful, routine, or interesting in order to persuade a victim to install it
- Denial of Service Attacks
	- Use up all available resources using a large number of unsuspecting computers and turning them into zombies
	- Prevents a business from operating regularly

### Patches
- OS Patches
- Application Patches

### Physical Security
- Firewalls and crap add protection but they're useless if I can grab your laptop
- Once I have a laptop, I can use the login and password and the VPN to pass the firewall and read any files you have downloaded

### Disaster Recovery
- Store backups
- Think about the types of disasters that might occur
- Things happen, so you have to plan for them
- Earthquakes, floods, fires, intruders, viruses, etc.

### Security Policy
- Without a plan, major effort and considerable money can be wasted devising and supporting reasonable sounding systems that can be easily circumvented
- A strong firewall by itself is a wasted investment if your VPN policy is not equally strong, along with your password policy and physical security
- It must be comprehensive and rigorously enforced if it is to be useful

### Firewalls
- Routers are commonly used as firewalls because they already have the ability to filter transport layer ports associated with specific applications as well as specific ranges of IP addresses, and are typically positioned on the edge of a network
- Carefully limited which applications or IP addresses can pass through a router is called a Packet-Level Firewall. They're tedious and simple errors can cause big holes. However, it doesn't take much router processing power
- Application-Level Firewalls perform a stateful inspection of traffic. They watch a particular protocol conversation and make sure it's following normal rules. If something acts suspicious, it'll get caught and stopped. It takes a lot of processing and adds considerable latency.
- Network Address Translation (NAT) hides all internal IP addresses behind a single, publicly visible address. Doing so makes the internal network much less visible, and provides a level of protection.
- Some set up internal and external firewalls to limit where incoming traffic can access at different tiers

### Authentication
- User authentication is the separation from the trusted and untrusted.
- Knowledge: A password is something you know. It's a common way of authenticating a user.
- Possession: An access card is something you have. By showing a card with some kind of readable of information on it
- Being: Biometrics. It's fingerprint scanners, iris and voice scanners, etc. Little difficulty, high reliability.
- Social engineering is an odd term for simply deceiving people to get the information you want. It can be much easier to trick someone into telling you the password than trying to crack it. If we trust someone, we'll give them protected information.

### Encryption
- Encryption makes data unreadable by anyone who is not authorized. 
- 
Overview
- Network is about getting from network to network
- Layer 2 is about getting around within a network, this is network to network



Equipment
- Router (main)
	- Sends signals from network to network
	- Every port on a router connects to a different network
	- Every port has a different IP address on that network
	- That address is called the default gateway, and it's where devices send packets if they're going to different networks.
	- Routers don't care about individual IP addresses, it sends packets to the correct network
	- There are two ways to deal with routing
		- Static Routing: manually tell the router where every other router is in the network
		- Dynamic Routing: let the router build a rotating table on its own by sharing information with other routers so it can learn the configuration of the network.
	- Routing Tables
		- A list of networks and ports.
		- To get to network X go to port Y etc.
		- Gateway of Last resort is a port they'll send out of if nothing else matches or makes sense
	- Routing Protocols (how two or more routers interact)
		- Interior Gateways
			- Distance Vector:  the router periodically sends out the entire network map it has built, but only sends the information to routers directly connected to it.
				- RIP (router information protocol)
			- Link State: whenever there is a change in the state of any link, a router sends information about every direct connection to every router it knows about on the whole network.
				- OSPF (Open Shortest Path First)
			- Hybrid
				- EIGRP (Enhanced Interior Gateway Routing Protocol)
		- Exterior Gateways
			- Span multiple routing systems to span great distances
				- BGP (Border Gateway Protocol)
					- Used across the internet
- Computers
- Layer 3 Switches
	- Uncommon
	- Have some built-in routing capabilities
	- Can't function as a router



Internet Protocol (IP)
- Dominant protocol at the network layer
	- Others like GGP, ICMP, IGMP, IGMP-AC, and IPsec
- How it makes connections
	- It doesn't
	- It's connectionless
	- Each packet is independent of the others
	- Packets aren't grouped
	- Packets are sent to the router and the router worries about it
	- It doesn't check for errors
- IPv4 addresses
	- 32 bits long
	- Separate every byte (eight bits) by a dot
	- Translate each byte into a decimal
	- Each section is called an octet
	- 4,294,967,296 total combinations
	- There are about 1/2 an address for each person in the world
	- Only 50% of the population is online, but most people have multiple addresses
- IPv6
	- 128 bits long
	- We separate every two bytes (16 bits) by a colon
	- Translate each section into hexadecimal
	- Each section is called a hextet
	- For each 2-byte section we get a decimal number from 0-65,536
	- 340,282,366,920,936,463,463,374,607,431,768,211,456 total combinations
	- Enough addresses to cover every atom on the surface of 100 earths 



Packets
- PDU for Layer 3
- Occasionally used as a generic term for PDU when they may mean segment or frame
- Parts 
	- Version Number
		- 4 bits
		- Species IPv4 or IPv6
		- IPv4 is standard
	- Header Length
		- 4 bits
		- A number 5-15 that indicates the number of 32-bit words in the packet
	- Type of Service
		- 8 bits
		- Used for Quality of Service
		- So you can give priority to more important traffic
	- Total Length
		- 16 bits
		- The total length of the packet, including header and data
		- Ranges from 20-65,535 bytes
	- Identifiers
		- 16 bits
		- Also known as the fragment identifier
		- Contains which part this is when an IP packet has been broken up into multiple packets in some protocols
	- Flags
		- 3 bits
		- 1 is always zero. Called the evil bit. Bad guys should mark it if it's malicious
		- 2 DF: Do not fragment (packet is dropped if equipment cannot handle a large packet)
		- 3: MF: More fragments (indicates this is an intermediate fragment)
	- Packet Offset
		- 13 bits
		- Used with Fragment ID in fragmented packets to help put them back together
	- Hop Limit
		- 8 bits
		- Also called the TTL (Time to Live)
		- Number of router hops the packet can go before it's dropped
		- Decrements with each hop and then it dies
	- Protocol
		- 8 bits
		- Indicates the kind of data being carried in the data field
		- 1 = ICMP
		- 6 = TCP
	- CRC
		- 16 bits
		- Cyclic redundancy check
		- Identifies corrupt packets
		- User data is not checked, only the header
	- Source Address
		- 32 bits
		- IP address of the source computer
	- Destination address
		- 32 bits
		- IP address of the destination computer
	- Options
		- Not really used
	- User Data
		- Actual payload of the packet
		- Segment from Layer 4



Classes
- A means very big (first octet 1-127)
- B means medium sized (first octet 128-191)
- C means little baby network (first octet 192-223)
- D (first octet 224-239)
- E (first octet 240-255)



Masks
- Each class is associated with a mask that defines which portion of the address is held in common with every host on the network and which portion of the address is used to identify the host
- The default mask for a class A network is: 255.0.0.0, or 11111111.0.0.0
- The default mask for a class B network is: 255. 255.0.0, or 11111111. 11111111.0.0
- The default mask for a class C network is: 255. 255. 255.0, or 11111111. 11111111. 11111111.0
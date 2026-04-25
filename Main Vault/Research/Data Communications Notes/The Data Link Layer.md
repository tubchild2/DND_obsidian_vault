General Purpose:
- Responsible for controlling access to the media (the wire) by understanding how a network type works.
- Reliable transmission of data frames between two nodes connected by a physical layer
- Information is converted from packets to frames, which are sent across [[The Physical Layer]], and then converted back into frames, which are converted back into packets
	- Packets -> Frames -> Physical Signals -> Frames -> Packets
- Layer 2
- Focuses on the local area network (LAN)
- Capable of some flow control. Receives back to the sender what it needs. With ethernet, we don't do flow control at layer 2.
- It also does some error handling. Also not really with layer 2 with ethernet.


General Purpose Pt. 2:
- Controls access to media (the wire)
- Local addressing (MAC address)
- Flow control
- Error handling
- PDU: The Frame


IEEE Project 802
- A way to standardize the definition of networks to allow for better communication between them
- IEEE 802.3 is Ethernet.
- Ethernet is the most popular LAN type.


Sublayers
- LLC sublayer
	- Talks to the network layer
	- Logical Link Control
	- Where drivers exist
	- Doesn't have to change
- MAC sublayer
	- Talks to [[The Physical Layer]]
	- Media Access Control
	- Changes depending on ethernet, wi-fi, Bluetooth, or other protocols


Protocols for Layer 2
- Ethernet
- WiFi
- ATM
- FrameRelay
- FDDI (Fiber Ring)
- There are more


Hardware
- Switch
	- Connects every device on a LAN
	- More intelligence than a hub (Multiport Repeater) but looks almost identical
	- Keeps track of which computer is at each port and only sends traffic to that port if it's destined for the attached computer
	- Can handle multiple simultaneous conversations without collisions
	- Two types of forwarding frames to devices
		- Store and forward
			- Stores and checks for error
		- Cut through
			- Immediately moves from port A to port B
			- Much faster, but errors might not get caught
		- Fragment Free
			- Stores the frame for just enough time to get the address and then sends it out
			- Faster speeds
			- Reduces the chance of errors, but doesn't eliminate it
	- QOS
		- Ports can be configured so that certain types of information gets a higher priority and moves faster
	- Ways devices can speak
		- Unicast (one to one)
		- Broadcast (one to all)
		- Multicast (one to many)
	- Flooding can be used to check who owns what and to find MAC addresses
	- 
- Bridge
	- Separates devices on a network by their MAC (physical) address
	- Since the LLC sublayer of layer 2 is common among most network types, a bridge can convert from one network type to another.


Controlled Access
- At the MAC layer, layer 2 controls access to [[The Physical Layer]]
- There are multiple types
	- Polling
		- Asks each device if it needs to transmit
		- Doesn't work great with lots of devices
	- Token Ring
		- A token travels from device to device
		- When the token gets to a device, the device can transmit
		- Doesn't require a central device, some versions with a central device exist
	- Contention
		- Sometimes called random access 
		- Ethernet allows hosts to transmit on a shared medium after listening for a clear wire first
		- An algorithm exists to handle collisions when they occur
		- Collisions were detected and would cause one to wait for less time than the other collider
- CSMA/CD
	- Each computer on an Ethernet LAN network waits until there's a clearing and then just goes
	- Carriers sense if there's traffic, and detect collisions
	- If a collision happens, all computers are jammed and wait a random amount of time and try again
	- In CSMA/CA, the host polls the access point to request time to send data. It's not contention


History of Ethernet
- Invented by Robert Metcalf and David Boggs in the 70s at Xerox
	- Metcalf gets most of the credit for it
- Originally ran on RG-8 Coax
	- Used random access / contention at first
	- Ran at 10 Mbps 
	- Was as big around as your thumb
	- Wasn't very flexible
	- Impedance of 50 Ohms
	- Was hard to work with and expensive
	- $1-5 per foot
	- Connectors were $5 each
	- Not much privacy
- Thinnet
	- IEEE 10base2
	- Thinner, more flexible, and lower quality RG-58 Coax
	- 15 cents per foot
	- Connectors were under $2
	- More repeaters were required
- Versions of Ethernet
	- Ethernet / Thinnet
		- 10 Mbps
		- 10baseT
		- Cat3+ Required
	- Fast Ethernet
		- 100 Mbps
		- 100baseT (when over twisted pair)
		- Cat5+ required
	- Gigabit Ethernet
		- 1000 Mbps (1Gbps)
		- Cat5e+ required
		- Designated 1000BaseT or 1GBaseT when over twisted pair
		- Ideal for workstations
	- 5GBaseT
		- 5000 Mbps (5Gbps)
		- Cat6+ required
	- 10GBaseT
		- 10 Gbps
		- Cat6a+ required
		- Ideal for server rooms over fiber optic cables
	- 40GBaseT
		- 40 Gbps
		- Cat8+ required
	- 100 Gigabit Ethernet
		- 100 Gbps
		- Pretty much requires fiber optic cables
		- Very very very good in server rooms


Broadcast Domain
- All of the devices that will hear a broadcast from a host
- Separated by Routers
Collision Domain
- Separated by bridges and routers
- Where collisions could happen if 2+ computers broadcasted at the same time


Frames
- PDU for Layer 2
- Applies only to LAN
- Format of a Frame
	- Preamble (8)
		- Alternating 1s and 0s for a bunch of time
	- Destination Address (6)
		- MAC Address
	- Source Address (6)
		- MAC Address (6 byte hexadecimal)
	- Type (2)
	- Data (46-1500)
	- FCS (4)
		- Frame Check Sequence
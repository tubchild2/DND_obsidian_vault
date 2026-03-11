
Overview
- The telephone system
- WANs: get computers across the world
- MANs: get us across towns

History
- Alexander Bell developed the telephone system
- 3 Hz to 3.4 KHz (human voice) could be carried through the phone receiver
- Electrical signals were carried through a switchboard and converted back at the receiver
- Trunk lines were run from one phone office to another to create a backbone
- Quality was bad over distance, and they have to give a dedicated line for each phone call
- The solution was digital signals between phone stations. Repeated signals to improve quality.
- The solution to dedicated lines was packet switching

Internetworking
- To connect two buildings, you can
	- Dig trenches to run wiring
	- Lease space on telephone and power poles to run wiring
	- Install microwave dishes or laser transceivers
	- Build and launch satellites in geosynchronous orbits within range of our city and make the connection via satellite
	- Lease dedicated digital circuits from the local phone company, connect to a private MAN or WAN that can carry the data, or just use the internet over VPNs
- POP means point of presence
- Error rates increase over distance. MANs and WANs especially have to account for this problem.

History
- POTS
	- In the very early days of computing, when computers filled entire rooms, engineers built a modem to convert the digital output of a computer to an analog signal on a phone line.
	- Plain Old Telephone Service
- ISDN
	- Integrated Services Digital Network
	- Provided switched digital signals that paralleled the data rates of dedicated T Carrier services.
	- BRI was a basic rate interface, which provided 2 64Kbps circuits that could be bonded together.
- PRI
	- Primary Rate Interface
	- Equivalent of a T-1 line, providing 24 channels for the equivalent of 12 BRI circuits
	- Every LEC implemented ISDN in a different, largely incompatible manner, and priced them at unaffordable rates.

Dedicated Circuit, Circuit Switched, and Clouds
- Circuit networks don't have a monopoly on the Cloud concept; most WAN network types provide some kind of cloud to connect to.
- Switching was how lines switched from target to target, basically.
- Packet switching solved the problem of conversations needing a dedicated line.
- Eventually, this was automated by the dialer.
- Phone freaking (?)
- Datagram packet switching 
	- Allows packets to take different paths
	- Used by the internet
- Virtual circuit packet switching
	- Switching maintains the same path for all packets
	- Early WAN tech used this method
	- SVC (Switched Virtual Circuit)
	- PVC (Permanent Virtual Circuits)

Dedicated Services
- Dedicated Services are T carrier and OC lines, mostly leased from telephone companies
- DSL services can be configured between two nearby points
- You order from your LEC, and are charged a flat fee by mile and by maximum potential data rate

Dedicated Circuit Networks
- DS0 is designed to carry a single telephone call in digital form. 
- DS1 is a multiplexed signals that can carry 24 DS0 signals using Synchronous Time Division Multiplexing
- CSU/DSU on a digital circuit (like a T1 Line) is comparable to a modem on an analog line. It converts from one network type to another.

Dedicated Circuit Switches
- Two kinds of point to point services; T-Carrier and SONET
- T-Carrier services are typically delivered to the individual businesses while SONET is an all fiber network that multiplexes many T-Carrier signals together
- Packet switched networks were developed in response to the high cost of dedicated circuits
- First major packet switched MAN and WAN: the private X.25 network
- T (Or E in Europe) lines went across towns or to the telephone company where they could switch to other

Frame Relay Networks
- Errors were assumed to be so infrequent that they didn't need error detection or correction
- Both of these use variable length PDUs to accommodate small or large blocks of data.
- Still in use, but is being phased out in favor of IP based services
- ATM was another private packet switched network for isochronous traffic like voice and video.

### MODERN MANs AND WANs
- IP based services that use IP are phasing out older MAN and WAN network types
- Multiprotocol Label Switching (MPLS) and Metro Ethernet have both been developed as MAN technologies and are expanding into the WAN.
- Metro Ethernet
	- Another switch point from your LAN.
	- Frames are unchanged, and your router will just see it as another broadcast domain
	- The biggest challenge is that there are higher latencies on Metro Ethernet MANs than with LANs, and hte longer the latency, the greater the challenge.
	- Most popular MAN technology and is growing in popularity in the WAN
- MPLS
	- A flexible technology
	- It takes any kind of frames or packets delivered to it, encapsulates them with its own labels, and then quickly delivers the traffic through its network with minimal overhead.
	- Operates at [[the Data Link Layer]], but is used for MANs and WANs
	- All kinds of traffic can be carried through MPLS; Ethernet, Frame Relay, ATM, etc.

### Datagram Approach vs. Virtual Circuits in packet switched networks
- The datagram approach is like the mail. Each packet is addressed and sent out independently. There's no guarantee that the packet will be delivered, much less delivered in some special order.
- The virtual circuit approach is like a telephone call. First you establish the circuit, then send the data. It assures that all frames will be received in the order sent, and that the sender and receiver will remain static during the course of the transmission.
	- There's Permanent Virtual Circuits (PVCs) and Switched Virtual Circuits (SVCs)
	- Virtual circuits are used in X.25, frame relay, ATM, MPLS, and Metro Ethernet
	- The Datagram approach is used in the Internet

### PVCs and SVCs
No Notes


### VPNs
- VPNs secure data by tunneling it
- Data is sent in a different form
- Whenever information is sent across the internet, there is risk
- If your company values the data and their network, they'll use VPNs judiciously
- VPNs are provided through a gateway
- They take considerable processing.
- Most LECs will lease you a DSL point to point connection. Digital Subscriber Line includes a whole family of point to point circuit technologies
- 
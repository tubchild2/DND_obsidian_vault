
Overview
- It's growing dramatically in businesses
- Many are using it as the primary method of providing network services
- Wireless LANs, WPANs, and WMANs are covered in this chapter
- IEEE 802
	- Keeps an eye on different LAN technologies' standards
	- 802.11 oversees wireless LANs
	- 802.3 oversees Ethernet
	- Standards
		- Standards aren't free, they're several hundreds of dollars
- Wi-Fi is synonymous with wireless networking 
- Wi-Fi alliance
	- Non-profit organization that promotes the usage of wi-fi
	- Certifies equipment by allowing their logo to exist on it

Definition
- There are a ton of other wireless systems besides Wi-Fi
	- Wi-Fi
		- Wireless LAN
	- WPAN
		- 802.15
		- Network in close proximity to an individual or other device
		- Cell phones, wireless speakers, etc.
	- Bluetooth
		- 802.15.1
		- A type of WPAN
	- BAN
		- 802.15.16
		- Body Area Network
		- Medical implanted devices
	- MAN
		- Metropolitan Area Network
		- Used to have some in Seattle and Portland, but they didn't make it
		- It's too expensive, and there are too many problems
- Wireless Ethernet Data Frame Format
	- Frame Control - 2 bytes
	- Duration ID - 2 bytes
	- Address 1 (destination) - 6 bytes
	- Address 2 (source) - 6 bytes
	- Address 3 (router) - 6 bytes
	- Sequence Control - 2 bytes
	- Address 4 (AP) - 6 bytes
	- Network Layer Data - 0-2312 bytes
	- Frame Check Sequence - 4 bytes
- Standards Letters
	- (legacy), A, B, G, N, AC, AX, etc.
	- They represent minor standards
	- Small changes to the standards

Channels
- Wireless networks break their total spectrum into separate overlapping channels, and each channel is dedicated to a single Access Point
- You can improve your throughput by scanning your wireless environment and setting your access point to use a channel that won't conflict with nearby Access Points
- CSMA/CA
	- Similar to Ethernet collision detection, except it avoids instead of detects
	- It's often impossible to tell if there's a collision, because signals can be in the microwatt range
	- First, lots of movements in teh file transfer process when timers are set and both ends wait to see if the data gets through, as when using the DCF. In some circumstances, another set of frames must be sent and acknowledged before frames of data can be sent. This method is called the Point Coordination Function, and it's helpful when an AP is covering a wide area.
![[Pasted image 20260223101105.png]]

- ACK/NAK
	- Acknowledge / Negative Acknowledge frames are sent whenever a frame is received, or if a timer expires between frames, when it's not received
- RTS/CTS
	- Request to send / clear to send is a communication protocol that attempts to confirm that both the laptop and the Access Point are ready to send data.
	- These extra frames are sent between data frames, as displayed in the flow chart
	- Not all Access Points implement this protocol, but it's useful to address the "hidden node" problem

Wireless Networking Challenges
- There are a bunch of issues when trying to implement a wireless network
	- Spectrum limitations
		- The FCC allocates portions of the electromagnetic spectrum for different uses
		- Instead of trying to get the FCC to allocate more spectrum, they looked for a way for multiple radios to be transmitting at the same time over the same portion of the spectrum in a way that the receiver could differentiate between them.
		- The ISM band goes in 2.4 GHz, and the UNII band transmits in the 5 GHz range.
		- By using a general use frequency, they didn't have to fight to take away spectrum that had already been allocated for some other purpose
	- Data rate
	- Signaling methods
	- Noise
	- Safety
	- Security
- They can transmit on the same portion of the spectrum with spread spectrum technologies
- These technologies include
	- FHSS
		- Frequency hopping spread spectrum
		- Sending frames on multiple frequencies
		- Hopping between em rapidly
	- DSSS
		- Direct Sequence Spread Spectrum
		- Each bit is encoded into 8 or 11 bits
		- Each one is sent on multiple frequencies and reconstructed
	- OFDM
		- Orthogonal Frequency Division Multiplexing
		- If that's not a mouthful, I don't know what is
		- The Frequencies are calculated to overlap in a way so as not to interfere with each other


Wireless Data Rate
- Collisions are infrequent, but the effort to avoid collisions consumes at least half of the total available throughput.
- An 802.11b wireless network that advertises a data rate of 11 Mbps will have an actual throughput of about 5.5 Mbps.
- Noise
	- Wireless networks are especially sensitive to electromagnetic noise.
	- Many devices operate in the unlicensed portion of the spectrum (2.4gHz) and may interfere
	- Microwaves, baby monitors, and wireless security cameras all use the same frequency
- Safety
	- Wireless access points emit 2 tenths of a watt, while a Microwave outputs up to 1000 watts
	- Very powerful service antennas can reach 100,000 watts (KINK FM Radio in Portland does)
- Wi-Fi Standards and their Data Rates
	- 802.11: 2Mbps
	- 802.11b: 11Mbps
	- 802.11a: 54Mbps
	- 802.11g: 54Mbps
	- 802.11.n: 600Mbps
	- 802.11ac: 1466Mbps
	- 802.11ax: 10530Mbps
	- These are typically half as fast, because 50% is used for validation and for preventing collisions
	- Wi-Fi is half-duplex: one direction at a time

Ad Hoc and Infrastructure
- Ad Hoc network
	- An Ad Hoc network is one where communication happens directly from one computer to another, without any central device to facilitate the communication
	- We usually set these up as two laptop networks for quick file transfers, but the 802.11 standard supports including more computers in an ad hoc network.
- Infrastructure network
	- All wireless computers communicate through a central device called an access point.
	- Access Points are the most commonly used bridge in networking today.
	- The bridge is combined with a router to provide access to the internet.
- BSS ESS
	- BSS is a basic service set which includes an access point
	- ESS is an extended service set which includes multiple BSSs connected to one network
- MIMO
	- Multiple In, Multiple Out
	- MIMO is a problem for 802.11 a, b, and g, but it's used as an advantage with 802.11n.
	- 802.11n gets such high data rates by taking advantage of reflected signals in order to figure out what's missing. 
	- It uses multiple antennas and comparing the strength of the signals on each antenna
	- Pronounced MEME-OH or MIME-OH, most say MIME-OH

Wireless LAN Security
- Antennas
	- Omnidirectional Dipole Antenna
		- Transmit in all directions
		- Weak signals above and below
		- Lower range
		- Useful for things that move
	- Directional Antennas
		- Satellites
		- Microwave horn antennas used by long-distance telephone companies
		- Directional Panel Antennas
		- Send the signal in one direction
		- The signal energy is much stronger

Why is Wireless so Popular?

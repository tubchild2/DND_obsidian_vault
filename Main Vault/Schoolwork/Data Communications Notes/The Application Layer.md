---
aliases:
---
**Overview**
- The application layer provides users and programs with network access
- Don't think of an application
- The application layer is the protocols available to applications that they can use to do networking


**Client / Server**
- Client:
	- A processor asking for a service. Could be asking for data or for processing to occur
	- Client is typically a user computer / PC
- Server:
	- A processor providing a service. Again, it could be data or processing.
	- Server is typically a high end computer in a server room
	- Server can be a pc
- It's common for devices to switch between the role of client and server rapidly
**History**
- In the early days, there was one mainframe computer with connected terminals
- Then, there were diskless work stations from Sun Systems and others. They had processing power but no storage.
- Then, there were microcomputers. They were full-fledged computers. They were both client and server at once.


**Middleware**
- Used when software on one computer is incompatible with data needed on another computer
- A server running middleware is installed between the client and the database server
- The separator between client and server
- Does the work of running protocols to move data from one machine to another

**P2P File Transfer**
- You get files directly from other computers on the internet
- Functions based off a centralized directory that you can use to access them
- The PCs use inform & update to keep it up
- You can query for content, and then it'll file transfer it directly

**The World Wide Web**
- Internet born around 1969
- About 1989 that the web came about
- Used a browser called the WorldWideWeb
- Erwise was the first browser with GUI
- NCSA Mosaic was the first browser that came out
- The hyperlink is the defining characteristic of the web
- The web is not the internet
	- The web is one service on the internet
	- Other channels carry email, telnet, etc.

**Protocols and Services**
- protocols:
	- Set of rules used by networking services
- services:
	- Programs that run on the clients and servers

**Email**
- Started small and was instrumental to the eruption of the internet
- In 1992, MIME allows for more pictures and stuff. It allows for longer docs, formatting, characters other than ASCII, and attachments. It would add a bunch of random characters that it could convert.
- Text only medium between 1989-1992
- Parts
	- MUI lets you compose and read
	- MTA are servers which move mail towards its destination
	- MDA is the server that hold the mail until the user is ready to read it
- Protocols
	- SMTP is used by MUA to send mail to the first MTA. Also used for MTA->MTA
	- POP3 is used by MDA to store mail until the receiver is ready to use it. 
	- IMAP is an alternative version of POP3

**HTTP / HTML**
- HTTP is the protocol used to exchange documents between servers and browsers
	- Protocol by which you move web pages
- HTML is the markup language used to format a document that is commonly exchanged on the internet
	- Coding language used to make web pages
	- CSS and JS are also used

**URL / DNS**
- Should actually be URI for Uniform Resource Identifier, but who cares
- URL contains the name of the page and the information of the DNS server it's on
- DNS is a Domain Name System, which basically manes that there are DNS servers that keep track of server names and their IP addresses. You typically move through DNS servers until you find the one you're looking for. 
- How DNS works
	- A distributed directory of IP addresses
	- If a pc wants to get to one place, it goes to it's DNS server, and asks for the IP address
	- Then, the DNS server doesn't know so it passes it off to the root DNS server. 
	- The Root DNS server then sends the DNS server another DNS server to check.
	- That server gets checked, rinse and repeat until you get the right DNS server with the right IP address and then it's returned
	- The PC then loads the web page on that IP address

**FTP**
- File Transfer Protocol
- Used to transfer files over the internet
- Developed prior to the web
- More secure versions now exist: (SFTP and FTPS)
- One of the first thing we wanted to do was transfer files from university to university
- Port 21 and a Port 21
	- Port 21 is used as a command channel
	- Port 20 (or a random port) is used as a data channel to send the data over
- It is assumed that the file server is always available
- Doesn't typically use a browser; uses FileZille, Fugu, etc.
- Lets you view the index of a site

**TELNET**
- Method of interacting with a remote computer or networking device
- Commonly used with networking devices like switches and routers to configure them or to inquire about their status
- By far one of the earliest 
- Used by terminals to talk to mainframes
- Way of connecting from a terminal to another computer via command line
- Used to administer a computer or router
- PuTTY is the most common Telnet client today
- Can be used to control other devices, but the passwords and information went across the network in plain-text, so it wasn't very secure

**SSH**
- Used as a more secure replacement for Telnet
- Data is encrypted much more
- PuTTY is a common SSH client
- Uses public-key encryption, but basically a secret key is used to encrypt and decrypt passwords and commands and is never sent across the network.
- Both the sender and the recipient have their own private copy of the key that is never sent

**SSL**
- Used to secure other methods of exchanging information, like email.
- Can be used to secure HTTP
- Secure Sockets Layer
- Generally secures layer 7 protocols 
- HTTPS and FTPS use SSL
- Now we use something called TLS, but we still call it SSL
- TLS is a better SSL
- You have to use a unique port number for SSL

**IM**
- Instant messaging
- Fairly new in terms of internet history
- Needs someone on both ends to send and receive
- You need to be there or it won't work
- Full duplex
- IRC is an early version. Not really used anymore.
- Primarily used on phones, not on computers
- Isochronous (timing sensitive)

**Text Messaging**
- Often confused with IM
- TM originated with cell to cell communication
- It doesn't take up any data link bandwidth
- Cell phones reserve a tiny portion of the electromagnetic spectrum (band) to carry control information like telephone numbers, keepalive, call set up, and call disconnect messages. 
- Most of the connection between a cell phone and a cell tower is dedicated to voice information
- Within the infrequently used part of the band, text messages are transferred. 
- Handles up to 140 bytes of information. Costs them nothing, but users are willing to pay a considerable amount for the service
- From the perspective of a user, IM and TM are identical since both can now originate on computers and phones.
- You don't need to be there to receive it, it's saved like with email.
- Much more reliable and full duplex, unlike email
- SMPP is the protocol actually used by text messaging

**Videoconferencing**
- Client server model similar to IM
- Isochronous (timing sensitive)
- Chooses from a large number of protocols
- Can be circuit switched or packet switched
- Reliable when circuit switched
- Over the internet (packet switched) it can be unreliable and there's no QoS

**VoIP**
- Voice over IP
- Converting analog voice information into a digital stream
- Sending it across a TCP/IP network to a destination server
- Decoding it back into an audio stream again
- Has a tremendous future
- Many companies are converting all of their internal voice traffic to VoIP to eliminate the separate voice network most companies use.
- Similar to video conferencing, but it's just audio. 
- VoIP has a lot of protocols
- Needs fast internet
- May be limited to your network or may act over the internet
- VOIP may be limited to other VOIP phones
- May be allowed to transfer to other carries

**Cloud Computing**
- The idea of outsourcing server functions to another company

**IEEE**
- They develop new standards.
- They invite engineers to comment on specifications. 
- These have come to be called an RFC, or a request for comment

**Wireshark**
- Used to capture internet traffic
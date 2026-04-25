Prerequisites
- Hey at least I have a basic understanding of networking!
- It says you should have 9-12 months of IT experience dawg

TestOut Linux Pro Certification
- System Administration and Configuration
- Storage and File System Management
- Networking and Printing
- Security and Access Control

CompTIA Linux+ Certification
- Hardware and System Configuration
- Systems Operation and Maintenance
- Security
- Linux Troubleshooting and Diagnostics
- Automation and Scripting

TestOut Lab Simulator
- You can click start over if you make a mistake
- If you click score lab, you can see if you completed your tasks or not
- If you were unable to complete one or more tasks, you can study the notes and then take it again
- They didn't mention any retake limit, so given time, it's impossible to fail.


### **Linux Introduction**
Key Words
- Linux Kernel: the actual operating system
- GUIL: a graphical user interface that the user interacts with
- Distribution: a unique compilation of the Linux kernel (free and open to all) with utilities, desktop environments, applications, and more.

OS Introduction
- Barely noticed when it first came out; now it's seen worldwide.
- There are tons of Linux apps and they're mostly free.
- Linux components
	- Kernel: OS core
	- Libraries: collections of prewritten elements so they can use stuff without writing their own functions. Like in C.
	- GUI: Looks a great deal like other OS
	- CMD: Focus of the course. Most core functions are performed here.
- First basic release had the Linux kernel, three basic utilities: BASH shell, update utility, and a compiler. 
- In 1991 Linus Torvald posted the source code online for free. That one move changed the way OS are developed. Other programmers were welcome to create their own versions. 
- Linux V1 in 1994. The open-source design was intended to value quality code. 
- 2022 Linux has over 300 versions. 
- The Kernel is freely available to anyone. You can even create your own version or distribution. 
- The GNU (GNU's not Unix) foundation. 
- Ubuntu, Fedora, Redhat, Oracle, Debien, ScentOS. Depends on your needs.


### Linux Implementations
- Linux is developed on the GNU public license. Eyes from all over can analyze and improve it. 
- Linux is a very stable operating system. Hundreds of Distros work for desktop. Linux outperforms most other OS. It's much much cheaper, and doesn't require incredible hardware. 
- Linux as a desktop OS
- Two divisions of desktop OS
	- Red Hat Variant
		- Fedora
		- Rocky
	- Debian Variant
		- Ubuntu
		- Kali
		- Mint
	- Others
		- SUSE
		- Arch
	- Software
		- LibreOffice
		- OpenOffice
		- VLC
		- Gimp
		- Chrome
		- Firefox
		- LightWorks
		- Apache
- Used as a hobbyist OS with little standardization. 
- Configuration is more of a manual task, but it's better in the long run
- Linux as a server OS
	- Used %45 of the time.
	- Includes different software
		- DHCP
		- DNS
		- Web Server
			- Apache
		- Database
			- MySQL
			- PostgreSQL
- It's a Modular OS and can be configured for what you need
- Can run on mobile devices with Android
	- Android is cheaper since Linux is free
	- Has better performance and efficiency
	- Tremendous app support
	- Apps cost less
	- A lot of power
- PC uses less than %10 of its available resources usually.
- Virtualization is the basis of cloud computing.
- Provides greater use for resources already owned. 
- Linux Virtualization
	- Install multiple OS with their own apps and data using a hypervisor
	- Hypervisor is a middleman between the computer and the OS's
		- Xen
		- KVM 
		- VirtualBox
		- VMware
	- Makes cloud computing much more possible.
- IaaS
	- Infrastructure as a service
- SaaS
	- Software as a service
	- The software is provided via a web browser as a service
- NaaS
	- Network as a service
	- Network connectivity through the cloud
- STaasS
	- Storage as a service
- DaaS
	- Desktop as a service
- PaaS
	- Combines multiple services



###  Linux Overview
- It provides the following key functions
	- Application Platform
	- Hardware Interface
	- Data Storage
	- Security
	- Network Connectivity
- Linux Key Components
	- Linux Kernel (the OS)
	- Libraries
		- Pre-written code elements that programmers can use
	- Utilities
		- Complete operating system management tasks
		- Creating and maintaining file systems
		- Editing text files
		- Managing the applications running on the system
		- Installing new applications on the system
	- UI
		- GUI
		- CMD
- Distributions
	- Mobile devices
		- Android
		- Cheaper
		- Better performance
		- Application support
	- Virtualization
	- Cloud computing
	- Embedded Linux
		- Used in automation devices



### Server Roles Facts
- Linux can fulfill many server roles
- NTP
	- Network Time Protocol
	- Used to synchronize time on your Linux system with a centralized NTP server
- SSH
	- Secure Shell or Secure Socket Shell
	- Used to securely log onto remote systems using encryption
	- Most common way to access a remote Linux system
	- Open SSH is an open source implementation
- Web Server
	- Program responsible for accepting HTTP requests from web browsers or clients and in turn sending the HTML documents and linked objects, such as images or JS.
		- Apache Server
		- Nginx
		- Lighttpd
		- Apache Tomcat
		- Monkey HTTP Daemon
- Certificate Authority
	- Digital certificate is used as proof of identity
- Name Server
	- Resolves or maps the fully qualified domain names (FQDNs) to their respective IP addresses and IP addresses to their respective FQDNs. 
	- Reminds me of DNS, but I think DNS is used for routing and finding name servers.
- DHCP
	- Dynamic Host Configuration Protocol (DHCP)
	- centralizes IP address assignment management byu allowing a server to dynamically assign IP addresses to clients.
	- Allows users that move from network to network to get IP addresses appropriate for the subnet they're connected to. 
	- To install, you need to set up the software
		- **$ sudo apt install isc-dhcp-server**
- SNMP
	- Simple Network Management Protocol
	- Designed for managing complex networks
	- Used to communicate and monitor network devices, servers, and more by means of the IP protocol
	- To install
		- **yum -y install net-snmp net-snmp-utils**
- File servers
	- Machine set up and configured to let other machines store and retrieve files on it from a central location
- Authentication Server
- Proxy
	- Provides indirect internet access to the computers in your network
	- Installed on the same computer as the firewall (usually). 
	- Increase performance and security by blocking direct access between two networks.
- Logging
	- Captures timeline of events that have taken place on the computer in the form of a file, which is referred to as a log file.
- Containers
	- Give you the ability to run an application in an isolated environment known as an image or container
	- Due to this isolation, multiple containers can be run on the same host without affecting each other or the main operating system.
	- Highly portable.
- VPN
	- Uses encryption to allow IP traffic to travel securely over the TCP/IP network
- Monitoring
	- Refers to the process of monitoring the essential Linux services, including the operating system metrics, process state, logs, service state, and file system usage. 
- Database
- Print Server
	- Used when a company wants their printer available to multiple users over a network
- Mail Server
	- Computer that sends, receives, and stores email for users.
- Load Balancer
	- When a company has back-end servers that receive a significant amount of traffic, response time to these servers can be increased through load balancers by distributing the workload
- Clustering
	- Two or more servers are grouped together in a way to make them work like one

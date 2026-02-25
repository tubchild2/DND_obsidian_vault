Overview
- IPv4 ran out of space
- NAT is used to isolate internal IP address ranges from external IP addresses, thus making available a vast number of private IP addresses
- Subnetting is the process of breaking addresses into manageable smaller blocks

Helpful Tool
	https://jodies.de/ipcalc

Broadcast Domains 
- LANs use broadcasting as a way to communicate with its members
- Anyone on a LAN can send out a broadcast packet that is delivered to everyone in the LAN
- These are used to mostly announce services, like that printers are ready to print.
- A broadcast's domain is the portion of the network in which broadcast packets can travel
- Broadcasts are transmitted by switches, but not over routers.

Private IP Addresses
- A mask is the first part, and is made up of contiguous 1s inside of 1-3 of the first octets
- The masked part of the address is shared by every computer on the network
- Broadcast messages are the opposite, they put all 1s in the unmasked part of the address, and unmask the masked part
- The lowest and highest addresses in the mask's range are used to identify the network ID (lowest) and the broadcast address (highest). The rest are valid host addresses within the subnet.
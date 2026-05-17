# ~Part 1~
### Linux Boot Process
|Term|Definition|
|---|---|
|Basic Input/Output System  <br>(BIOS)|A basic program that starts up a computer system. BIOS is a legacy system that's been replaced by UEFI.|
|Unified Extensible Firmware Interface  <br>(UEFI)|A basic program that starts up a computer system. UEFI has replaced BIOS.|
|Boot|The act of starting up a computer (also referred to as powering the computer on).|
|Firmware|Software that's embedded in hardware, usually on a read-only memory (ROM) chip.|
|Boot manager/  <br>bootloader|A software program that controls the process of loading the operating system.|
|Complementary metal-oxide semiconductor  <br>(CMOS)|A technology for constructing integrated circuits. It refers to the system configuration that's stored in a battery-powered memory chip on computers.|
|Power-On Self Test  <br>(POST)|A software process that verifies that computer hardware works properly.|
|Globally Unique Identifier  <br>(GUID)|A label that software programs use to identify the location of a data object.|
|Master Boot Record  <br>(MBR)|A legacy system that refers to the boot sector on a hard disk or other storage device. The boot sector contains the files required to start a computer.|
|Extensible Firmware Interface System Partition  <br>(ESP)|The partitioning scheme used by UEFI. ESP is the format used for the boot sector where the operating system and utilities for starting a computer are stored.|
|init|init is the first process that's started when booting a Linux system. init is a daemon process that continues running until the system is shut down. It's the direct or indirect ancestor of all other processes and automatically adopts all orphaned processes. init is a legacy process that's been replaced by systemd.|
|initramfs|initramfs is used as the first root file system that your machine has access to. It's used for mounting the real rootfs, which has all of your data.|
|Root  <br>partition|The partition at the top of the directory tree, which contains all of the programs and files necessary for running Linux. This is the root file system that's represented by a forward slash (/).|

The Generic Boot Process
- Hardware Boot Phase
	- When you power on the system, it checks if the hardware is working
	- POST phase
- UEFI is more secure and is used for config
- Control is then given to the boot device (bootloader)
	- Loads code into RAM
	- Creates a temporary virtual file system called a RAM Disk
		- Called initrd or initramfs
	- Loads a basic OS to get things started
	- Control of the hardware is passed to the kernel
- Kernel Phase
	- Loads Daemons and othe rprograms
	- Dismounts and destroys the RAM disk
	- Initializes the system by loading systemd


UEFI
- The interface between hardware/firmware and the OS
- It provides support for larger disks using the _Globally Unique Identifier Partition Table_ (GPT) partition scheme. The MBR partitioning scheme used by BIOS supported only four partitions per disk, with a maximum size of 2 TB per partition. UEFI supports a maximum partition size of 9.4 ZB (9.4 x 10 21 bytes).
- Has its own boot manager. 

##### UEFI BOOT

|Phase|Process|
|---|---|
|UEFI|The following steps take place during the UEFI boot process:<br><br>1. Power is supplied to the processor. The processor is hard-coded to look at a special memory address for code to execute.<br>2. This memory address contains a pointer or jump program that instructs the processor where to find the UEFI program. (The mount point for the EFI system partition is usually /boot/efi, where its content is accessible after Linux is booted.)<br>3. The processor loads the UEFI program.<br>4. UEFI runs the power-on self-test (POST). If the POST is successful, UEFI identifies other system devices. It uses the CMOS system clock and information supplied by the devices themselves to identify and configure hardware devices. Plug and Play devices are allocated system resources. The system typically displays information about the keyboard, mouse, and IDE drives in the system. Following this summary, information about devices and system resources is displayed.<br>5. UEFI reads the GUID partition table, which is located in the blocks immediately after block 0. The GUID partition table defines the layout of the partition table on the storage device.<br>6. Using this information, the UEFI boot loader locates the ESP which contains the boot loader files or kernel images for all operating systems that are installed on other partitions on the device. ESP also contains device driver files for hardware devices on the computer that are used by the firmware at boot, system utility programs to be run before the operating system is booted, and data files, including error logs.<br>    <br>    To boot Linux, you would use a UEFI-aware version of the GRUB bootloader and install its boot file (grub.efi) in the EFI system partition.|
|Boot loader|During the boot loader stage, UEFI gives control to the boot loader program. The following steps take place:<br><br>1. UEFI loads the boot loader code.<br>2. When the boot loader is in RAM and executing, a splash screen is commonly displayed, and an optional initial RAM disk (e.g., initrd or initramfs image) is loaded into memory. The initramfs image is used with new distributions. Initramfs:<br>    - Is a custom version of the init program, containing all the drivers and tools needed at boot.<br>    - Is created by mkinitrd. Mkinitrd uses dracut to reduce boot times by using special tools and enabling udev to create device nodes for system hardware.<br>    - Has root permissions that can be used to access the actual /root file system regardless of whether it exists on the local computer or an external device. Without the permissions, the computer could not access the file systems and read information that exists only on those file systems.<br>    - Is used to mount the file system and load the kernel into RAM.<br>3. With the images ready, the boot loader invokes the kernel image.|
|OS Kernel|During this stage, the Linux kernel takes over. The kernel:<br><br>1. Resides in the /EFI directory.<br>2. Initializes the hardware on the system.<br>3. Locates and loads the initrd script to access the linuxrc program, which configures the operating system.<br>4. Dismounts and erases the RAM disk image. On older distributions, this is the initrd image. On newer distributions, this is the initramfs image.<br>5. Looks for new hardware and loads the drivers.<br>6. Mounts the root partition.<br>7. Loads and executes either the init (Initial) process (for older distributions) or the systemd process (for newer distributions). These processes then launch all other processes (either directly or indirectly) to finish booting the system.<br><br>The init (Initial) or systemd processes are always assigned a process ID of 1 because they are always the first processes to run on the system.|
##### BIOS BOOT
| Phase       | Process                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| ----------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| BIOS        | In the BIOS stage, BIOS is loaded, and the system hardware is identified. The following steps take place:<br><br>1. Power is supplied to the processor. The processor is hard-coded to look at a special memory address for code to execute.<br>2. This memory address contains a pointer or jump program that instructs the processor where to find the BIOS program.<br>3. The processor loads the BIOS program. The first BIOS process to run is the power-on self-test (POST).<br>4. If the POST is successful, the BIOS identifies other system devices. It uses CMOS settings and information supplied by the devices themselves to identify and configure hardware devices. Plug and Play devices are allocated system resources. The system typically displays information about the keyboard, mouse, and IDE drives in the system. Following this summary, information about devices and system resources is displayed.<br>5. The BIOS then searches for a boot sector, using the boot order specified in the CMOS.                                                                                                                                                                                                                                                     |
| Boot loader | During the boot loader stage, BIOS gives control to the boot loader program. The following steps take place:<br><br>1. BIOS searches the boot sector, which contains a Master Boot Record (MBR).<br>2. BIOS loads the primary bootloader code from the MBR.<br>3. The primary bootloader does one of the following:<br>    - It examines the partition table marked as bootable, and then loads the boot sector from that partition. This boot sector contains a secondary boot loader, which locates an OS kernel.<br>    - It locates an OS kernel directly without using a secondary boot loader.<br>4. When the secondary boot loader is in RAM and executing, a splash screen is commonly displayed, and an optional initial RAM disk (e.g., initrd image) is loaded into memory. The initrd image:<br>    - Has root permissions that can be used to access the actual /root file system regardless of whether it exists on the local computer or an external device. Without the permissions, the computer could not access the file systems and read information that only exists on those file systems.<br>    - Is used to mount the actual file system and load the kernel into RAM.<br>5. With the images ready, the secondary boot loader invokes the kernel image. |
| OS Kernel   | During this stage, the Linux kernel takes over. The kernel:<br><br>1. Resides in the /boot directory.<br>2. Initializes the hardware on the system.<br>3. Locates and loads the initrd script to access the linuxrc program, which configures the operating system.<br>4. Dismounts and erases the RAM disk image. On older distributions, this is the initrd image. On newer distributions, this is the initramfs image.<br>5. Looks for new hardware and loads the drivers.<br>6. Mounts the root partition.<br>7. Loads and executes either the init (Initial) process (for older distributions) or the systemd process (for newer distributions). These processes then launch all other processes (either directly or indirectly) to finish booting the system.<br><br>The init (Initial) or systemd processes are always assigned a process ID of 1 because they are always the first processes to run on the system.                                                                                                                                                                                                                                                                                                                                                       |
##### Other Ways to Boot
PXE
- Preboot eXecution Environment
- process whereby a computer initially boots from firmware installed on the computer's network card
- When the client computer boots, it sends out an initial request for a PXE server
- If a server that hears this request uses PXE, it sends the client a list of boot servers that contain bootloaders available.
- Using this method, a computer can download and run Linux without the need to install the operating system to its local hard drive. 
- Used on thin clients where no hard drive exists

NFS
- Allows the storage and retrieval of data over a network. 
- You can use the NFS file system to boot Linux on a client in a diskless/thin client environment
- You can also boot Linux from the NFS file system to reduce administrative overhead
- Booting from an NFS server requires a PXE environment.
- To boot Linux using NFS, you must specify the following for configuration:
	- NFS client support as built-in.
	- The server and the name of the directory to mount as root (e.g., root=/dev/nfs). This is not the path to the actual server but a synonym to indicate that NFS is being used.
	- nfsroot using **nfsroot=\[\<server-ip>:]\<root-dir>\[,\<nfs-options>]** . 
	- NFS options for nfsroot include:
	    - Port from the server portmap daemon.
	    - Rsize and wsize to specify the buffer size for read and write requests.
	    - timeo to specify the timeout threshold in tenths of a second.
	- Configuration for IP addresses or use the **ip=autoconf** to indicate autoconfiguration.
	- nfsrootdebug to enable debugging messages to display during kernel boot.

Boot from ISO
- An ISO image is a file that is an identical copy of the original media. 
- ISO images are a convenient and common way to load a Linux distro
- An ISO image containing the Linux distro can be used from a variety of media, including a CD/DVD, a USB stick, and a hard disk drive (HDD). 
- The .iso can also be configured to be bootable, allowing the Linux distro to be loaded from the media

Boot from HTTP
- HTTP boot is a client-server communication based application. 
- It combines the dynamic host configuration protocol (DHCP), DNS, and HTTP to provide the capability for system deployment and configuration over the network
- Provides higher performance than TFTP, it's used to replace the PXE boot method of network deployment
- The basic process for booting using HTTP is as follows:
	- The client initiates the DHCP process by broadcasting a DHCP request containing the HTTP Boot identifier. A DHCP server that supports the HTTP Boot extension provides a boot resource location in Uniform Resource Identifier (URI) format to the client.
	- The URI points to the Network Boot Program that is appropriate for the client’s request. The client then uses the HTTP protocol to download the NBP from the HTTP server to its memory.
	- The client executes the downloaded NBP image. This program may then use other UEFI interfaces for further system setup based on the NBP design.

### System Services
| Term       | Definition                                                                                                                                                                           |
| ---------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Daemon     | A computer program that runs as a background process. It may run in response to an event or may be set up to run at a specific time.                                                 |
| Process    | A running program. It is often used synonymously with service or daemon.                                                                                                             |
| Service    | A term that is used interchangeably with process and daemon. ( **service** is also a command in earlier versions of Linux that runs and controls processes using a SysVinit script.) |
| **mask**   | An option of the **systemctl** command that prevents a service from starting.                                                                                                        |
| **unmask** | An option of the **systemctl** command that removes a mask from a service.                                                                                                           |
Targets control how your system starts
Daemons further define how your system runs
System services run at boot time

How to control them
- Rarely have a UI
- To start a daemon, use the `systemctl` command
	- `systemctl start <daemon name>`
	- `systemctl stop <daemon name>`
	- `systemctl restart <daemon name>`
		- Restarting a daemon fixes a lot of problems
	- `systemctl status <daemon name>`
	- `systemctl reload <daemon name>`
		- Rereads and updates the configuration
		- Doesn't stop the daemon for the users on the system
		- Isn't available for all daemons
	- `systemctl enable <daemon name>`
		- Makes a daemon run at boot
	- `systemctl disable <daemon name>`
		- Prevents a daemon from running at boot 
	- `systemctl is-enabled <daemon name>`
- Daemons are often named a service followed by d like ntpd

|Command|Function|Example|
|---|---|---|
|**systemctl start _service_ .service**|Starts a daemon.|**systemctl start nfs.service** starts the NFS daemon.|
|**systemctl stop _service_ .service**|Stops a daemon.|**systemctl stop nfs.service** stops the NFS daemon.|
|**systemctl restart _service_ .service**|Restarts a daemon.|**systemctl restart nfs.service** stops and then restarts the NFS daemon.|
|**systemctl reload _service_ .service**|Reloads a daemon's configuration without actually stopping the daemon itself.|**systemctl reload nfs.service** reloads the NFS daemon's configuration file without stopping the daemon itself.|
|**systemctl status _service_ .service**|Displays a daemon's status.|**systemctl status nfs.service** displays the current status of the NFS daemon.|
|**systemctl enable _service_ .service**|Automatically starts a daemon when the system starts.|**systemctl enable nfs.service** automatically starts the NFS daemon every time the system boots.|
|**systemctl disable _service_ .service**|Prevents a daemon from automatically starting when the system starts.|**systemctl disable nfs.service** disables the NFS daemon so that it does not automatically start when the system boots.|
|**systemctl is-enabled _service_ .service**|Looks to see if a daemon is configured to automatically start on system boot.|**systemctl is-enabled nfs.service** displays whether or not the NFS daemon will be automatically started when the system boots.|
|**systemctl mask _service_ .service**|Prevents a daemon from starting at all, either automatically or manually, from the shell prompt.|**systemctl mask nfs.service** prevents the NFS daemon from starting at all.|
|**systemctl unmask _service_ .service**|Unmasks a previously masked daemon. This allows the daemon to be started either manually or automatically.|**systemctl unmask nfs.service** unmasks the NFS daemon.|


### System Shutdown
- Unclean Shutdowns
	- Push and hold power button
	- Pull the plug
	- UPS runs out of battery power
- Use an uninterruptible power supply
	- Battery powered
	- Stalls and gives the system time to shut down if a blackout occurs
- Clean Shutdowns
	- runlevel 0 halts a system
	- runlevel 6 reboots a system
	- poweroff.target halts a system
	- reboot.target reboots a system
- Shut down with shell commands (requires root access. Use sudo or login as root)
	- halt
		- shuts down a system
	- reboot
		- restarts a system
	- shutdown
		- -H halts
		- -P poweroff
		- -r reboots
		- TIME specifies when the system should shutdown
		- -c cancels delayed shutdown
- Message users
	- wall utility messages everyone
		- Acronym for write all
		- Only displays on a terminal window for logged in users
		- `wall "message"`
		- `wall /path`
		- the -n parameter makes the message anonymous

| Command                                                                                                                      | Function                                                                                                                                                                                                                                                                                         | Examples                                                                                                                                                                                                                                                                                                                                             |
| ---------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **shutdown -h now  <br>halt**  <br>**init 0  <br>systemctl isolate poweroff.target  <br>systemctl isolate runlevel0.target** | Shuts the system down immediately. Consider the following for the **shutdown** command:<br><br>- **-h** specifies that the system halt or power off after shutdown.<br>- **now** forces the system to shut down without a delay.<br><br>Any of these commands shuts the system down immediately. |                                                                                                                                                                                                                                                                                                                                                      |
| **shutdown -r now  <br>reboot  <br>init 6  <br>systemctl isolate reboot.target  <br>systemctl isolate runlevel6.target**     | Shuts the system down immediately and then reboots.<br><br>Any of these commands reboots the system immediately.                                                                                                                                                                                 |                                                                                                                                                                                                                                                                                                                                                      |
| **shutdown -h _time message_  <br>shutdown -r _time message_**                                                               | Shuts the system down in the designated amount of time and sends a message.                                                                                                                                                                                                                      | **shutdown -h +5** **System is going down** sends a message and shuts the system down in five minutes.**  <br>shutdown -h 22:00** shuts the system down at 10:00 p.m.  <br>**shutdown -r +15** reboots the system in 15 minutes.  <br>**shutdown -r 24:00** **System is going down at Midnight** sends a message and reboots the system at midnight. |
| **shutdown -c  <br>Ctrl+c**                                                                                                  | Cancels a pending shutdown.                                                                                                                                                                                                                                                                      |                                                                                                                                                                                                                                                                                                                                                      |
| **shutdown -rf _time_**                                                                                                      | The **-r** parameter issues the reboot command.  <br>The **-f** parameter stands for reboot fast and skips the fsck utility on reboot.                                                                                                                                                           | **shutdown -rf** reboots the system and skips fsck.**  <br>shutdown -r +15** reboots the system in 15 minutes and uses fsck.                                                                                                                                                                                                                         |
| **shutdown -k _message_**                                                                                                    | Sends a warning message, but does not shut down the system.                                                                                                                                                                                                                                      | **shutdown -k Please log out of the system** sends the message to logged in users, but does not actually shut the system down.                                                                                                                                                                                                                       |



# ~Part 2~
### Graphical User Interfaces
| Term                           | Definition                                                                                                                                                                                                                                                                                                                                                                                   |
| ------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Graphical user interface (GUI) | A mechanism in Linux that allows a user to perform functions with a mouse and keyboard (similar to Windows and Mac interfaces) as opposed to performing all functions from a Linux shell.                                                                                                                                                                                                    |
| Scenegraph                     | A data structure representing a graphical scene. When using the Wayland system, the Wayland compositor keeps track of what's on the screens in a scenegraph. This lets the Wayland compositor know which Wayland client should receive events from hardware devices (such as the keyboard). When the Wayland client makes changes, these are sent to and recorded by the Wayland compositor. |
| Display server                 | The program responsible for coordinating the input and output of the programs and applications running the GUI interface. These may go to and from the rest of the operating system, the hardware, or each other.                                                                                                                                                                            |
| Window manager                 | A manager that controls the placement and appearance of windows on a Linux computer (such as moving, hiding, resizing, or closing), as well as controlling what they display. In X11, this is a separate program. In Wayland, this function is incorporated in the Wayland compositor.                                                                                                       |
| Desktop environment            | The environment that controls desktop features, including menus, screensavers, wallpapers, desktop icons, and taskbars. Common desktops include Gnome, Unity, Cinnamon, MATE, and KDE.                                                                                                                                                                                                       |
The Display Server
- A display server is a program that sits between the kernel and GUI
- Coordinates IO for programs
- Determines how programs are displayed
- Common Protocols
	- X11 (X Windows)
		- Most commonly implemented display servers
		- XFree86 was the standard X Windows server
		- Licensing issues disturbed devs
		- X.Org became the new standard
		- Determines what client window is effected by an event and then messages them what they need to know. The client then sends the desired update back to the server, which then updates the compositor. 
	- Wayland
		- Considers the server and compositor as one large component. It detects an event, uses a scenegraph to check which client needs the event, and then the client can render, then the compositor redraws the scene and updates its scenegraph. 

Window Manager
- Also called compositor
	- No it's not, cause apparently they're different
- Customized how windows look and behave
- Common
	- X11 Window Mangers
		- Enlightenment
		- KWin
	- Wayland
		- Sway
		- Way Cooler
		- KWin
		- Enlightenment
- Stay away from minimalist ones and choose something like Enlightenment

Desktop
- Ties everything together
- Preference based
- A single distro can support multiple desktops
- Desktops
	- GNOME
	- Unity
	- Cinnamon
	- MATE
	- KDE

X11 Systems

| Component           | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| ------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| X11 Server          | The X11 server is the main component of the X Window System.  <br>  <br>The X11 server:<br><br>- Manages input devices, such as the mouse and keyboard, and controls output to monitors and printers.<br>- Is networked, which means its output can be displayed locally or sent over the network to other computers.<br>- Uses the DISPLAY environment variable to control where the output is sent. Setting DISPLAY to **0:0** will send the X11 server output to the monitor on the local system.<br>- Has two common implementations.<br>    - X.Org is most commonly used by X11 Windows systems.<br>    - XFree86 is an earlier X11 server implementation that was used by default in most Linux distributions up until 2004. |
| Window manager      | A window manager controls the placement and appearance of windows on a Linux computer (such as moving, hiding, resizing, or closing), as well as controlling what they display. Most Linux distributions come with multiple window managers.  <br>A few window manager examples for X11 include:<br><br>- Enlightenment<br>- Sawfish<br>- KDE Window Manager (KWin)                                                                                                                                                                                                                                                                                                                                                                 |
| X client            | X clients are the graphical applications (such as Firefox) requesting the display of pixel buffers on the screen.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| Desktop environment | A desktop environment controls the desktop features, including desktop menus, screensavers, wallpapers, desktop icons, and taskbars.<br><br>The two most common desktop environments are GNU Network Object Model Environment (GNOME) and Kool Desktop Environment (KDE).                                                                                                                                                                                                                                                                                                                                                                                                                                                           |

Wayland Systems

|Component|Description|
|---|---|
|Wayland compositor|The Wayland compositor is the main component of the Wayland system. In a Wayland system, the display server and the compositor (window manager) are one component, simplifying the process of updating the GUI.  <br>  <br>The Wayland compositor:<br><br>- Manages input devices, such as the mouse and keyboard, and controls output to monitors and printers.<br>- Is networked, which means its output can be displayed locally or sent over the network to other computers.<br>- Controls the placement and appearance of windows (such as moving, hiding, resizing, or closing).<br>- Controls what is displayed.|
|Wayland client|Clients are the graphical applications (such as Firefox) requesting the display of pixel buffers on the screen. In a Wayland system, the client also performs the rendering by itself and then shares that information with the compositor.|
|Desktop environment|A desktop environment controls the desktop features, including desktop menus, screensavers, wallpapers, desktop icons, and taskbars.<br><br>The two most common desktop environments are GNU Network Object Model Environment (GNOME) and Kool Desktop Environment (KDE).|


### Linux Desktops
- Most distros have a default desktop
- There are dozens of environments to choose from
- GNOME
	- One of the most popular
	- Default GUI for fedora and ubuntu
	- Most of the space is blank except for the top bar
	- Activities menu used to start and stop apps
- Unity
	- Primarily on Ubuntu
	- The top has menu buttons
	- Left has quick launch bar
	- I like how it looks
- MATE
	- Based on early version of gnome
	- Top bar has settings
	- Icons in the top right are grouped by category
- Cinnamon
	- Designed to resemble windows
	- Menu button in bottom left
- KDE Plasma
	- Settings in bottom right
	- Main menu in bottom left
	- Has a thing for words that start with K
	- Widgets exist that can run on the desktop


### Remote Desktop
- Lets you use one PC to control another
- Both systems need the app
- One runs the server, one runs the client
- SSH creates a secure connection
- The client can operate the server
- Useful for
	- Administration
	- Troubleshooting
	- User access to powerful desktop resources
- Remote Desktop Features
	- Can send prints
	- Listen to audio
	- Copy and paste between local and remote systems
- Considerations
	- Locks the desktop for the server
	- Blocks interactive logons
	- Requires logout of local users on the remote system
	- Quality is dependent on the network connection
- Remote desktops for Linux
	- VNC
		- Virtual network computing
	- XRDP
	- No Machine
	- SPICE
		- Owned by RedHat

| Technology                                                          | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| ------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Virtual Network Computing  <br>(VNC)                                | VNC allows you to connect to and control a remote computer. In doing so, VNC transmits the keyboard and mouse events from the remote server back to the client computer. VNC also supports relaying graphical user interface (GUI) updates back to the client computer over the network. VNC is one of the most popular remote desktop technologies.                                                                                                                                                                                                                                                                                                                                |
| xrdp                                                                | xrdp is an open-source implementation of Microsoft's Remote Desktop Protocol. This technology allows a Windows machine to connect to a Linux system using Windows Remote Desktop. xrdp also works with FreeRDP and rdesktop. This technology uses Xvnc or X11rdp to manage the X session.                                                                                                                                                                                                                                                                                                                                                                                           |
| NX                                                                  | NX is the remote desktop protocol developed by a company called NoMachine. They produce a remote desktop solution (also named NoMachine) that lets you connect using the NX or SSH protocols (NX is used by default). In addition to Linux, NX is also available on the other common platforms, such as Windows, Mac and iOS, Android, and Raspberry. This allows you to connect to and from various platforms, such as from Linux to Linux or to and from Linux and Windows.                                                                                                                                                                                                       |
| Simple Protocol for Independent Computing Environments  <br>(SPICE) | The main purpose of SPICE is to provide a complete, open-source solution for remote access to virtual machines. With SPICE, you can seamlessly play videos, record audio, share USB devices, and share folders without complications. The basic building blocks for SPICE are the SPICE protocol, server, and client. SPICE-related components include QXL (a paravirtualized framebuffer device) and the guest QXL driver. Qumranet originally developed SPICE using a closed-source codebase in 2007. However, in 2008, Red Hat, Inc. acquired Qumranet. Then in December of 2009, Red Hat released the code under an open-source license and made the protocol an open standard. |

### Accessibility
- Each Linux Distro is different and some don't have universal access. The concepts are general
- Universal access is enabled by default in many systems
- Search "Universal Access"
- Enable or disable features with on/off buttons
- Seeing
	- High contrast
	- Large text
	- Cursor Size
	- Zoom
		- Magnifying glass
	- Screen Reader
		- Reads text
	- Sound Keys
		- Hears beep whenever num lock or caps lock is turned on or off

| Feature                   | **Description**                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     |
| ------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| High Contrast             | Changes the contrast of the windows and buttons so that they’re easier to see. This is not the same as changing the brightness of the whole screen since not all parts of the user interface always change.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |
| Large Text                | Increases the font size to a preset size.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| Cursor Size               | Provides a menu where you can select cursor sizes (from small to large).                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| Zoom                      | Turns your mouse into a type of magnifying glass by default. Additional options let you limit which part of the screen is magnified.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
| Screen Reader and Braille | A screen reader reads the text on a screen, including menu and button text.<br><br>Popular screen readers on Linux systems include the following:<br><br>- Orca - a free, open-source scriptable screen reader that works with the GNOME desktop.<br>- Emacspeak - a free screen reader that's often bundled with text editors.<br><br>Linux can also use the following Braille hardware devices:<br><br>- Braille Display - a special type of computer monitor that creates a tactile display of textual information. Many Linux text-mode applications manage Braille Display with no configuration changes.<br>- Braille Embosser - prints a hard copy of a text document using embossed Braille characters. A Linux daemon named _brltty_ redirects text-mode output to a Braille device and is often required. |
| Sound Keys                | Lets the user hear a beep (or another sound) when the Num Lock or Caps Lock keys are turned on or off.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              |



- Hearing
	- Visual Alerts
		- If someone wants to be notified of an alert sound, a flash displays

|   |   |
|---|---|
|Visual Alerts|Notifies the user when an alert sound is played. Options include:<br><br>- Flashing the windows title<br>- Flashing the entire screen|


- Typing
	- Screen Keyboard
		- On screen keyboard used with the mouse
	- Repeat Keys
		- Determines whether to continue typing a key if it's held down
	- Cursor Blinking
	- Typing Assist (AccessX)
		- Sticky keys (lets you type shortcuts one key at a time)
		- Slow keys (time between pressing a key and it being accepted)
		- Bounce keys (ignores fast duplicate keypresses)

|Feature|**Description**|
|---|---|
|Screen Keyboard|An onscreen keyboard that displays an image of a physical keyboard, which allows the individual to use a mouse or touchscreen to select keys as if they were pressed on a real keyboard.<br><br>The GNOME Onscreen Keyboard (GOK) provides the onscreen keyboard for many distributions. But other applications (such as Onboard and Florence) provide the same feature as well.|
|Repeat Keys|Affects how quickly the action associated with a key is repeatedly performed when the key is pressed and held down. For example, if you press and hold a character key, such as the letter D, that character is typed repeatedly according to the repeat rate.|
|Cursor Blinking|Determines if the cursor shown will blink and, if so, the rate at which it blinks.|
|Typing Assist (AccessX)|Lets you configure the following:<br><br>- Sticky Keys - lets you type keyboard shortcuts one key at a time rather than having to hold down all of the keys at once. For example, instead of needing to press and hold the Ctrl key and then press the C key, with this feature enabled, you can instead press and release the Ctrl key and then press the C key.<br>- Slow Keys - determines the delay or the amount of time that elapses between the time you press the key and when it is accepted. Additional features let you include auditable sounds to aid in this process.<br>- Bounce Keys - ignores fast key presses of the same key, compensating for when users accidentally press a single key multiple times.|


- Pointing and Clicking
	- Mouse keys
		- Lets you move the mouse with the numeric keypad
	- Click assist
		- Lets you perform mouse clicks in different ways
		- Performs double clicks on held
		- Hover click
	- Double click delay
		- Adjust delay as needed

|Feature|Description|
|---|---|
|Mouse Keys|Lets you move your mouse by means of the numeric keypad. For example, if you need to move the mouse to the left, you press the 4 key. To move the mouse up, you press the 8 key. To move your mouse down, you press 2, and so forth.|
|Click Assist|Click Assist includes the following options:<br><br>- The simulated Secondary click option, which allows you to send a double-click by simply holding down the primary mouse button for a specified amount of time.<br>- The Hover click option, which sends a mouse click whenever the mouse pointer stops moving for a specified amount of time.|
|Double-Click Delay|Double-clicking only happens when you press the mouse button twice and quickly enough. If the second press is too long after the first, you’ll get two separate clicks, not a double-click. By adjusting this setting, you change the amount of time that can elapse between the first and second click to still qualify as a double-click.|

# ~Part 3~
### Red Hat Package Manager (RPM)
- Installing software on Linux is weird and the process is very different
- You have two options
	- Install precompiled app from a software package
	- Install the application from source code, then use a compiler to turn it into an executable

From Package
- You need a package manager. Many use RPM. Ubuntu uses DPKG
- Regardless, they both install software, update software, uninstall software, query software, and verify software integrity. 
- RPM stores a database of installed packages /var/lib/rpm. If the file is corrupted, you can run `rpm --rebuilddb`
- RPM packages follow naming conventions
	- They come precompiled for certain hardware architectures and distros
	- Make sure you get the correct version for your system
	- Parts of the name `gftp-2.0.19-12.fc21.x86_64`
		- Name
		- DASH
		- Version Number
		- DASH
		- Release Number
			- **fcx** is for Fedora
		    - **rhlx** is for Red Hat
		    - **suse** _xxx_ is for version _xxx_ of SUSE
		- DOT
		- Distribution Field (optional)
		- DOT
		- Release numbers might contain distribution data:
		- Aarchitecture Type
		    - **i386** is for any Intel 80386 or newer processor.
		    - **i586** is for any Intel Pentium I or newer processor.
		    - **i686** is for any Intel Pentium II or newer processor.
		    - **x86_64** is for 64-bit Intel or AMD CPUs.
		    - **noarch** is for any architecture (not architecture-specific).
- The best place to find packages is the package repository for your distribution
	- /etc/yum.repos.d/fedora.repo
	- yum downloader downloads from the repository
- After you install a package, use the `rpm --checksig` command to verify its integrity

Managing Packages
- Installing
	- `rpm -i package_name`
	- The `-ihv` parameter gives you more information
- Check Dependencies
	- `rpm -i --test package_name`
	- Doesn't install, just verifies dependencies
	- Prints necessary software
- Check installed
	- `rpm -qa`
- Update
	- `rpm -U package_name`
- Uninstall
	- `rpm -e package_name`
	- -e stands for erase
- Query
	- `rpm -q package_name`
	- `rpm -qi package_name`
		- Gives extra information
	- Gives you detailed information about a package
	- DONT PUT IN A FILE NAME BECAUSE THAT WONT WORK
	- USE THE PACKAGE NAME WHICH DOESNT INCLUDE .RPM
- Verify
	- `rpm --checksig package_name`

| Command      | Function                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        | Examples                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| ------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **rpm**      | Uses the Red Hat Package Manager (RPM) to manage packages. Package options are:<br><br>- **--rebuilddb** rebuilds the database indices from the installed package headers.<br>- **--initdb** creates a new database.<br>- **--checksig** checks the authenticity of the package. The option checks the package's digital signing key against the package to ensure it has not been altered.<br>- **-i** installs a package. Uses the entire package filename when installing.<br>- **-h** prints hash marks as the package archive is unpacked.<br>- **-v** displays a verbose version of the installation.<br>- **--test** tests a package for uninstalled dependencies without actually installing it.<br>- **--nodeps** installs the package without checking for dependencies. This is not recommended.<br>- **--force** installs the package regardless of whether a newer version of the package is already installed, package files overwrite files from previously installed packages, or if the package replaces other installed packages.<br>- **-e** uninstalls (e.g., erases) a package. To uninstall a package, use the package name, not the file name. If dependencies exist, the dependent packages must first be removed.<br>- **-U** updates an installed package to the newest version.<br>- **-F** upgrades the package, but only if an earlier version currently exists on the system.<br>- **-q** queries the computer for information about installed packages.<br>    <br>    Use this with **-a** to list all packages and **-l** to show the files associated with the package.<br>    <br>- **-V** verifies that packages are free from errors by performing an MD5 checksum on the package. RPM only gives output when packages have errors. If errors are present, the command displays the error code and the file name. The error codes are:<br>    - S indicates a problem in the size of a file.<br>    - M indicates a problem with a file's mode.<br>    - 5 indicates a problem with the MD5 checksum of a file.<br>    - D indicates a problem with a file's revision numbers.<br>    - L indicates a problem with a file's symbolic link.<br>    - U indicates a problem with a file's ownership.<br>    - G indicates a problem with a file's group.<br>    - T indicates a problem with the modification time of a file.<br>    - c indicates the specified file is a configuration file.<br>    - ' **.** ' in place of a code letter indicates that no error is present in that area. | **rpm --checksig acroread** checks the authenticity of the acroread package.**  <br>rpm -i BackupPC-3.1.0-3.fc9.src.rpm** installs the BackupPC package.  <br>**rpm -ihv http://rpm.sh-linux.org/rpm-fc9/target-SRPMS/BackupPC-3.1.0-3.fc9.src.rpm** installs the specified package directly from the internet.  <br>**rpm -i --test dbus-python-0.83.0-2.fc9.src.rpm** tests the computer for uninstalled dependencies for the dbus-python package.  <br>**rpm -i --nodeps dbus-python-0.83.0-2.fc9.src.rpm** installs the package but does not check for missing dependencies.  <br>**rpm -i --force dbus-python-0.83.0-2.fc9.src.rpm** installs the package regardless of effects on other packages.  <br>**rpm -e dbus-python** removes the package from the computer.  <br>**rpm -e --nodeps dbus-python** removes the package from the computer but does not check for dependent packages.  <br>**rpm -U dbus-python-0.83.0-2.fc9.src.rpm** removes any version older than the specified version and installs the specified package.  <br>**rpm -U --replacepkgs dbus-python-0.83.0-2.fc9.src.rpm** reinstalls the dbus-python package. This option is for fixing errors.  <br>**rpm -qa** displays a list of all installed packages.  <br>**rpm -qi BackupPC** shows all available information about the BackupPC package.  <br>**rpm -q --whatrequires gmp** lists the packages that are dependent on the gmp package.  <br>**rpm -ql metacity** shows the files associated with the metacity package.  <br>**rpm -q --provides gmp** lists the functions that the gmp package provides.  <br>**rpm -q --requires gmp** lists the functions that the gmp package requires.  <br>**rpm -q --whatprovides /usr/lib/libstlport_gcc.so** shows the package that provides the libstlport_gcc.so file.  <br>**rpm -V BackupPC** verifies the BackupPC package.  <br>**rpm -Va** verifies all installed packages. |
| **rpm2cpio** | Converts RPM packages into a cpio archive. This is useful for extracting files from an RPM package without installing and searching for the specific files.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | **rpm2cpio logrotate-1.0-1.i386.rpm > logrotate.cpio** converts the files from the **logrotate** package into a cpio archive.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |



### Online Package Installation
|Term|Definition|
|---|---|
|Software repository|An online location that stores software packages for a Linux distribution.|
|YUM|The Yellowdog Updater, Modified package manager.|
|yumdownloader|A utility that downloads an RPM package from a software repository.|
|DNF|The Dandified YUM package manager.|
Yellowdog Updater Modified
- Advantages over the RPM
	- Installs with dependencies automatically
	- Automatically locates requested packages by searching repositories on the internet
- YUM equivalents
	- Zypper (open SUSE)
	- Dnf 
- YUM syntax
	- `yum option command package_name`
		- remove
		- list installed
		- list installed package_name
		- list
		- list updates
		- list update package_name
		- info package_name
		- whatprovides file_name
	- `yum install package_name`
	- `yumdownloader package_name`
		- Queries the same repositories and saves them in the current dir you ran the command from
		- Then you can download them manually
- /etc/yum.conf
	- Defines the URL for software repositories where packages are saved
- /etc/yum.repos.d
	- Store the repos in a separate file for each repo for the yum utility to use

|Command|Function|Example|
|---|---|---|
|**yum**|Installs RPM packages, including their dependencies. Be aware of the following actions and options:<br><br>- **list** displays lists of packages.<br>- **install** installs a package. Use the entire package filename for installations.<br>- **list updates** displays whether updates are available for packages.<br>- **update** updates RPM packages.<br>- **list available** lists packages that are available to install.<br>- **search** searches all packages for a specified term.<br>- **info** displays detailed package information.<br>- **provides** , **whatprovides** display which packages are associated with a specific file.<br>- **remove, erase** uninstalls a package.<br>- **-y** bypasses confirmation prompts.|**yum list all** shows all packages in the repository and any installed on the computer.  <br>**yum list javahelp2** searches for the javahelp2 package in the repository.  <br>**yum list *help*** lists all packages in the repository that have the string "help" somewhere in the name.  <br>**yum list installed mtools** shows whether the mtools package is installed on the computer.**  <br>yum install BackupPC-3.1.0-3.fc9.rpm** installs the BackupPC package and any package dependencies.  <br>**yum install http://rpm.sh-linux.org/rpm-fc9/target/BackupPC-3.1.0-3.fc9.rpm** installs the specified package directly from the internet.  <br>**yum list update mtools** looks for an update for the mtools package and updates it if one is available.  <br>**yum update sssd** updates the sssd package.  <br>**yum update** updates all installed packages.  <br>**yum list available** shows the available packages.  <br>**yum search Java** searches all package information and descriptions for the term _Java_ .  <br>**yum info zuff** shows information about the zuff package.  <br>**yum whatprovides /etc/updatedb.conf** shows which packages are associated with the updatedb.conf file.  <br>**yum remove kdegames** uninstalls the kdegames package from your computer.  <br>**yum -y update** updates all packages without requesting confirmation prompts.|
|**yumdownloader**|Downloads a package without installing it.|**yumdownloader zuff** downloads the zuff package, but does not install it.|
|**createrepo**|Creates a repository list of RPM packages stored locally or on a network. Be aware of the following options:<br><br>- **-g** specifies an XML file for the repository.<br>- **-x** excludes specific file globs.|**createrepo -g** **packagefile.xml** creates a list of packages using the .xml file.|
|**dnf**|Installs RPM packages, including their dependencies. Be aware of the following actions and options:<br><br>- **list** displays lists of packages.<br>- **install** installs a package. Use the entire package file name when installing.<br>- **list updates** displays whether updates are available for packages.<br>- **update** updates RPM packages.<br>- **list available** lists packages that are available to install.<br>- **search** searches all packages for a specified term.<br>- **info** displays detailed package information.<br>- **provides** , **whatprovides** display which packages are associated with a specific file.<br>- **remove, erase** uninstalls a package.<br>- **-y** bypasses confirmation prompts.|**dnf list all** shows all packages in the repository and any installed on the computer.  <br>**dnf list javahelp2** searches for the javahelp2 package in the repository.  <br>**dnf list *help*** lists all packages in the repository that have the string help somewhere in the name.  <br>**dnf list installed mtools** shows whether the mtools package is installed on the computer.**  <br>dnf install BackupPC-3.1.0-3.fc9.rpm** installs the BackupPC package and any package dependencies.  <br>**dnf install http://rpm.sh-linux.org/rpm-fc9/target/BackupPC-3.1.0-3.fc9.rpm** installs the specified package directly from the internet.  <br>**dnf list update mtools** looks for an update for the mtools package and updates it if one is available.  <br>**dnf update sssd** updates the sssd package.  <br>**dnf update** updates all installed packages.  <br>**dnf list available** shows the available packages.  <br>**dnf search Java** searches all package information and descriptions for the term _Java_ .  <br>**dnf info zuff** shows information about the zuff package.  <br>**dnf whatprovides /etc/updatedb.conf** shows which packages are associated with the updatedb.conf file.  <br>**dnf remove kdegames** uninstalls the kdegames package from your computer.  <br>**dnf -y update** updates all packages without requesting confirmation prompts.|

### Debian Package Manager (DPKG)
|Term|Definition|
|---|---|
|Debian packages|A collection of files that allow libraries or applications to be distributed through a package management system. Debian is distinctly different from the RPM format.|
Debian Package Manager
- Some Linux distros use RPM, and others use DPKG
- Use a naming convention similar to RPM
	- packagename_version_architecture.deb
	- flightgear_3.0.0-5_i386.deb
- `dpkg`
	- dpkg action package_name/file_name
	- If it hasn't been installed, use the file_name
	- Install
		- dpkg -i file_name
	- Uninstall
		- dpkg -r package_name
	- List Installed Packages
		- dpkg -l
		- Output will be very long
		- To search for one, use `dpkg -l | grep target`
	- View package files
		- dpkg -L package_name
		- dpkg -S file_name
			- Doesn't always work
	- Check a package
		- dpkg -s
- Advanced Package Tools (APTs)
	- apt-cache
		- queries the debian package database
	- apt-get
		- Gets dependencies automatically
		- apt-get upgrade
		- apt-get remove
		- apt-get dist upgrade ???
	- /etc/apt/sources.list stores repos to check
	- aptitude
		- Has some GUI for package management
		- `sudo apt-get install aptitude`
		- can be used in the command line
			- aptitude install
			- aptitude remove
			- aptitude purge
			- aptitude update
			- aptitude full-upgrade
			- aptitude search


| Command       | Function                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   | Examples                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  |
| ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **dpkg**      | Installs Debian packages on Debian distributions. Be aware of the following **dpkg** options:<br><br>- **-i** installs a package.<br>- **--configure** reconfigures an unpacked package.<br>- **-r** removes the package, but does not delete the configuration files.<br>- **-P** completely uninstalls the package, including the configuration files.<br>- **-p** lists information about a currently installed Debian package.<br>- **-I** (uppercase i) or **--info** lists information about packages that are not installed.<br>- **-l** (lowercase L) displays all packages with names that match a specified pattern.<br>- **-L** shows the installed files for a package.<br>- **-S** finds a package associated with specified files.<br>- **-C** searches for packages that have been installed only partially on the system.<br>- **-B** disables packages that have dependencies on the package being removed.<br>- **--ignore-depends** ignores dependency checking for specified packages.<br>- **-no-act** prevents changes from being written.<br>- **-G** prevents a package from being installed if a newer version of the package already exists on the computer.<br>- **-E** does not install the package if the same version of the package is already installed.<br>- **-R** installs the package recursively.<br><br>The **dpkg-reconfigure** command reconfigures an already installed package.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | **dpkg -i docbook_4.5-4_all.deb** installs the docbook package.**  <br>dpkg -r docbook** removes the docbook package.  <br>**dpkg -P docbook** removes the docbook package and its configuration files.  <br>**dpkg -i docbook** displays information about the package.  <br>**dpkg -I dwm-tools_26-2_i386.deb** displays information about the dwm-tools package.  <br>**dpkg -l kcheckers*** lists all packages that begin with kcheckers.  <br>**dpkg -L docbook** lists all files installed with the docbook package.  <br>**dpkg -S /usr/share/base-files/motd** shows the package associated with the motd file.  <br>**dpkg -B -r docbook** removes the docbook package and disables any package dependent on the docbook package.  <br>**dpkg -G -i docbook_4.5-4_all.deb** installs the docbook package if it is a newer version than a previously installed package.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |
| **apt-cache** | Retrieves information about the Debian package database. Be aware of the following **apt-cache** options:<br><br>- **showpkg** displays information about a package in the database.<br>- **stats** shows the number of packages installed, dependency information, and other package cache statistics.<br>- **unmet** lists any missing dependencies in the package cache.<br>- **depends** shows all of the package's dependencies.<br>- **pkgnames** displays whether a package is installed on the system. When the package name is left off, the command shows information for all packages on the computer.<br>- **search** searches for a package in the cache.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | **apt-cache showpkg 3dchess** shows information about the 3dchess package.  <br>**apt-cache depends 3dchess** shows dependency information for the 3dchess package.  <br>**apt-cache pkgnames 3dchess** displays whether the 3dchess package is installed.**  <br>apt-cache search kde** searches for all packages that contain "kde" anywhere in the name.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
| **apt-get**   | Downloads and install packages. Be aware that **apt-get:**<br><br>- Is similar to the **yum** utility on an RPM distribution.<br>- Uses the file /etc/apt.conf or the files in the directory /etc/apt/apt.conf.d to configure apt behavior.<br>- Gets its information about the application repositories from the /etc/apt/sources.list file, which is built from files in the directory /etc/apt/sources.list.d.<br>- Automatically calculates and resolves package dependencies when installing, updating, and removing packages.<br><br>## apt-get<br><br>- **update** updates the list of packages available from the sources in **/etc/apt/sources.list** with the latest information about available packages.<br>- **upgrade** upgrades all installed packages to the latest versions in accordance with the information found in the sources listed in **/etc/apt/sources.list** .<br>- **dist-upgrade** similar to the **upgrade** option, but will also install new packages as needed and remove packages as needed.<br>- **install** installs a package using the package name. The package name is not the filename. During the installation, **apt-get** retrieves the most recent version of the package.<br>- **remove** removes a specified package, but leaves the configuration files.<br>- **purge** removes the package and the configuration files.<br>- **source** retrieves the latest version of the package. The command accesses the /etc/apt/sources.list file to determine whether the latest package version is installed.<br>- **check** checks the package database for consistency and errors.<br>- **clean** removes unneeded package information files and logs. This command is needed when not using the dselect utility to install Debian packages.<br>- **autoclean** removes information files about packages that can no longer be downloaded.<br>- **-d** downloads packages without installing them.<br>- **-f** attempts to fix a computer with unsatisfied dependencies. (Use with: **apt-get install** and **apt-get remove** )<br>- **-m** ignores package files that cannot be accessed or located.<br>- **-q** shows less progress information.<br>- **-s** simulates package installation without doing an actual install.<br>- **-y** automatically provides a _yes_ response to _yes/no_ questions in the package installation script. | **apt-get info 3dchess** shows package and dependency information for the 3dchess package.**  <br>apt-get install 3dchess** downloads and installs the 3dchess package from a package repository.  <br>**apt-get remove 3dchess** removes the 3dchess package, but leaves the 3dchess configuration files.  <br>**apt-get purge 3dchess** removes the 3dchess package along with the 3dchess configuration files.  <br><br>Before **purge** was added as a command in the **apt-get** utility, you had to use **--purge** as an option with the **remove** command (for example, **apt-get remove --purge 3dchess** ). This older syntax is still supported.<br><br>**apt-get source 3dchess** determines whether a newer version of 3dchess is available, and if so, installs it.**  <br>apt-get -d install 3dchess** downloads the 3dchess package without installing it.**  <br>apt-get -f install 3dchess** tries to fix dependency issues for the 3dchess package.  <br>**apt-get -m remove 3dchess** removes the 3dchess package, but ignores missing files.  <br>**apt-get -q remove 3dchess** removes the 3dchess package, but shows less of the information during the process.  <br>**apt-get -s install 3dchess** tests the installation process of the 3dchess package without installing it.  <br>**apt-get -y install 3dchess** installs the 3dchess package and automatically provides a yes answer to any yes/no prompts. |
| **apt**       | The **apt** command is similar in design and function to the **apt-get** tool suite mentioned above. The **apt** command manages dpkg packages on Debian- and Ubuntu-based distributions. You can also use it to locate, download, and install packages found in online repositories.  <br>  <br>The syntax for using **apt** is as follows:<br><br>- **apt install _package_name_** installs the specified package.<br>- **apt remove _package_name_** uninstalls the specified package.<br>- **apt search _search_term_** looks for packages with the search term found in the configured repositories.<br>- **apt update** updates repositories with the latest list of available packages found in the configured repositories.<br>- **apt dist-upgrade** upgrades all installed packages with any available updated packages.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         | **apt update** update list of available packages from repositories  <br>**apt info 3dchess** shows dependency information for the 3dchess package.  <br>**apt install 3dchess** downloads and installs the 3dchess package from a package repository.  <br>**apt remove 3dchess** removes the 3dchess package, but leaves the 3dchess configuration files.  <br>**apt purge 3dchess** removes the 3dchess package along with the 3dchess configuration files.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                             |
| **aptitude**  | Views the list of packages and perform package management tasks such as installing, upgrading, and removing packages in the Advanced Packaging Tool (APT). The **aptitude** command is APT's front end. This command displays a list of software packages and allows the user to interactively pick packages to install or remove.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                           |


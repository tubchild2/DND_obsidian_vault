
### Processes
**top**
	Returns process ID (PID), uptime, load, CPU status, memory, and priority information for processes.
	Is useful in situations where you need to monitor processes continuously
	-h displays the help screen
	-f adds or removes columns from the chart
	-F shows a list of sortable columns, the press the key of the letter next to the column to be sorted
	-u specifies one specific user

**ps**
	Provides information about the currently running processes, including the PIDs.
	Displays a snapshot of cuurrently running processes in ascending order based on the PID. 
	By default, the ps command displays
		- PID
		- Name of the shell session (TTY)
		- CPU time the process has used (TIME)
		- The command used to invoke the process (CMD)
	Other options
		-A, -e shows all processes
		-a shows processes owned by other users and attached for a terminal
		-f shows detailed information for processes
		-u shows processes by user ID
		-i shows the processes in long format and the process state (under thman e STAT column)
			sleeping (S)
			running (r)
			traced (t) by another process
			zombie (Z)
		-x shows processes that are not attached to a terminal. Use this to view daemons that begin during system boot

**ps aux**
	Lists all processes in great detail.

**pidof**
	Finds the processes ID of a process.
	You can also output ps aux to a text file, and use grep to search for the process by name.

**pgrep**
	Combined the functionality of the ps command, and the grep command. 
	You can specify certain selection criteria that you want the command to look for. 
	The command then searches through all the currently running processes and then outputs a list of only those processes that match the criteria you specify.
		-f searches for a specific process name
		-p only matches processes whose parent process ID is listed
		-u only matches processes whose effective user ID is listed


### Process Management
**kill**
	Terminates a process using a process ID (PID) and a specific kill signal. 
	Kill signals can be sent using a term or a numeric value. 
	Options include the following
		-SIGHUP, -1
			Tells the process to shut down and restart. When it restarts, the process will have the same PID. 
		-SIGINT, -2
			Stops a process if the Ctrl+c key combination has been used
		-SIGKILL, -9
			Forces a process to stop when it's unresponsive to other options for exiting or killing it. 
			Doesn't give the process a chance to clean up any resources that it's using. 
			Allocated resources remain allocated until it's restarted. 
			Use as last resort. 
		-SIGTERM, -15
			Stops the process cleanly by giving it a chance to  release the resources allocated to it. 
			Default signal used by the kill command if no signal is specified.
		-l 
			Lists all of the signals that are available for the kill command.

**killall**
	Terminates processes in the same way as the kill command, using their command name instead of their PID.
	This command uses the same signal commands that kill uses.

**pkil**
	Searches for processes that match the search criteria and then sends them a kill signal. 
	This command uses the same signal commands that kill uses.

**nohup &**
	Allows a command or shell script to continue running in the background after logging out from a shell
	EXAMPLE: nohup gedit & starts the gedit process in the background

**screen**
	Uses multiple shell windows from within a single SSH session. 
	Using screen, you can
		keep processes running while you access the shell prompt through an SSH connection to enter additional commands
		Keep an SSH shell active even if the network conection is closed or goes down
		Disconnect and reconnect to a shell session from multiple locations without having to stop and then restart whatever processes were running. 
	Shortcuts and Options
		Ctrl+a ? causes the screen help to be displayed
		Ctrl+a c causes a new screen window to be created. The old window remains active along with any processes that were running within it. 
		Ctrl+a n toggles between open windows in the screen.
		Ctrl+a d detaches the screen window and returns the user to the original shell prompt. Whatever was running in the window remains running. In fact, the user can completely log out, and everything will keep running within the detached window. 
		Entering screen -r reattaches a detached screen window. If multiple detached screen windows exist, the user will be prompted to specify which one to reattach to. 



### Task Management
| File                        | Description                                                                                                                                                                                                                                                                                                            |
| --------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| /etc/crontab                | The /etc/crontab (cron table) file holds entries that direct commands to execute at a specific time. The /etc/crontab file:<br><br>- Is used to schedule custom tasks that run system-wide.<br>- Can only be edited by the root user.<br><br>**crond** runs tasks scheduled in the /etc/crontab file as the root user. |
| /etc/cron. _directory_      | The **cron** daemon executes the scripts found in each of the following directories at the specified interval for the whole system:<br><br>- /etc/cron.hourly<br>- /etc/cron.daily<br>- /etc/cron.weekly<br>- /etc/cron.monthly                                                                                        |
| /var/spool/cron/ _username_ | If permitted, each user can create a personal crontab file located at /var/spool/cron/ _username_.                                                                                                                                                                                                                     |
| /etc/cron.allow             | The /etc/cron.allow file identifies users who are allowed to create their own cron jobs. If /etc/cron.allow file exists, then only users listed within it are allowed to create a crontab file in /var/spool/cron/ _username._ All other users are denied, and the /etc/cron.deny file is ignored.                     |
| /etc/cron.deny              | The /etc/cron.deny file identifies users who are not allowed to create cron jobs. If the /etc/cron.deny file exists, only the users listed within it are not allowed to edit /var/spool/cron/ _username._ Everyone else is allowed. This file is only processed if the /etc/cron.allow file does not exist.            |

| Example                                                | Minute | Hour | Day of Month | Month   | Day of Week | Command                                     | Description                                                                                                                                                                                                          |
| ------------------------------------------------------ | ------ | ---- | ------------ | ------- | ----------- | ------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **00 5 * * 6 /bin/tar -cf /home /mnt/usb/homebak.tar** | 00     | 5    | *            | *       | 6           | **/bin/tar -cf /home /mnt/usb/homebak.tar** | This schedule runs the tar utility on the sixth day of the week (Saturday) at the fifth hour (5:00 a.m.) and zero minutes. (Note that the days of the week are numbered 0 through 7, 0 and 7 being equal to Sunday.) |
| **15 23 25 * * /bin/updatedb**                         | 15     | 23   | 25           | *       | *           | **/bin/updatedb**                           | This schedule runs the **updatedb** command at 11:15 p.m. on the 25th of every month.                                                                                                                                |
| **00 24 1 1,6 * /bin/who > /root/who.txt**             | 00     | 24   | 1            | 1 and 6 | *           | **/bin/who > /root/who.txt**                | This schedule runs the **who** command at midnight on the first days of January and June.                                                                                                                            |


**at**
	Lets you schedule a command to run later
	/etc/at.allow specifies who can use it
	/etc/at.deny specifies who can't use it
	Enter at time, then each command you want to run at the at prompt, then press Ctrl+d

|Command|Used To|Examples|
|---|---|---|
|**at _time date_**|Schedules the command to run at a specific time and date. Options and syntax include:<br><br>- **today**<br>- **tomorrow**<br>- **_month #_**<br>- **_MMDDYY_**<br>- **_MM/DD/YY_**<br>- **_DD.MM.YY_**|**at 12:12AM** starts the command the next time the clock reads 12:12 AM.**  <br>at 12:12AM September 1** starts the command at 12:12 AM on September 1.**  <br>at 12:00AM 01/01/2016** starts the command at 12:00 AM on January 1, 2016.**  <br>at 12:00AM 01012016** starts the command at 12:00 AM on January 1, 2016.**  <br>at 12:00AM 01.01.2016** starts the command at 12:00 AM on January 1, 2016.|
|**at _time_of_day_**|Uses time-of-day keywords to run the command. Options are:<br><br>- **Midnight** (12:00 AM)<br>- **Noon** (12:00 PM)<br>- **Teatime** (4:00 PM)|**at midnight** starts the command the next time the clock reads 12:00 AM.|
|**at now**|Runs the command immediately.||
|**at now + _number time_period_**|Schedules the command to run at the designated time in the future. Use:<br><br>- **minutes**<br>- **hours**<br>- **days**<br>- **months**|**at now +** **6 days** starts the command six days after the time the command is issued.  <br>**at now +** **1 months** starts the command one month after the time the command is issued.|
|**at -f _filename_ _time_**|Schedules the tasks listed in the specified file to run at the designated time.|**at -f /home/user/mycommands now + 3 hours** starts the jobs listed in the mycommands file in three hours from the time the command is issued.|
|**at -l  <br>atq**|Lists the tasks in the at queue for the current user.<br><br>- When run as root, **atq** or **at -l** lists all the jobs in the at daemon's queue.<br>- When run as a user other than root, **at** lists only the jobs for the current user.|**atq** shows all jobs in the at queue.|
|**at -d _jobnumber_  <br>atrm _jobnumber_**|Removes jobs from the **at** queue. Uses spaces to separate multiple jobs.|**at -d 2 3** removes jobs 2 and 3 from the at queue.  <br>**atrm 4** removes job 4 from the at queue.|

**cron**
	Essentially lets you schedule commands to run later. Unlike at, it can run repeatedly. 
	crontab
		manages the /var/spool/cron/ username crontab file.
			-e edits the crontab file for the current user in vi
			-l displays the contents of the current user's crontab file
			-r removes the current user's crontab file
			-u username specifies a different user for the -e, -l, and -r options
	crontab file
		loads a crontab job from a file
		Write the file using the crontab syntax

**Scheduling with Cron**
	Go into /etc/crontab
	There's cron.hourly, cron.daily, cron.weekly, and cron.monthly
	Add a bash script into one of these directories
-
	cron.d is for everything else that doesn't fit into those schedules
	You don't put scripts in cron.d
	You add crontab files
	make a crontab file and place it into the cron.d file
-
	Each user can make their own crontab file
	They're stored in /var/spool/cron
	You can check if you have one with crontab -l
	crontab -e makes a new one

**anacron**
	The cron daemon assumes that the Linux OS will remain up 24 hours a day, 7 days a week. 
	If a system is not powered on when a scheduled cron job should run, it's skipped. 
	The anacron service compensates for times when the system is powered off. 
	If a job is scheduled in anacron while the system is off, the missed job will automatically run when the system comes back on.

|Field|Description|
|---|---|
|Period|The period field specifies the recurrence interval in days. For example:<br><br>- 1 means the task recurs daily.<br>- 7 means the task recurs weekly.<br>- 30 means the task recurs every 30 days.<br>- @monthly means the task recurs once per calendar month.|
|Delay|The delay field specifies the time (in minutes) that the anacron daemon should wait before executing a missed job after the system starts back up.|
|Job-identifier|The job-identifier field specifies a name that will be used for the job's timestamp file. The identifier must be unique for each anacron job. The timestamp file is created in the /var/spool/anacron directory and contains a single line with a timestamp that indicates the last time the particular job was run.|
|Command|The command field specifies the command or script that should be run.|




### System Logging
| File/Directory                                | Contents                                                                                                                                                                                                                                                                                                                                                     |
| --------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **/var/log/boot.log  <br>/var/log/boot.msg**  | The system writes messages generated during the boot process to either the boot.log or boot.msg file depending on the distribution.                                                                                                                                                                                                                          |
| **/var/log/faillog  <br>/var/log/btmp**       | Login failures for user accounts are listed in either the faillog or btmp file, depending on the distribution.                                                                                                                                                                                                                                               |
| **/var/log/firewall  <br>/var/log/firewalld** | Depending on the distribution, the system stores log entries for the host firewall.                                                                                                                                                                                                                                                                          |
| **/var/log/lastlog**                          | The lastlog file holds information about the last time each user logged in.                                                                                                                                                                                                                                                                                  |
| **/var/log/maillog**                          | The maillog file contains reports on mail server status and messages related to incoming and outgoing mail.                                                                                                                                                                                                                                                  |
| **/var/log/messages**                         | The messages file is the default file for storing system messages. This file may include copies of messages that appear on the console, internal kernel messages, and messages sent by networking programs.<br><br>The messages file is based on the init daemon, used on older Linux distributions.                                                         |
| **/var/log/warn**                             | The warn file displays warning messages from many processes by default.                                                                                                                                                                                                                                                                                      |
| **/var/log/wtmp**                             | The wtmp file keeps track of all users who have logged into and out of the system, as well as listing every connection and runlevel change.                                                                                                                                                                                                                  |
| **/var/log/dmesg**                            | The dmesg file is often called the kernel ring buffer. It reports messages received in the process of configuring hardware devices as the system boots.                                                                                                                                                                                                      |
| **/var/log/secure**                           | The secure file logs any attempts to log in as the root user or attempts to use the **su** command. This file also contains information on remote logins and failed root user login attempts.                                                                                                                                                                |
| **/var/log/sa**                               | The / **var/log/sa** directory stores **/sa _[n]_** files, which contain all performance information for the day of the month indicated by **_[n]_** . For example, **/var/log/sa/sa15** contains performance information for the fifteenth day of the month, and it will be overwritten on the fifteenth day of the next month.                             |
| **/var/log/cron**                             | The cron file stores messages related to tasks scheduled with cron. It keeps track of which tasks are run and when they were started.                                                                                                                                                                                                                        |
| **/var/log/rpmpkgs**                          | On Red Hat systems, the rpmpkgs file tracks installed packages. It also records all kernel packages on the system.                                                                                                                                                                                                                                           |
| **/tmp/install.log  <br>/root/install.log**   | The install.log may or may not be present, depending on the distribution. This file records messages related to the installation and can be useful for installation records for a computer.                                                                                                                                                                  |
| **/etc/rsyslog.conf**                         | The rsyslog.conf file is the main configuration file for the rsyslogd, which logs system messages on Linux systems. This file specifies rules for logging. For every log message received, rsyslog looks at its configuration file /etc/rsyslog.conf to determine how to handle that message. If no rule statement matches the message, Rsyslog discards it. |
| **/var/log/kern.log**                         | The var/log/kern.log file provides a detailed log of messages from the Linux kernel. These messages may prove useful for trouble-shooting a new or custom-built kernel.                                                                                                                                                                                      |
| **/var/log/ _[application]_**                 | Many applications also create logs in the /var/log directory. If you list the contents of your /var/log subdirectory, you will see familiar names such as /var/log/apache2 representing the logs for the Apache 2 web server, or /var/log/samba, which contains the logs for the Samba server.                                                               |
Log File Notes
	Detect intruders. Troubleshoot.
	Stored in /var/log
		boot.log / boot.msg. Some use one or the other. 
		cron logs cron stuff
		dmesg stores hardware detection information
		faillog stores failed authentication attempts
		firewalld
		lastlog stores last time users logged in
		mail or maillog stores info about mail
		messages is used in older Linux distros that run init
		secure contains info about access to network daemons
		rpmpkgs installed rpm packages
		warn stores warning messages
		wtmp list of authenticated users


Centralized Logging
	It's cumbersome to look at individual log files; centralize them.
	Several third-party agents or daemons can be installed and used:

| Daemon    | Description                                                                                                                                                                                                                                                                                                    |
| --------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| rsyslog   | A lightweight daemon installed on most common Linux distributions. It offers fast, high-performance, great security features and a modular design. It is able to accept inputs from a wide variety of sources, transform them, and output the result to diverse destinations. This is the most popular daemon. |
| syslog-ng | syslog-ng collects logs from any source, processes them in real-time, and delivers them to a wide variety of destinations. syslog-ng also allows you to flexibly collect, parse, classify, rewrite and correlate logs from across your infrastructure and store or route them to log analysis tools.           |
| Fluentd   | Lets you unify the data collection and consumption for better use and understanding of data. Fluentd tries to structure data as JSON as much as possible and has a flexible plug-in system that allows the community to extend its functionality.                                                              |
| logstash  | A heavy-weight agent capable of performing more advanced processing and parsing. It is capable of obtaining data from a multitude of sources simultaneously, and after processing, it can then send it to your favorite “stash.”                                                                               |

**journald**
	Older linux distros don't use journald. 
	/var/log/journal
	You can't view it with cat or less. You have to use the journalctl command
		-b to see boot logs. You can also append a number. 4 shows the fourth boot since the beginning of the journal, and -4 shows boot logs from 4 boots back. 
		-u sorts by specific service / daemon whose entries you want to view. 
		-r sorts in reverse order
		-f shows the most recent logs
		-k shows kernel messages
	Configured in /etc/systemd/journald.conf 
		MaxFileSec
		MaxRetentionSec
		ForwardToSyslog
		MaxLevelStore
			0 emergency
			1 alert
			2 critical
			3 error
			4 warning
			5 notice
			6 info
			7 debug


**var/log/journal**

|Parameter|Description|
|---|---|
|**MaxFileSec**|Specifies the maximum amount of time to store entries in the journal file before starting a new file.|
|**MaxRetentionSec**|Specifies the maximum amount of time to store journal entries. Any entries older than the specified time are automatically deleted from the journal file.|
|**MaxLevelStore**|Specifies the maximum log level of messages stored in the journal file. All messages equal to or less than the log level specified are stored. Any messages above the specified level are dropped. This parameter can be set to:<br><br>- **emerg** (0)<br>- **alert** (1)<br>- **crit** (2)<br>- **err** (3)<br>- **warning** (4)<br>- **notice** (5)<br>- **info** (6)<br>- **debug** (7)|
|**ForwardToSyslog**|Configures journald to forward log messages to the traditional syslogd daemon.|

#### Viewing the Journal

| Command           | Function                                                                                                                                                                                                                                                                                                                                                                                                                                              | Example                                                                                                                                       |
| ----------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------- |
| **journalctl**    | Views the entire journal. The output begins at the beginning of the journal and pauses one page at a time. To exit out of journalctl, press **q** .                                                                                                                                                                                                                                                                                                   | **journalctl**  <br>Displays the journal, starting with the oldest entries.                                                                   |
| **journalctl -b** | Views system boot messages. The messages from the most recent system boot are displayed by default. To display messages from a specific boot, use the following options with this command:<br><br>- Specify a positive number to display messages from the specified system boot, starting from the beginning of the journal.<br>- Specify a negative number to display messages from the specified system boot starting from the end of the journal. | **journalctl -b 2**  <br>Displays messages created during the second boot event from the beginning of the journal.<br><br>## journalctl -b -2 |
| **journalctl -u** | Displays only log entries related to a specific service running on the system.                                                                                                                                                                                                                                                                                                                                                                        | **journalctl -u ntpd**  <br>Displays only journal messages relating to the ntpd daemon.                                                       |
| **journalctl -f** | Displays the last few entries in the journal. The journalctl command then monitors the journal and prints new entries as they are added.                                                                                                                                                                                                                                                                                                              | **journalctl -f**  <br>Displays the last few entries in the journal and then prints new entries as they are added.                            |


#### Log File Display Facts
There are binary and text-based log files

**Text Based**
	Just use cat, grep, tail, head, less, more, vi, or gedit

**Binary Files**

| Command                | Function                                                                                                                                                                                                                                                                                                                                                                                                                       |
| ---------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **dmesg**              | Views the boot logs and troubleshoots hardware errors. The **dmesg** command shows information about all the hardware controlled by the kernel and displays error messages as they occur.                                                                                                                                                                                                                                      |
| **dmesg -n** _#_       | Controls which error messages are sent to the console. For example, **dmesg -n 1** sends only the most critical errors (0 and 1) to the console. Other messages are still logged in the log files.                                                                                                                                                                                                                             |
| **last**               | Shows all users who have logged in to and out of the system, as well as listing every connection and runlevel change (for example, the contents of the **/var/log/wtmp** file).                                                                                                                                                                                                                                                |
| **faillog  <br>lastb** | Shows all failed login attempts on the system (for example, the contents of the **/var/log/btmp** file or **/var/log/faillog** file, depending on the distribution).                                                                                                                                                                                                                                                           |
| **lastlog**            | Shows a list of the dates and times for the last login for each user.                                                                                                                                                                                                                                                                                                                                                          |
| **logger**             | Changes the message severity and where logged messages are sent.                                                                                                                                                                                                                                                                                                                                                               |
| **logrotate**          | Manages, compresses, renames, and deletes log files based on specific criteria (such as size or date).                                                                                                                                                                                                                                                                                                                         |
| **sar**                | Views system statistics. **sar** is short for System Activity Report. It comes as part of the **sysstat** (System Statistics) package. When used alone, it returns CPU statistics. Common options include the following:<br><br>- **-A** displays all information.<br>- **-b** displays I/O statistics.<br>- **-B** displays swap statistics.<br>- **-f /var/log/sa _filename_** displays information from the specified file. |

#### Logrotate
The logrotate utility automatically manages, compresses, renames, and deletes log files based on certain criteria, such as size or date. On most distros, it:
- Automatically runs each week as a cron job to periodically maintain system logs. Old logs are renamed with a numbered extension, and logs are deleted after four weeks. 
- Uses /etc/logrotate.conf as the main config file
- Uses scripts in /etc/logrotate.d to overwrite the settings in /etc/logrotate.conf

|Command|Function|Examples|
|---|---|---|
|**compress**|Compresses old log files using **gzip** .||
|**maxage**|Removes rotated logs that are older than the specified number of days.|**maxage 180** deletes every rotated log older than 180 days.|
|**dateext**|Uses a daily extension on archived files using **file.YYYYMMDD** format.|Uses a daily extension on archived files using a _file.YYYYMMDD_ format.|
|**rotate**|Specifies the number of times to rotate the log before deleting it.|**rotate 5** rotates the log file five times and then removes it.|
|**size**|Rotates or removes log files based on file size as follows:<br><br>- **size k** specifies the size in kilobytes.<br>- **size** **M** specifies the size in megabytes.<br>- **size** **G** specifies the size in gigabytes.|**size 100M** deletes or rotates files larger than 100 megabytes.|
|**notifempty**|Prohibits empty logs from being rotated.||
|**missingok**|Prevents errors from being displayed for missing log files.||
|**create**|Creates a log file with a name identical to the one just rotated. The command specifies the mode (permissions) of the file as well as the owner and group for the file.|**create 744 root root** creates a file with read, write, and execute permissions for the owner and read permission for the group and everyone, specifies root as the file owner, and specifies root as the group.|
|**postrotate**|Indicates the start of script commands to be executed after log files are rotated. The term endscript must be used to indicate the end of the script.||

### Resource Monitoring
Resource monitoring exists to keep track of conditions on network resources and ensure those resources perform optimally. Monitoring helps to 
1. identify problems 
2. Identify the source of those problems
3. Identify situations that indicate potential problems
4. Identify resources that might need to be upgraded or changed

**Automatic Bug Reporting Tool (ABRT)**
ABRT is a suite of tools that helps users detect, analyze, report, and resolve application crashes.
When a system crash occurs, ABRT:
- Collects data about the system
- Produces backtrace from the core dump
- Automatically genereates and sends reports
- Creates a bug ticket
- Identifies and makes available knowledge-badse articles relevant to the problem
- Identifies software updates that resolve the issue
You can install it with 
	yum install abrt-cli
	yum install abrt-desktop

| Component      | Function                                                                                                                                                                                                                                                                                                                                                                                                      |
| -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **abrt**       | The ABRT utility consists of a daemon and a collection of tools for handling crashes and monitoring logs for errors.                                                                                                                                                                                                                                                                                          |
| gnome-abrt     | GUI application for problem management and reporting.                                                                                                                                                                                                                                                                                                                                                         |
| libreport      | A generic library that provides an API for reporting problems to different entities such as email, bugzilla, faf, scp upload, etc. By default, the notifications are sent to root at the local machine. You can use the conf file to change where notifications are sent.                                                                                                                                     |
| faf            | A crash-collecting server, also known as the ABRT server. It provides accurate statistics of incoming reports and acts as a proxy in front of issue tracking software, such as bugzilla. It’s designed to receive anonymous μReports and to find similar information among them.<br><br>For known issues, it generates responses with links to faf’s problem page, an issue tracker, or knowledge base entry. |
| satyr          | Algorithms for program failure processing, analysis, and reporting. More specifically, satyr:<br><br>- Generates a description of the failure from various stack traces.<br>- Analyzes stack traces of failed processes.<br>- Discovers the thread that caused the failure, in multi-threaded stack traces.<br>- Generates a failure report in a specified format.<br>- Sends the report to a remote machine. |
| retrace server | Provides dump analysis and backtrace generation service over a network using HTTP protocol. It is currently being merged to faf.                                                                                                                                                                                                                                                                              |
| µReports       | Micro reports, µReports, are small, machine readable reports used for automated reporting. They identify the operating system, versions of software running when the system crashed, information about the call stack at the time of the crash, and a stack trace, or multiple stack traces in the case of multi-threaded programs. No private data is allowed in the report.                                 |

**ABRT Tools and Commands**
abrt-cli list
	Lists all crashes on a machine
abrt-cli list -d \<ID_OR_PATH>
	Displays detailed report data about a particular problem
abrt-cli report \<ID_OR_PATH>
	Reports a problem
abrt-cli remove \<ID_OR_PATH>
	Deletes a problem

**CPU Monitoring and Configuration**
CPU monitoring involves gathering information such as architecture, vendor name, model, number of cores, and speed of each core. The table below describes some of the Linux CLI commands you can use to monitor your CPU.

/proc/cpuinfo
	Displays details about individual CPU cores and outputs content with less or cat.

uptime
	Displays the current time, how long the system has been running, how many users are logged on, system load averages for the past 1, 5, and 15 minutes. Load avg of 1 means the CPU is keeping up with the demand or is 100% utilized. Less than 1 means the CPU is underutilized. Any number greater than 1 indicates the CPU is overutilized and has been asked to do more than it can do at a time. 
	-s sees when the server was started date/time
	-p simplifies for how long the system has been running

sar 
	(system activity report)
	/etc/cron.d/sysstat
	/var/log/sa
	You can use sar to view
		- Collective CPU usage
		- Individual CPU usage
		- Memory used and available
		- Swap space used and available
		- Overall I/O activities of the system
		- Individual device I/O activities
		- Network statistics
	Provides an overview of the computer	

sysctl -a
	lets you control the kernel parameters at runtime

idle
	Shows which users are logged in and their cumulative CPU usage

top
	Shows CPU usage in real time

htop
	Shows CPU usage in real time, but is prettier!

free
	Shows free memory usage or something

iostat
	Also good!
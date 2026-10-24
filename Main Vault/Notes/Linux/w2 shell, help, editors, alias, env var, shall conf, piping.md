### 2.01 Linux Shell
- The UI is the method by which the end user communicates with the operating system
- Linux distros usually include two types of UI; the command line interface, and the graphical user interface
- Most Linux system administrators use the CLI to dedicate processing power to what's most needed
- The Linux shell provides the CLI/TUI (text user interface (interchangeable terms?)). There are multiple types of command line shells for Linux.
- You can see what shell you're using with the command 'ps -p \$\$'
- You can change shells with the change shell function 'chsh'
- You can access the shell with either a terminal session, or with 'Ctrl+Alt+F1'
- You can press tab to autocomplete something you're typing in CLI with tab completion
- Commands you enter are saved in .bash_history.txt. You have a command history and is updated every time you enter a shell command. You can press the up arrow key to reuse commands really quickly.


| Linux Shell Type | Description                                                                                                                                                                                                                              |
| ---------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| sh               | The Bourne shell is the oldest Linux shell but is not widely used. This shell was developed for UNIX in the 1970s.                                                                                                                       |
| Bash             | The Bourne-Again shell (Bash) is the default shell used by most Linux distributions. It uses commands similar to a UNIX shell. The Bash includes:<br>- Command and file name completion when pressing the Tab key.<br>- Command history. |
| zsh              | The Z shell (zsh) is an improved version of Bash and is available on many Linux distributions.                                                                                                                                           |
| shh              | The Bourne shell (sh) is an earlier version of Bash and is similar in many ways. The sh shell was originally created by Steve Bourne.                                                                                                    |
| ksh              | The Korn shell (ksh) provides scripting features not found in Bash. Ksh was developed by David Korn.                                                                                                                                     |
| csh              | The C shell (csh) uses syntax similar to the syntax used in the C programming language.                                                                                                                                                  |
| tcsh             | The tcsh shell is an improved version of csh. It offers command line editing and completion features that are not available in csh.                                                                                                      |



### 2.02 Linux Help Resources

| Term            | Definition                                                                                                                                  |
| --------------- | ------------------------------------------------------------------------------------------------------------------------------------------- |
| Man Page        | A text-based help file for a specific command, service, or config file that shows a command's syntax, options, related files, and commands. |
| Info Node       | Text-based help information similar to a man page but more verbose and emphasizes how to use a Linux command or utility.                    |
| Whatis database | A database containing short man page descriptions.                                                                                          |
- Commands have dozens of options that modify their behavior
- Man, info, and --help make it so you don't need to go to the internet

##### Manual
- Accessed with the man command
- Derived from the Linux Documentation Project, and automatically installed with your packages
- Stored in MANPATH or man_db.conf
- Has 9 sections
	1. Documentation and Commands
	2. Unix and C System Calls
	3. C Library Routines
	4. Special File Names
	5. File Formats and Conventions
	6. Games
	7. Miscellaneous
	8. Admin Commands and Daemons
	9. Kernel
- Navigation
	- Up and Down Arrows
	- PgUp and PgDn
	- Exit with q
- Results Overview
	- TITLE
	- NAME
	- SYNOPSIS
	- DESCRIPTION
	- AUTHOR
	- REPORTING BUGS
	- COPYRIGHT
	- SEE ALSO
	- Version number and revision date


##### Info Utility
- Organized into nodes
- Accessed with the info command
- More verbose and explanatory than man
- Navigation
	- Up and Down arrows
	- Mouse wheel
	- PgUp and PgDn
	- Home and End
	- n and p
	- Exit with q
Example:
	info ls

##### cd /usr/share/doc
- cd /usr/share/doc
- list the contents
- Each of these subdirectories contain documentation resources
- Seems more cumbersome than man and info

##### --help
- Type a command followed by '--help' for assistance with it
- '\[command] -h' also works
- help \[command]
	- help -s returns a short description for each topic matching pattern
	- help -d returns a short description

##### Whatis Database
- whatis \[keyword]
- apropos \[keyword]
	- Returns a one line man page description



### 2.03 Text Editors

| Attribute            | The vi Editor                                                      | The nano Editor                                                                     |
| -------------------- | ------------------------------------------------------------------ | ----------------------------------------------------------------------------------- |
| Availability         | Included in virtually every Linux distribution.                    | Included in most Linux distributions.                                               |
| Licensing            | BSD License or CDDL (free and open source software).               | GNU General Public License (GPL) (free software license).                           |
| Interface Complexity | Non-intuitive, especially due to the different operational modes.  | Intuitive, mostly due to the onscreen display of keystroke shortcuts.               |
| Feature set          | Full and complex feature set.                                      | Basic feature set.                                                                  |
| Learning curve       | May take a prolonged time to learn due to its complex feature set. | Usually learned quickly, especially for users having experience with other editors. |

##### Vi

| Term               | Definition                                                                                                                                                                                                                                                       |
| ------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| vi / vim           | A utility that creates and modifies text files.                                                                                                                                                                                                                  |
| vi operating modes | Four different modes that the vi text editor operates under<br>1. Command Mode (use vi specific commands)<br>2. Command Line Mode (keyword search, file save, quit)<br>3. Insert Mode (enter text into the Vi editor)<br>4. Replace Mode (replace existing text) |
| vi commands        | Keystroke sequences that control the vi editor                                                                                                                                                                                                                   |
| nano               | A utility that creates and modifies text files                                                                                                                                                                                                                   |
- Vi is packaged with pretty much every Linux distro
- Vim is a newer version with a GUI called gvim
- Steep learning curve
- Non-graphical text editor
- Most widely used
- Uses the 'vi \[filename].txt' command

| Command                          | Function                                                                                                                                         | Mode           |
| -------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------ | -------------- |
| **vi**                           | Starts vi. Type the command at the shell prompt.                                                                                                 | N/A            |
| **vi** **[file_name]**           | Starts vi and immediately begins working on the named file (either a new file or an existing file). Type the **vi** command at the shell prompt. | N/A            |
| **Insert** key  <br>**i  <br>s** | Enters insert mode from command mode.                                                                                                            | Command        |
| **Esc** key                      | Enters command mode from edit mode.                                                                                                              | Insert/Replace |
| **Delete** key                   | Deletes text.                                                                                                                                    | Insert/Replace |
| **Insert** key                   | Toggles between the insert and replace modes while in edit mode.                                                                                 | Insert/Replace |
| **_#_ [line_number]**            | Goes to a specific line in the document while in command mode. For example, **#94** moves the cursor to line 94.                                 | Command        |
| **dw**                           | Cuts a whole word and trailing space.                                                                                                            | Command        |
| **de**                           | Cuts a whole word but omits the trailing space.                                                                                                  | Command        |
| **d$** or **D**                  | Cuts all text following the cursor to the end of the line.                                                                                       | Command        |
| **dd**                           | Cuts a line from the text.                                                                                                                       | Command        |
| **p**                            | Places text in memory into the document.                                                                                                         | Command        |
| **u**                            | Undoes the last action.                                                                                                                          | Command        |
| **O**                            | Opens a new line above the current line.                                                                                                         | Command        |
| **o**                            | Opens a new line below the current line.                                                                                                         | Command        |
| **Ctrl+g**                       | Displays the file name, the total number of lines in the file, and the cursor position.                                                          | Command        |
| **/[term]**                      | Searches forward for all instances of a term. Press n to go to the next term and N to go to the previous term.                                   | Command        |
| **?[term]**                      | Searches backward for all instances of a term. Press n to go to the previous term and N to go to the next term.                                  | Command        |
| **yy**                           | Copies a line of text into memory.                                                                                                               | Command        |
| **a**                            | Appends text after the cursor.                                                                                                                   | Command        |
| **A**                            | Appends text after the current line.                                                                                                             | Command        |
| **C**                            | Changes text from the current cursor position to the end of the line.                                                                            | Command        |
| **cc**                           | Changes text of the entire line.                                                                                                                 | Command        |
| **ZZ**                           | Saves the current file and exits vi.                                                                                                             | Command        |
| **h**                            | Moves the cursor one space to the left.                                                                                                          | Command        |
| **j**                            | Moves the cursor down a line.                                                                                                                    | Command        |
| **k**                            | Moves the cursor up a line.                                                                                                                      | Command        |
| **l**                            | Moves the cursor one space to the right.                                                                                                         | Command        |
| **z**                            | Exits without saving.                                                                                                                            | Command        |
| **:**                            | Enters command line mode from command mode.                                                                                                      | Command        |
| **w**                            | Saves the current document.                                                                                                                      | Command line   |
| **w** **[file_name]**            | Names and saves the file.                                                                                                                        | Command line   |
| **w![file_name]**                | Overwrites the file.                                                                                                                             | Command line   |
| **q**                            | Exits vi. This produces an error if the text was modified.                                                                                       | Command line   |
| **q!**                           | Exits vi without saving.                                                                                                                         | Command line   |
| **wq** or **exit**               | Saves the document and exits vi.                                                                                                                 | Command line   |
| **e!**                           | Reloads the file from the last saved version. This discards all edits and reloads the last saved version of the file into vi.                    | Command line   |

Command Mode
- You can't edit the file
- Entered by pressing the escape key
- Default

Insert Mode
- Entered by pressing
	- Insert (toggles between this and replace mode)
	- i
	- o
	- s
	- a

Command Line Mode
- Entered from command mode by pressing the colon key
- To save a file, type :w \[filename]
- To exit a file, type :q
- To quit without saving, type :q!
- You can overwrite an existing file with :w!
- You can save and quit with :wq
- You can search for text with '/text_to_find'
- You can make it case insensitive by adding \c to the end or by running the command :set ignorecase
- You can search and replace with ':s/\[find]/\[replace]'
- You can cut and paste somehow I missed it

Replace Mode
- Entered by pressing Insert (toggles between this and insert mode)

##### Vim
- You can't begin adding text until you exit command mode
- Switch to insert mode with insert key or by pressing I or S
- It's almost entirely the same with a couple small differences I can figure out later

##### Nano
- I'm getting tired
- My brain is fried
- I want to do something else my god
- Easier to use I believe
- I'm genuinely incapable of focusing on this anymore
- It's 2:30 I've been at this for hours
- I have other things to do with my time than this

|Shortcut|Function|
|---|---|
|^G  <br>(Ctrl+G)|Displays the help text, which includes a list of all keyboard shortcuts.|
|^X  <br>(Ctrl+X)|Closes the current buffer or exits from nano.|
|^O  <br>(Ctrl+O)|Writes the current buffer (or the marked region) to disk.|
|M-Space  <br>(Alt+Space or  <br>Esc+Space)|Goes back one word.|
|^Space  <br>(Ctrl+Space)|Goes forward one word.|
|M-A  <br>(Alt+A or Esc+A)|Marks text starting from the cursor position.|
|M-6  <br>(Alt+6 or Esc+6)|Copies current line (or marked region) and stores it in cutbuffer.|
|^K  <br>(Ctrl+K)|Cuts current line (or marked region) and stores it in cutbuffer.|
|^U  <br>(Ctrl+U)|Uncuts (paste) from the cutbuffer into the current line.|
|^W  <br>(Ctrl+W)|Searches forward for a string or a regular expression.|
|^\  <br>(Ctrl+\)|Replaces a string or a regular expression.|

### 2.04 Aliases
Overview
- Used in Linux to provide shortcuts for commands
- Can add parameters to commands
- How to use aliases to add simple substitutes
- System admin defines aliases
- Default aliases differ from distro to distro
- Alias disappears after you close the terminal
- /etc/bashrc/.bashrc usually contains default aliases that will persist if you place them there
	- /etc/profile applies to all users
	- .profile is specific to one user
	- .bashrc also works for non-login so it doesn't really work for login specific stuff

Common Aliases
- dir --> ls -l
- ll --> ls -l
- la --> ls -a
- lla --> ls -al

Creating an Alias
- alias ld = 'ls - d'
- Combine multiple commands into one alias with semicolons.
- Create a persistent alias by editing /etc/bashrc/.bashrc with nano and add user specific aliases

Seeing defined aliases
- alias

Remove Alias
- unalias alias
- Returns if it's persistent


### 2.05 Environment Variables
Overview
- They define the shell environment
- A variable is a bucket that can store a value and that has a name
- Two kinds: user-defined variables and environment variables
- Environment variables are generated automatically


##### Important Files
- /etc/shadow
	- Contains encrypted passwords
- /etc/passwd
	- Contains account information
- /etc/group
- /etc/profile
	- System wide boot file

| Variable      | Description                                                                                                                                                                                                                                                              |
| ------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| SHELL         | The user's login shell.                                                                                                                                                                                                                                                  |
| DISPLAY       | The location where Windows output is displayed.                                                                                                                                                                                                                          |
| ENV           | The location of the configuration file for the current shell.                                                                                                                                                                                                            |
| HISTSIZE      | The number of lines or commands that are stored in a history list while your shell session is ongoing.                                                                                                                                                                   |
| HOME          | The absolute path of the user's home directory.                                                                                                                                                                                                                          |
| HOSTNAME      | HOSTNAME is identical to HOST, but is only used on certain distributions.                                                                                                                                                                                                |
| LOGNAME       | The current user's username.                                                                                                                                                                                                                                             |
| MAIL          | The path to the current user's mailbox file.                                                                                                                                                                                                                             |
| OLDPWD        | The directory the user was in prior to switching to the current directory.                                                                                                                                                                                               |
| PATH          | The directory paths used to search for programs and files.<br><br>- Use a colon to separate entries in the PATH variable.<br>- Do not include a period (.) in the PATH variable. A period indicates that the working directory is in the path and poses a security risk. |
| PWD           | The path of the current working directory.                                                                                                                                                                                                                               |
| LANG          | The language the operating system uses.                                                                                                                                                                                                                                  |
| TERM          | The type of terminal to emulate when running the shell.                                                                                                                                                                                                                  |
| USER          | The current logged in user.                                                                                                                                                                                                                                              |
| BASH          | The location of the Bash executable file.                                                                                                                                                                                                                                |
| BASHOPTS      | The list of options that were used when Bash was executed.                                                                                                                                                                                                               |
| BASH_VERSION  | The Bash version being executed in a readable form.                                                                                                                                                                                                                      |
| BASH_VERSINFO | The Bash version in machine-readable output.                                                                                                                                                                                                                             |
| EUID          | The current user's ID number.                                                                                                                                                                                                                                            |
| HISTFILE      | The filename where past commands are stored.                                                                                                                                                                                                                             |
| HISTFILESIZE  | The number of past commands that HISTFILE stores for multiple sessions.                                                                                                                                                                                                  |
| OSTYPE        | The type of operating system (usually Linux).                                                                                                                                                                                                                            |
| PS1           | The characters that the shell uses to define what the shell prompt looks like.                                                                                                                                                                                           |
| COLUMNS       | The number of columns being used to draw output on the screen.                                                                                                                                                                                                           |
| LINES         | The number of lines being used to draw output on the screen.                                                                                                                                                                                                             |
| UID           | The current user's user ID.                                                                                                                                                                                                                                              |
Managing Environmental Variables
- `echo $` can see what these variables store
- Run `env` to see all of your environmental variables
- To change an environment variable, enter the name, an equal sign, and the new value. It'll only apply to the current shell session unless you enter `export <variable name>`. If you want it to persist beyond system reboot, you need to change a bash file.
- ~/.bash_profile is what you need to edit to make it persist

|Command|Function|Example|
|---|---|---|
|**[name]=[value]**|Creates a new shell variable with an assigned value or changes the value of an existing variable.  <br><br>To append information to a variable instead of replacing it, include the current variable in the command. (See example.)  <br>Changing the value of an environment variable will change it for the current shell session and any subsequent child processes.|**TRAINING="TestOut"  <br>PATH=$PATH:/bin/additionalpath**|
|**export [name]=[value]**|Creates a new environment variable for the current shell session and any subsequent child processes.|**export TRAINING="TestOut"**|
|**export [name]**|Exports an existing shell variable to make it an environment variable for the current shell session and any subsequent child processes.|**TRAINING="TestOut"  <br>export TRAINING**|
|**declare -x [name]=[value]**|Creates a new environment variable for the current shell session and any subsequent child processes (functionally equivalent to **export [name]=[value]** ).|**declare -x TRAINING="TestOut"**|
|**declare -x [name]**|Exports an existing shell variable to make it an environment variable for the current shell session and any subsequent child processes (functionally equivalent to **export [name]** ).|**TRAINING="TestOut"  <br>declare -x TRAINING**|
|**export -n [name]**|Removes the export property of an environment variable, making it a shell variable.|**export -n TRAINING**|
|**declare +x [name]**|Removes the export property of an environment variable, making it a shell variable (functionally equivalent to **export -n [name]** ).|**declare +x TRAINING**|
|**echo $[name]**|Displays the contents of an environment variable (or any variable).|**echo $TRAINING**|
|**printenv**|Displays a list of the current environment variables.|**printenv**|
|**env**|Displays a list of the current environment variables.<br><br>You can also use the **env** command to run a command using temporarily manipulated environment variables.|**env**|
|**export -p**|Displays a list of all exported variables and functions.|**export -p**|
|**set**|Displays a list of all environment variables, shell variables, local variables, and shell functions.<br><br>You can also use the **set** command to set or unset values of shell options and positional parameters.|**set**|
|**unset [name]**|Removes the variable and its value independent of whether the variable is an environment variable or a shell variable.|**unset TRAINING**|


|Variable Type|Typical Source|Naming Convention|Inherited by Child Processes|
|---|---|---|---|
|Environment|Inherited from a parent process. It may be the system process that passes environment information gathered from a variety of system files and settings.|Uppercase|Yes|
|Shell|Generated by shell startup scripts.|Uppercase|No|
|User|Created by a user at the shell prompt or added when scripts that are defined in a user's profile are run.|Lowercase|No|
|Local|Defined in scripts and in script functions.|Lowercase|No|


### 2.06 Shell Configuration Files
Overview
- Customize your bash environment with these
- These files are scripts whenever the bash session runs
- They depend on the distro
- Non login shells
	- /etc/bashrc
		- Settings for everyone
		- Non login
	- /etc/bash.barshrc 
	- ~/.bashrc
		- Settings for just the user
		- Non login
- Login shells only
	- The stuff in /etc/profile
	- ~/.bash_profile
		- Highest priority
	- ~/.bash_login
		- Second Highest Priority
	- ~/.profile
		- Third Priority
	- ~/.bash_logout

| Configuration File                                    | Run by                  | Shell Type                                                                                                 |
| ----------------------------------------------------- | ----------------------- | ---------------------------------------------------------------------------------------------------------- |
| **/etc/bashrc** or  <br>**/etc/bash.bashrc**          | All users               | Non-login                                                                                                  |
| **~/.bashrc**                                         | The specified user only | Non-login<br><br>On most Linux distributions, this file is also called by login shell configuration files. |
| **/etc/profile**                                      | All users               | Login                                                                                                      |
| ***. sh files in the  <br>/etc/profile.d/ directory** | All users               | Login<br><br>On most Linux distributions, this file is also called by non-login shell configuration files. |
| **~/.bash_profile**                                   | The specified user only | Login                                                                                                      |
| **~/.bash_login**                                     | The specified user only | Login                                                                                                      |
| **~/.profile**                                        | The specified user only | Login                                                                                                      |
| **~/.bash_logout**                                    | The specified user only | Login<br><br>This file is only run as the user logs out (runs the **exit** command).                       |
Login Shell
- In use if you're in a text based login screen
- Run after the user successfully logs in using a user ID and password
- Created at bootup

Non-Login Shell
- You didn't have to log in to access the cmd
- Already logged in to get into the GUI
- Non-login shells run when a user opens a shell after first authenticating with a user ID and password


### 2.07 Redirection, Piping, Command Sub
| Term                 | Definition                                                                                                                            |
| -------------------- | ------------------------------------------------------------------------------------------------------------------------------------- |
| Standard stream      | Preconnected input and output communication channels available to Linux shells and processes.                                         |
| stdin                | A standard stream that provides data that is typically streamed from the keyboard.                                                    |
| stdout               | A standard stream that accepts normal output information to be streamed to the console screen or shell window.                        |
| stderr               | A standard stream that accepts normal error information to be streamed to the console screen or shell window.                         |
| Redirection          | The process of modifying a shell command to divert the standard input, output, and error streams to locations other than the default. |
| Piping               | The process of redirecting the output from one command to be the input of another command.                                            |
| Here documents       | A block of text that is redirected as input to a command.                                                                             |
| Command substitution | A feature of the bash shell that substitutes the output of one shell command as the arguments for another shell command.              |
##### Redirection
Overview
- stdin (0)
	- Controls how data is input
	- Standard input that is sent into a command for it to process
- stdout (1)
	- Control output
	- Normal screen output of a command
- stderr (2)
	- Control output
	- Assigned to output in case of errors
- You can redirect input and output from and to text files
- Linux uses the less than symbol to take input and provide it to a command
- 1> is for input
- 1> is used for output
- 2> is used for errors
- This will overwrite text files, so you should use the appending syntax
- 1>> is for input appending
- 2>> is for output appending 
- 3>> is for error appending 
- You can use an ampersand to do two redirections

|Standard Stream|File Descriptor|Associated Device|
|---|---|---|
|stdin|0|Keyboard|
|stdout|1|Console screen or graphical shell window|
|stderr|2|Console screen or graphical shell window|

| Command Operator             | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          |
| ---------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **>** and **1>**             | Redirects command output that is normally sent to stdout to the file name that follows the operator. The 1 is implied so that **>** and **1>** are functionally identical.<br><br>- If the file that follows the operator exists, it is overwritten.<br>- If the file doesn't exist, it is created.<br>- If there is no output generated by the command, the file will be empty.                                                                                                                                                     |
| **2>**                       | Redirects command output that is normally sent to stderr to the file name that follows the operator. The **2** is mandatory.<br><br>- If the file that follows the operator exists, it is overwritten.<br>- If the file doesn't exist, it is created.<br>- If there is no error generated by the command, the file will be empty.                                                                                                                                                                                                    |
| **>>** , **1>>** and **2>>** | The **>>** operator functions in the same way as the **>** operator except that any output/errors are appended to the file that follows the operator.<br><br>- The **>>** and **1>>** operators appends the output sent to stdout.<br>- The **2>>** operator appends the output sent to stderr.<br>- If the file that follows the operator exists, it is appended with the output/error.<br>- If the file doesn't exist, it is created.<br>- The file will be not be appended if there is no output/errors generated by the command. |
| **&>**                       | Redirects both command output that is normally sent to stdout and command errors that are normally sent to stderr to the file name that follows the operator.<br><br>- As part of a command, **&> myfile.txt** is equivalent to **> myfile.txt 2> &1** or **> myfile.txt 2> myfile.txt** .<br>- File creation follows the rules for the **>** operator.                                                                                                                                                                              |
| **&>>**                      | The **&>>** operator functions in the same way as the **&>** operator except that both output and errors are appended to the file that follows the operator.<br><br>- As part of a command, **&>> myfile.txt** is equivalent to **>> myfile.txt 2>> &1** (where **&** indicates that what follows is a file descriptor and not a filename) or **>> myfile.txt 2>> myfile.txt** .<br>- File creation follows the rules for the **>** operator.                                                                                        |
| **<** and **0<**             | Redirects command input that is normally read from stdin so that it is read from the file name that follows the operator. The 0 is implied so that **<** and **0<** are functionally identical.<br><br>- If the file that follows the operator exists, it is used as input.<br>- If the file doesn't exist, an error is shown.<br>- If there is no input needed by the command, the file is ignored.                                                                                                                                 |
Examples
- Storing the date and time in a text document
	- `date 1>date-and-time.txt`
- Redirecting an error message to a text file
	- `ls non-existing-file 2>errmsg.txt`


##### Piping
Overview
- Takes the output from one command and uses it as input for another
- `command 1 | command 2`
	- Command 1's output is moved into Command 2's input
	- ListAuthors | SortList returns a list of sorted authors
- Two pipes is a logical `OR` operator
- `command 1 || command 2`
	- If command 1 doesn't work, run command 2

Tee
- Tee basically takes a command and also outputs it to the text file
- Text_File_Command | tee

|Example|Result|
|---|---|
|**ls /bin \| tee binfiles.txt**|Displays the files and directories contained in the /bin directory on the console screen (or shell window) and writes the same information to the binfiles.txt file.|
|**ls -1 *.txt \| wc -l \| tee count.txt**|Pipes a one-column list of files that end with _.txt_ in the current directory to the wc (word count) command and then take that output, which gives the number of files in the list, and pipes that to the tee command that displays this number on the console screen (or shell window) and writes the same number to the count.txt file.|
**Device Files Often Used with Redirection and Piping**
Device files are file-like access points to hardware devices. There are two device files that are often used with redirection and piping: /dev/tty and /dev/null

| Device File      | Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| ---------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| **/dev/tty**     | The first terminals were Teletype (abbreviated as _tty_ ), which can be compared to a remote controlled typewriter. The /dev/tty device file is associated with the computer's controlling terminal or the shell's window.<br><br>- Data can be both written to and read from this file.<br>- Text written to this file is displayed on the console monitor's screen or shell window.<br>- Text read from this file originates from the console's keyboard.<br>- The **/dev/tty** device file is similar to a combination of stdin and stdout. Both stdin and stdout are accessed as data streams, whereas **/dev/tty** is accessed like a file. |
| **/dev/null**    | The /dev/null device file is associate with a null device. A null device is commonly used for disposing unwanted output streams.<br><br>- While a command can read from **/dev/null** , commands typically write unwanted output or unwanted error messages to **/dev/null** .<br>- A slang word for the **/dev/nul** device file is bit bucket.                                                                                                                                                                                                                                                                                                 |
| **/dev/zero**    | Similar to /dev/null, /dev/zero discards any input. It also returns a "0" for however many times it is accessed. It is most commonly used for:<br><br>- Initializing a new block device<br>- Overwriting existing data                                                                                                                                                                                                                                                                                                                                                                                                                           |
| **/dev/urandom** | Returns a pseudo-random number. Frequently used when performing cryptographic (encryption) tasks.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                |
##### CMD Substitution
Overview
- Command Substitution creates a child process that runs a command pipes the output back into words in the shell. It then starts a second process that uses the output from the first command
- 128KB limit. Can return error if too many arguments
- Breakdown of command substitution in action
	- `printf "The date and time is: $(date)\n"`
	- The shell creates a child process and runs the $(date) command.
	- The output from the child process is redirected back to the shell but is not parsed.
	- The $(date) operator in the original command is replaced with the output from the child process.
	- Another new process is created that runs the printf command with the replaced text.

Xargs
- Breakdown of xargs in action
	- `find /home -name *~ | xargs rm`
	- This will search the names of files in /home for anything that ends with a tilde
	- That output will then be piped into the xargs command, which will process the arguments 128 KB at a time to prevent overflow
	- The arguments are moved from xargs into the input for rm
	- All in all, every file in home that ends with a tilde will be removed



| more
	output page by page

| less
	output scrollable


### Bash Shell Scripting
A test file that contains a series of commands. Each command goes on a different line. 

**Starting and Ending a Script**
\#!/bin/bash
	Each shell script's first line must specify which shell the script is running under. 

exit 0
	used to end the script


**Syntax**
Comments are made with the \# sign

echo presents text to the user

Variables
	read VARNAME creates a variable that is read from the console input
	$VARNAME is used to reference the created variable later
	You can declare variables without specifying a datatype with something like PATH=\$PATH:\$NEWPATH
	You can also declare them with the declare command. -i makes it an integer

| Command            | Description                                                                                                                                                                                                                                                               | Examples                                                                                                                                                                                                  |
| ------------------ | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **time _command_** | The output shows three values as follows:<br><br>- real - The time from the moment the Enter key was pressed until the moment the command is completed.<br>- user - The amount of CPU time spent in user mode.<br>- system - The amount of CPU time spent in kernel mode. | **time wget wget https://wordpress.org/latest.zip** use the **wget** command to download the zip file, but also displays the time it took.<br><br>## real     0m1.604s user    0m0.042s sys      0m0.099s |

**Executing**
Use one of the following methods to run the script:
- Add the folder that contains the script to the **PATH** environment variable; then enter the script name at the shell prompt.
   - Save the script in a folder that is already in **PATH** , such as /usr/bin or /bin; then enter the name of the script.
   - Type the full path name to the script to run it from anywhere.
   - Type **./ _script_name_** to run the script if it resides in the current directory. (./ indicates the present working directory.)


**Other**
Output is sent to stout. 



### Shell Env., Bash Variables/Parameters
Linux creates a non-interactive shell whenever a script is run. 

printenv displays environment variables but not shell variables
set displays both

**Scripts and Environment Variable Inheritance**
To run a script from a parent Bash shell:
- A child process is created.
- The child process opens a Bash shell.
- The script runs in the child Bash shell.

The child shell inherits environment variables from its parent process.
- A copy of the parent shell’s environment variables is given to the child shell.
- Any environment variable added to the parent shell after the child shell is created won’t be available to the child shell.
- The child shell can manipulate these environment variables without affecting the parent’s environment variables.

**Commands for Environment Variables**

| Command                                | Description                                                                                                                                                                                                                    | Examples                                                                                                                                                                         |
| -------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **printenv**                           | When an environment variable name is added as an argument, **printenv** displays the environment variable's value.<br><br>When no arguments are added, **printenv** displays a list of environment variables and their values. | **printenv PATH**  <br>This command displays the value of the PATH environment variable.<br><br>**printenv**  <br>This command lists all environment variables and their values. |
| **_variable name_=_value_**            | Creates a shell variable with the given name and value.                                                                                                                                                                        | **training=TestOut**  <br>This command creates the shell variable with the name of "training" that has the value "TestOut".                                                      |
| **export _variable name_**             | Converts a shell variable into an inheritable environment variable.                                                                                                                                                            | **export training**  <br>This command converts the training variable into an environment variable.                                                                               |
| **declare -x _variable name_=_value_** | Creates and exports an environment variable at the same time.                                                                                                                                                                  | **declare -x training=TestOut**  <br>This command creates an environment variable named "training" that has the value "TestOut".                                                 |
**Positional Parameters**
Special variables that contain the arguments given when the shell is invoked. They're named with digits like \$1, \$2, \$3, etc.

**Special Parameters**
Their values are set and maintained by the Bash shell

|   |   |
|---|---|
|Special  <br>Parameter|Description|
|*|The positional parameters as a single text string|
|@|The position parameters as an array|
|#|The number of positional parameters|
|?|The exit status of the last executed command|
|-|The option flags from the last set command|
|$|The process ID (PID) of the shell|
|!|The process ID of the last background job|
|0|The name of the shell or shell script|
|_|The last argument of the previous command|

**User Variables**
Created with declare

**Integer Variables and Shell Arithmetic**
Created with declare -i for making integers
You can do + - \* / for basic arithmetic

**Arrays**
There are two kinds of arrays: indexed and associative. 
Indexed arrays are created using declare -a. Each element has an index starting at zero.
Associative arrays are created with declare -A. Each element of the array is accessed using the variable name, the bracketed element name, and braces. 

**Shell Expansions**
Variable expansion is known as parameter expansion and using the ${} construct. 
Command expansion is also known as command substitution, and uses the $() construct. It uses the output of a command to replace the command itself. The command within the parentheses is run, and the output is substituted. 


### Bash Scripting Logic
Now we get into some command structures finally. 

if statements
```
if condition then
	commands
elif condition then
	commands
else
	commands
fi
```

The test command can be used within an if statement to check if a condition is true or false. 
	-d tests if a dir exists
	-e tests if a file exists
	-f tests whether a regular file exists
	-G tests whether the specified file xists and is owned by a specific group
	-h or -L tests whether the specified file exists and if it's a symbolic link
	-O tests whether the file exists and is owned by a specific user
	-r tests whether the specified file exists and if the read permission is granted
	-w does it exist, is the write permission granted
	-x does it exist, is the execute permission granted

case/esac (switch statement)
```
case variable in 
	val1)
		commands
		;;
	val2)
		commands
		;;
	val3)
		commands
		;;
esac
```

looping
```
while condition do
	commands
done

until condition do
	commands
done

for i in {1..10} do
	commands
done

```

exit codes


### Version Control with Git
|Location|Description|
|---|---|
|Remote repository|The remote Git repository is a copy of your project’s files stored on a remote server.<br><br>- This repository is important for projects that have multiple collaborators.<br>- It gives you a central place to store your team members’ work.<br>- You can create a remote repository on your own Git server, or you can use one of the many Git repositories online.|
|Local Repository|The local Git repository is a copy of the remote repository that’s stored on your computer. The local repository:<br><br>- Stores all additions, changes, and deletions.<br>- Allows you to push all your local changes to the remote repository at the appropriate time.<br>- Allows you to make changes offline and apply changes when you’re connected to the internet.|
|Index|The index is part of the local repository. The index stores the list of files and tracks changes to the files.|
|Development Workspace|This is the folder on your computer where you do your work.<br><br>- You can add new files to your project, modify files, and remove files.<br>- After you make changes to your workspace, you can tell Git to update all the repositories to reflect your changes.|
**Installation**
git init
	Creates a local repository
	Used only once for the initial setup
	Run this command in the folder where your existing project files are located
	Creates a new .git sub directory in your cwd and a new master branch for your project

git clone
	Creates the local working directory
	Adds a .git subdirectory to create the local repository
	Puts a copy of all the project's files onto your computer

git branch
	Creates a new branch for a change. 
	Working in the separate branch makes it harder for you to break the main project with an unstable change.
	You can use git merge to merge the changes, or delete the branch. 


**Management**

| Command        | Description                                                                                                                                                                     |
| -------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **git config** | Sets Git configuration values in configuration files.                                                                                                                           |
| **git add**    | Tells the index to add a file to the next commit for you. This is sometimes called staging the file.                                                                            |
| **git pull**   | Updates the local repository and your development workspace.                                                                                                                    |
| **git fetch**  | Updates just the local repository.                                                                                                                                              |
| **git mv**     | Moves files, like the **mv** command, but the **git mv** command also notifies the index of the change.                                                                         |
| **git cp**     | Copies files or directories, like the **cp** command. Like **git mv** , it also notifies the index of the change.                                                               |
| **git rm**     | Creates a file or directory delete request in the index. The requested file or directory will be removed from your file system and the local Git repository at the next commit. |
| **git status** | Displays the files that have changed in your working directory that haven’t been added to the local index.                                                                      |
**Committing and Pushing**
git commit
	Changes you've indexed will be saved to the local Git repository

git pull
	Pulls or downloads any changes from the remote repository

git merge
	merges the changes from the remote repository

git log
	Displays all of your commits so that you can review the project history and search for specific changes

git push
	Sends your commits to the remote Git repository.
	Gives the rest of your team access to your work. 
	
### Navigation
pwd
	Displays the current working directory

cd
	Changes the present working directory
	cd ..
		Changes to parent dir
	cd ../..
		Changes two levels up in the dir
	cd / 
		Changes to the root dir
	cd ~
		Changes to the home dir

ls
	Displays the contents of a directory
	-a
		Displays all dir contents, including hiddden content
	-l 
		Displays extended information
		Includes owner, modified date, size, and permissions
	-R
		Displays contents of a directory and all of its subdirectories
	-d
		Displays directories but not files
	-r
		Reverses the sort order

echo
	Displays the contents of a variable in Linux
	$PATH
		Displays the current directory path
	$SHELL
		Returns the default or preferred shell
	$0
		Return the current shell type. 
	$MANPATH
		Returns the location of the manual directory




### Directory Mgmt.
mkdir
	Creates a director
	mkdir -p
		Creates all directories within the path when the path doesn't exist

cp
	Copies contents
	cp -r
		Recursively copies subdirectories and files within dir

mv
	Moves or renames directories (and files)
	EX: mv /temp/station ~/doc/
		Moves station from temp to ~/doc
	EX: mv /current/previous
		Renames the dir current to previous
	mv -f
		Overwrites a directory that already exists in the destination directory without prompting
	mv -i
		Prompts before overwriting a directory in the destination directory
	mv -n
		Never overwrites files in the destination directory

rmdir
	Deletes and empty directory

rm
	Removes the directory and file information from the file system
	rm -i
		Prompts before removing
	rm -r
		Removes directories, subdirectories, and files within them
	rm -f
		Eliminates prompt for read-only files and avoids an exit code error if a file doesn't exist



### File Mgmt.
touch
	If the file doesn't exist, touch creates a blank version of hte file.
	If the file does exist, this command updates the file's modification and last accessed time

cp
	Copies files
	cp -f
		Overwrites files that already exist in the destination directory
	cp -i
		Prompts before overwriting a file in the destination directory

mv
	Moves or renames files (and directories)
	mv -f
		Overwrites files that already exist in the destination directory
	mv -i
		Prompts before overwriting a file in the destination directory
	mv -n
		Never overwrites files in the destination directory

rm
	Removes a file or directory
	Doesn't permanently remove data. Use the shred command to do that.
	rm -f
		Deletes with a prompt

cat
	Lets you view changes in a file

shred
	Permanently deletes a file's data

nano
	Simpler to use than the vi ediitor
![[nano cmds.png]]

vi
	Creates and modifies text files. 
	Defacto CMD .txt editor
	Command mode is the initial mode vi uses when started. Provides commands to cut and replace text.
	Command line mode is used to load files, and to save files after editing them in the file system
	Edit mode is the mode that vi uses to write and edit text in the file
		Insert Mode adds text between the preceding and subsequent text
		Replace mode overwrites subsequent text

![[vi cmds.png]]


### Config / ETC.
ps -p \$\$
- Displays the active shell for the CLI

chsh
- Changes the current shell after a restart

su
- Switches user

exit
- Logs out of root user account

uname
- Displays information about the system
	uname -a

whoami
	Displays the name of the active user

history
	Displays your command history

clear
	Clears the shell screen

man
	Type man followed by what you want help with
	Displays which section from the manual the info is from
	Explains what it does and how to use it.
	man -k 
		Lets you search all man pages for a specific search term

### Program Mgmt.
Running Executables
	1. Enter full path to the file
	2. Switch to the directory where the file resides and use ./ to the beginning of the command to specify that it's in the current directory
	3. Add to the PATH environmental file

exec
	Executes an executable to replace the shell process with the new process created by the file


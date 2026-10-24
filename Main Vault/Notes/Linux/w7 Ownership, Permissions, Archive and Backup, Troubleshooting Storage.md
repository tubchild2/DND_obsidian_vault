
### 8.09 Ownership
Ownership determines who controls files
By default, the user that creates a file or dir is the owner. They have read/write/exc priveledges
You can view ownership in properties

The primary group to which the owner belongs is also given ownership
ls -l shows the owner and the owner group (3rd and 4th columns)

Ownership can be modified if you're logged in as the current owner or as root
chown (change owner)
`chown userORgroup fileORdir`

Ownership group can be modified
`chown (leading dot)groupname fileORdir`
chgrp groupname file

Modifying both the owner and the owner group
`chown rtracy.rtracy /tmp/resources.txt`

-R applies recursive ownership changing

| Command   | Function                                                                                                                                                                                                                                                                                                                                                                                            | Example                                                                                                                                                                                                                                                                                                                                                                                                                   |
| --------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **ls -l** | View a long listing of files and directories. The long listing shows the mode of each file and directory along with ownership information.<br><br>The output listed is (from left to right):<br><br>- Permissions<br>- Number of links<br>- Owner name<br>- Group name<br>- Number of bytes in the file<br>- Last modified time<br>- File name                                                      | **drwxr-xr-x 22 root sales 4096 Jun 19 15:01 sales**  <br>  <br>In this example, root is the file owner and sales is the group owner.                                                                                                                                                                                                                                                                                     |
| **chown** | Change the ownership of a file or directory. Be aware of the following options:<br><br>- **-R** changes the ownership of the file recursively throughout the directory tree.<br>- **_user_** changes the file ownership only.<br>- **_user_ : _group_** or **_user_ . _group_** change the user and group ownership of the file.<br>- **: _group_** or **.group** changes the group ownership only. | **chown pmorril /sales/report** makes pmorril the user owner of the /sales/report file.  <br>**chown -R pmorril /sales** makes pmorril the owner of all files in the /sales directory (and below).  <br>**chown pmaxwell:sales /sales/report** makes pmaxwell the user owner and sales the group owner of the file.  <br>**chown :sales -R /sales** makes the sales group the owner of all files in the /sales directory. |
| **chgrp** | Change the group owner of a file or directory.                                                                                                                                                                                                                                                                                                                                                      | **chgrp sales /sales/report** makes the sales group the group owner of the file.                                                                                                                                                                                                                                                                                                                                          |


### 8.10 Permissions
Every file and directory has an inode (index node) that stores information
- Last modified date
- Size
- Data block location
- Permissions
- Ownership
- Mode
	- User permissions (owner)
	- Group permissions (group owner)
	- Other permissions (anyone else on the Linux system who is not an owner or a member of the owning group)

| Permission | Letter Abbreviation | Octal Value | Allowed Actions on Files                                                                                         | Allowed Actions on Directories                                          |
| ---------- | ------------------- | ----------- | ---------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------- |
| Read       | r                   | 4           | Open and read the file                                                                                           | List directory contents if the Execute permission is also present       |
| Write      | w                   | 2           | Edit the file and save the changes                                                                               | Add, delete, and rename files if the Execute permission is also present |
| Execute    | x                   | 1           | Execute the file if it's a program file or a shell script (must be used in conjunction with the Read permission) | Enter the directory and access its contents                             |

**Viewing Permissions**
Permissions are identified with the letter abbreviation (r, w, x) or the octal value that corresponds to the permissions.  

![[Pasted image 20260520135908.jpg]]

- A d preceding the permissions indicates that the object is a directory.
- A dash (-) preceding the permissions identifies a file (the example above is for a file).
- Permissions are grouped according to user, group, or other permissions.
- If a given permission has not been assigned, a dash (-) takes its place in the mode.
- When using numbers to represent permissions, add the numbers together within each permission group. Then string the numbers together. For example, the mode of the file in the graphic above can be represented by the number 764.
- The root user has all permissions to files and directories regardless of the mode settings.

First three characters specify permissions to owner
Second three character specify permissions to the group
Third three character specify permissions to everyone else




PROBLEM
Owner has rwx 7
Group has x 1




**Managing Permissions**
ls -l 
	Displays permissions

chmod
	Changes permissions
	-R does it recursively (all files in a dir)
	Select an entity (u (owner), g (owner group), o (other / everyone else))
	Select a permission (r (read), w (write), x (execute))
	Select a file or directory


|Command|Function|Example|
|---|---|---|
|**ls -l**|View a long listing of files and directories. A long listing displays the permissions assigned to files and directories (among other information).|**drwxr-xr-x** 22 root root 4096 Jun 19 15:01 sales  <br>(This is a directory with 755 permissions assigned.)|
|**chmod**|Change the permissions for the specified file. You can use the following syntax options:<br><br>- **_entity_ + _permission_** adds a permission for a user, group, or other to a file or directory.<br>- **_entity_ - _permission_** removes a permission for a user, group, or other from a file or directory.<br>- **_entity_ = _permission_** sets the permission equal to the permission specified for a user, group, or other for a file or directory.<br>- **decimal_value** sets the permissions for the file according to the numbers represented for each mode entity.<br>- **-R** sets permissions recursively.|**chmod u+x,g+x,o+x myfile** adds the Execute permission to the myfile file for user, group, and other.**  <br>chmod g-w,o-w myfile** removes the Write permission for group and other from the myfile file.  <br>**chmod u=rwx myfile** grants the user Read, Write, and Execute permissions for the myfile file.  <br>**chmod 711 myfile** grants the user Read, Write, and Execute permissions (7) while group and other both receive the Execute permission (1) for the myfile file.|
|**getfacl _file_**|For each file, **getfacl** displays the file name, owner, group, and the access control list (ACL). If a directory has a default ACL, **getfacl** also displays the default ACL. Non-directories cannot have default ACLs.<br><br>## getfacl<br><br>- **-a** displays the file access control list.<br>- **-d** displays the default access control list.<br>- **-c** tells the command to NOT display the comment header (the first three lines of each file's output).<br>- **-e** prints all effective rights comments, even if they're identical to the rights defined by the ACL entry.<br>- **-E** tells the command to NOT print effective rights comments.<br>- **-s** skips files that only have the base ACL entries (owner, group, and others).<br>- **-R** lists the ACLs of all files and directories recursively.<br>- **-L** uses _logical walk_ by following symbolic links to directories. The default behavior is to follow symbolic link arguments and to skip symbolic links encountered in subdirectories. (This is only effective in combination with **-R** .)<br>- **-P** uses _physical walk_ by not following symbolic links to directories. This also skips symbolic link arguments. (This is only effective in combination with **-R** .)<br>- **-t** uses an alternative tabular output format. The ACL and the default ACL are displayed side by side. Permissions that are ineffective due to the ACL mask entry are capitalized. The entry tag names for the ACL_USER_OBJ and ACL_GROUP_OBJ entries are also displayed in capital letters, which helps in spotting those entries.<br>- **-p** tells the command to NOT strip leading slash characters ('/'). The default behavior is to strip leading slash characters.<br>- **-n** lists numeric user and group IDs.<br>- **-v** prints the version of **getfacl** and exits.|**getfacl myfile**<br><br>Output:  <br># file: myfile  <br># owner: cpelfrey  <br># group: admin  <br>user::rw-  <br>group::r--  <br>other::r--|
|**setfacl _file_**|This utility sets access control lists (ACLs) for files and directories.<br><br>## setfacl<br><br>- **-m** modifies the ACL of a file or directory. ACL entries for this operation must include permissions.<br>- **-x** remove ACL entries. It is not an error to remove an entry which does not exist. Only ACL entries without the perms field are accepted as parameters, unless the POSIXLY_CORRECT environment variable is defined.<br>- **-b** removes all extended ACL entries. The base ACL entries of the owner, group and others are retained.<br>- **-k** removes the default ACL. If no default ACL exists, no warnings are issued.<br>- **-n** tells the command to NOT recalculate the effective rights mask. The default behavior of **setfacl** is to recalculate the ACL mask entry, unless a mask entry was explicitly given. The mask entry is set to the union of all owning group permissions and all named user and group entries. (These are exactly the entries affected by the mask entry.)<br>- **-d** tells the command that all operations apply to the default ACL. Regular ACL entries in the input set are promoted to default ACL entries. Default ACL entries in the input set are discarded. (A warning is issued if that happens.)<br>- **-R** applies operations to all files and directories recursively. This option cannot be mixed with **--restore** .<br>- **-L** uses _logical walk_ by following symbolic links to directories. The default behavior is to follow symbolic link arguments and to skip symbolic links encountered in subdirectories. { This is only effective in combination with **-R** and cannot be mixed with **--restore** .)<br>- **-P** uses _physical walk_ by not following symbolic links to directories. This also skips symbolic link arguments. (This is only effective in combination with **-R** and cannot be mixed with **--restore** .)<br>- **-v** prints the version of **setfacl** and exits.|**setfacl -m u:cplefrey:r myfile  <br>**grants the cplefry user Read access to the file named myfile.<br><br>## setfacl -m m::rx myfile|


### 8.14 Archive and Backup
**tar**
Takes a list of specified files and copies them to an archive. You can compress these archives to make what are called "tar balls"
The basic syntax is as follows
	tar \[option] \[file]

Options for tar
- r appends tar files to the end of an archive
- u (update) only appends files newer than copy in archive
- c creates a new archive
- x extracts files from an archive
- t lists what files exist in the archive
- v verbosely lists files processed
- f lets you specify the name of the file you'd like to create
- Compression
	- J compresses with xz utility
	- j compresses with bzip2
	- z compresses with gzip

| Command | Options and Descriptions                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     | Examples                                                                                                                                                                                                                                                                |
| ------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **tar** | \|   \|   \|<br>\|---\|---\|<br>\|**-A**\|Appends one tar file to another archive file.\|<br>\|**-c**\|Creates a new archive.\|<br>\|**-d**\|Identifies differences between the files in an archive file and the same files in the file system.\|<br>\|**-v**\|Displays a list of all files being written into the archive.\|<br>\|**-f**\|Specifies the file to create or unpack. Without this option, tar uses standard input and output as the destination.\|<br>\|**-x**\|Extracts the files. If no destination directory is specified, then tar extracts the files to the current working directory.\|<br>\|**-z**\|Compresses and decompresses a file using the gzip utility (normally named with a .gz extension).\|<br>\|**-j**\|Compresses and decompresses a file using the bzip2 utility (normally named with a .bz2 extension).\|<br>\|**-J**\|Compresses and decompresses a file using the xz utility (normally named with a .xz or .lzma extension.\|<br>\|**-C**\|Changes to a specific directory to extract the files.\|<br>\|**-t**\|Lists the contents of an archive.\|<br>\|**-P**\|Tells tar to not strip the leading / from filenames as they are added to the archive.\|<br>\|**-r**\|Adds files to the end of an existing tar archive.\|<br>\|**-u**\|Adds files to the end of an existing tar archive only if they are newer than the existing files in an archive.\|<br>\|**-X _file_name_**\|Causes tar to exclude the file names contained in the specified file when creating an archive file.\| | **tar -cf /root/tarbackups/oct17backup.tar /home**  <br>Writes a backup of the /home directory to the **/root/tarbackups/oct17backup.tar** file.<br><br>## tar -cvf /root/tarbackups/oct17backup.tar /home<br><br>## tar -xvf /root/tarbackups/oct17backup.tar -C /home |

**Archiving**
Example archival
	tar -cvf \<destination_filename.tar> \<source_dir/file>
	tar -cvf /media/usb/homebak.tar /home

This example copies /home to the external media found in /media/usb/homebak.tar


**Extraction**
Example extraction
	tar -xvf <source.tar>
Extracts to current dir, so make sure to cd first


**Compressing with tar**
Add J, j, or z option. It's good practice to specify the file extension you use. 
If you're decompressing something you compressing with J (xz) add J to the extraction command. 

| Command   | Options and Description                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                  | Examples                                                                                                                                                                               |
| --------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| **gzip**  | \|Option\|Description\|<br>\|---\|---\|<br>\|**-c**\|Writes the file to standard output.\|<br>\|**-d**\|Decompresses the file.\|<br>\|**-l**\|Displays information about files in an archive.\|<br>\|**-r**\|Recursively compresses all files in directories and subdirectories.<br><br>This is the same as the **tar -z** command.\|                                                                                                                                                                                                                                                                                                                    | **gzip file** .tar  <br>Compresses an archive file created with tar. The original uncompressed file is removed.<br><br>## gzip -c file.tar > file.tar.gz<br><br>## gzip -d file.tar.gz |
| **xz**    | \|Option\|Description\|<br>\|---\|---\|<br>\|**-z**\|Compresses a file.\|<br>\|**-d**\|Decompresses a file.\|<br>\|**-k**\|Keeps the original file unchanged.<br><br>This is the same as the **tar -J** command.\|                                                                                                                                                                                                                                                                                                                                                                                                                                       | **xz file**  <br>Compresses the archive file and removes the original file.<br><br>## xz -k file<br><br>## xz -d                                                                       |
| **bzip2** | \|Option\|Description\|<br>\|---\|---\|<br>\|**-z**\|Compresses a file.\|<br>\|**-d**\|Decompresses a file.\|<br>\|**-k**\|Keeps the original file unchanged.<br><br>This is the same as the **tar -j** command.\|                                                                                                                                                                                                                                                                                                                                                                                                                                       | **bzip2 file.tar**  <br>Compresses the tar archive file and removes the original file.<br><br>## bzip2 -k file.tar<br><br>## bzip2 -d                                                  |
| **zip**   | \|Option\|Description\|<br>\|---\|---\|<br>\|**-d**\|Removes a file from the zip archive. When a zip archive includes multiple files, use this option to remove a file from the archive.\|<br>\|**-u**\|Updates the file in the zip archive. The opposite of -d, meaning you can use this option to add a new file to the zip file already created.\|<br>\|**-m**\|Deletes the original files after zipping.\|<br>\|**-r**\|Lets you zip a directory recursively.\|<br>\|**-x**\|Lets you exclude the file's files while creating the zip of multiple files, such as a directory.\|<br>\|**-v**\|Verbose mode or print diagnostic version information.\| | **zip –r _my.zip mydir_**  <br>Will recursively zip the files in the mydir directory. The results are saved to the my.zip file.<br><br>## zip –m my.zip myfile.txt                     |


**cpio**
- Like tar, but slightly different. 
- You attach a list of files to be added
- You specify as a command option what files you want to be added
- You do so with the cat command

cat \<file> | cpio
find
ls

**Using find with cpio**
find . -depth -print | cpio -ov > /media/usb/backup.cpio
- period means current dir
- print means to print the full filenames
- | means to pipe content into cpio
- -o new archive
- -v verbose
- you lost me testout ngl

**Extracting from cpio**
gunzip
	Uses gz to extract files from the archive

**dd utility**
For copying

|Command|Options|Examples|
|---|---|---|
|**dd**|\|Option\|Description\|<br>\|---\|---\|<br>\|**bs=BYTES**\|Read and write up to bytes at a time (the default is 512; overrides ibs and obs)\|<br>\|**cbs=BYTES**\|Convert bytes at a time\|<br>\|**conv=CONVS**\|Convert the file as per the comma-separated symbol list\|<br>\|**count=N**\|Copy only **N** input blocks\|<br>\|**ibs=BYTES**\|Read up to bytes at a time (the default is 512)\|<br>\|**if=FILE**\|Read from **FILE** instead of stdin\|<br>\|**iflag=FLAGS**\|Read as per the comma-separated symbol list\|<br>\|**obs=BYTES**\|Write bytes at a time (the default is 512)\|<br>\|**of=FILE**\|Write to **FILE** instead of stdout\|<br>\|**oflag=FLAGS**\|Write as per the comma separated-symbol list\|<br>\|**seek=N**\|Skip **N** obs-sized blocks at start of output\|<br>\|**skip=N**\|Skip **N** ibs-sized blocks at start of input\|<br>\|**status=LEVEL**\|The level of information to print to stderr - **none** suppresses everything but error messages, **noxfer** suppresses the final transfer statistics, and **progress** shows periodic transfer statistics\||**dd if=/dev/sda of=/dev/sdb**  <br>Will clone one hard disk to another hard disk<br><br>## dd if=hdadisk.img of=/dev/sdb3<br><br>## dd if=/dev/hda1 of=~/partition.img|


### 8.15 Troubleshooting Storage
**Common Storage Issues**
High Latency
Low Throughput
	Measured in iops
Capacity
File System
Hardware
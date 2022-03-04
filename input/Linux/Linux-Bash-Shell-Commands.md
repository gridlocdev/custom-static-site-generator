# Basic Linux Shell Commands

Linux is an operating system made for greater control of the computer. To accomplish this, lots of primary functionality requires usage of a shell or command line.

[Commands from: Hostinger Linux Commands Tutorial](https://www.hostinger.com/tutorials/linux-commands)

## Table of Contents

- [Basic Linux Shell Commands](#basic-linux-shell-commands)
  - [Table of Contents](#table-of-contents)
  - [Basic Commands](#basic-commands)
  - [Advanced Commands](#advanced-commands)

## Basic Commands

| Name | Example | Description |
| --- | --- | --- |
| pwd | ```pwd``` | Prints the current directory path |
| cd | ```cd [directory_name]``` | Changes the directory you're currently in. |
| ls | ```ls``` | Prints the contents of the directory to the console. |
| cat | ```cat [file_name]``` | List the contents of a file |
| cp | ```cp [path/file_name] [directory_path]``` | Copy files to location |
| mv | ```mv [path/file_name] [directory_path]``` | Move files to location |
| mkdir | ```mkdir [directory_name]``` | Creates a directory with the specified name |
| rmdir | ```rmdir [directory_name]``` | Removes a directory |
| rm | ```rm [file_name]``` | Deletes a file |
| touch | ```touch [file_name]``` | Creates a new blank file |
| locate | ```locate [file_name]``` | Searches ALL directories of the filesystem to find the specified item |
| find | ```find [file_name]``` | Searches only the current directory of the filesystem to find the specified item |
| grep | ```grep [file_name]``` | Searches all the text within a file and prints out a highlighted version to the console window |
| sudo | ```sudo apt install [package_name]``` | Do something as an admin user. It's short for 'SuperUser do'. These tasks usually require admin or root permissions. Try not to use it too much, it can break things. |
| df | ```df -h``` | Output how much disk space is currently being used in the current directory |
| du | ```du -h``` | Output how much storage is taken up in the current directory |
| head | ```head [file_name]``` | Output the _first_ x number of lines of a text file |
| tail | ```tail [file_name]``` | Output the _last_ x number of lines of a text file. |
| diff | ```diff [file_1_name] [file_2_name]``` | Compare the contents of a file line by line, and console output lines that do not match |
| tar | ```tar tvf [file_name].tar.gz``` | Compress a set of files together (Usually used for archiving) |
| chmod | ```chmod r+w [file_name]``` | (Change Mode): Change the read / write / execute permissions of files or directories |
| chown | ```chown [user_name] [file_name]``` | (Change Ownership): Change the ownership of a file or directory to another user |
| jobs | ```jobs -l``` | Lists out all currently executing system processes to the console |
| kill | ```kill [process_id]``` | Stops a program's process given the ID of the program |
| ping | ```ping [host_address]``` | Check your connectivity to network host address |
| wget | ```wget [host_address]``` | Download files from the internet (if it's a download link) into the current directory |
| uname | ```uname -a``` | Prints detailed information about your Linux system like machine name, operating system, kernel, etc. |
| top | ```top``` | (Table of Processes): A console output of a Task Manager view. See utilized CPU, running processes, anything you can see in the System Monitor/Task Manager but inside the shell window |
| history | ```history``` | View a list of all of the commands you've entered in the lifetime of the shell window |
| man | ```man [command_name]``` | (Manual): View a description of any command and view a list of its arguments |
| echo | ```echo "Hello, World!"``` | Print text for the given argument into the shell window |
| zip | ```zip [file_title].zip [file_name]``` | Compress your files into a zipped archive |
| hostname | ```hostname``` | View the name of the currently connected network |
| useradd | ```sudo useradd [user_name]``` | Linux is a multi-user system, and these two commands add and remove users |
| passwd | ```passwd``` | Adds or modifies a password for the current user |
| clear | ```clear``` | Clears the console output window |

## Advanced Commands

| Name | Example | Description |
| --- | --- | --- |
| uptime | ```uptime``` | Displays how long the system has been running. Outputs the number of users, and average computational load on the system |
| apt | ```apt install [package_name]``` | Install, update, remove, or manage packages from the primary package manager for Linux (DPKG)  |
| yum | ```yum install [package_name]``` | Install, update, remove, or manage packages from a 3rd party package manager (RPM). Primarily used in a Red Hat based OS |
| lsof | ```lsof``` | (List Open Files): Lists out all of the files that are currently being accessed by processes |
| ss | ```ss -t -a``` | Fully-featured view of network connection information. This helps display information about open sockets and active connections |
| netstat | ```netstat``` | Commonly considered a deprecated and less feature-ful network information tool. It is functionally similar to the ```ss``` command, and shares many common outputs |
| mount | ```sudo mount -l -t [directory_name]``` | Used to attach a local or network drive to be accessed by the Unix-based filesystem |

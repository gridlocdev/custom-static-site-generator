# Main Linux Folders and what they're used for

These are the directories you can find on a standard Linux filesystem and what each of those directories is responsible for.

- [Main Linux Folders and what they're used for](#main-linux-folders-and-what-theyre-used-for)
  - [Table Format](#table-format)
  - [Text Format](#text-format)

## Table Format

| Directory Name | Description | Details |
| --- | --- | --- |
| bin | Application Executables | Contains the binaries to boot and run things |
| boot | Boot Files | Contains files used in booting the operating system |
| dev | Drivers | Contains the device drivers for all of the devices. |
| etc | Configuration | Contains configuration files |
| home | User Folder | The main folder the user interacts with to store and create things |
| var | Changing-Data | Files that change often but still need to be kept on disk storage between boots (Like logs, databases, websites, anything that persists from one boot to the next) |
| opt | Packages | The folder that houses all of your UNIX software add-on packages. |
| proc | In-Memory Data | Creates in-memory temporary files associated with many aspects of the operating system for easy access. It's not stored on disk like other folders are, as it's an in-memory file folder and is stored in the transient memory. |
| mnt | Storage Devices | Mounting point for external storage devices. |
| sbin | Root-Only Programs | Administrative executable programs included in the Unix system by default. These are only made available to the root user. |
| lib | System Helper Programs | Programs that are available by default in Linux outside of the package ecosystem that are accessible to all users. An example is the pwd (Print Working Directory) command. |

## Text Format

- ***bin*** : (Application Executables) Contains the binaries to boot and run things

- ***boot*** : (Boot Files) Contains files used in booting the operating system

- ***dev*** : (Drivers) contains the device drivers for all of the devices.

- ***etc*** : (Configuration) contains configuration files

- ***home*** : (User Folder) The main folder the user interacts with to store and create things

- ***var*** : (Changing-Data) Files that change often but still need to be kept on disk storage between boots (Like logs, databases, websites, anything that persists from one boot to the next)

- ***opt*** : (Packages) The folder that houses all of your UNIX software add-on packages.

- ***proc*** : (In-Memory Data) Creates in-memory temporary files associated with many aspects of the operating system for easy access. It's not stored on disk like other folders are, as it's an in-memory file folder and is stored in the transient memory.

- ***mnt*** : (Storage Devices) Mounting point for external storage devices.

- ***sbin*** : (Root-Only Programs) Administrative executable programs included in the Unix system by default. These are only made available to the root user.

- ***lib*** : (System Helper Programs) Programs that are available by default in Linux outside of the package ecosystem that are accessible to all users. An example is the pwd (Print Working Directory) command.

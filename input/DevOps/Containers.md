# Containers

_Containers_ are lightweight portable environments that you create to run your software on.

A _container_ is a program that runs application code in a secluded area of the operating system. Meaning, that program is completely isolated from and can't see anything in the rest of the processes on the machine.

Containers are just programs designed to run in an enclosed area with bound ports.

## Virtualization

Virtualization is about abstracting the application and its components from the hardware that it runs on. _Containerization_ is one main method of achieving this, while the other is using _Virtual Machines_.

Containers are different from _Virtual Machines_ in that while Virtual Machines are a virtualized version of the entire operating system, containers just represent a sub-section of programs / files, and often times several containers are run inside one virtual machine.

## Drawbacks of traditional bare-metal hosting

Companies hosting their own bare-metal traditional server hosting typically presents a number of challenges for system admins and operations maintenance staff:

- **Maintenance costs** : It often costs lots of money to purchase servers as well as to pay trained professionals to manage those servers.
- **Scaling** : Creating / allocating more computing power to handle increased traffic is often expensive and time-consuming as it means purchasing more servers and more work to configure network connectivity.
- **Disaster recovery** : The method and ability to revive the application back online in the event of an unpredictable outage like a cyber-attack, natural disaster, etc; can often result in loss of critical data / infrastructure, and cause lots of losses for a company.
- **Environment Drift** : Over time, individual tweaks and configuration fixes to servers, can cause unexpected bugs due to the differences in how things are implemented on one server vs another.

## Container Options

**Docker** is the leading industry tool used to manage individual containers.

There are a couple of notable alternative Container tools:

- Podman
- LXC (Linux Containers)
- Containerd

## Container Images

Containers run on an isolated filesystem, which the structure of what it looks like is set up using a **container image**.

A **container image** contains everything that is needed to run an application including:

- All dependencies
- Configuration
- Scripts
- Binaries

Also, it might include:

- Environment Variables
- Default shell commands to run
- etc.

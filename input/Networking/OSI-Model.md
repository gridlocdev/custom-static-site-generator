# OSI Model

The OSI model is a framework that shows each layer in a computer's network stack.

- [OSI Model](#osi-model)
  - [Overview](#overview)
  - [Layers](#layers)
  - [Application Layer](#application-layer)
  - [Presentation Layer](#presentation-layer)
  - [Session Layer](#session-layer)
  - [Transport Layer](#transport-layer)
  - [Network Layer](#network-layer)
  - [Data Link Layer](#data-link-layer)
    - [Link Control Layer](#link-control-layer)
    - [MAC Layer](#mac-layer)
  - [Physical Layer](#physical-layer)

## Overview

The OSI model stands for Open Systems Interconnection (model). It's the world standard for network communications, adopted by all major computer and telecommunication companies.

It defines an independent component layout for how data gets transferred from one computer to another across your network and through the internet.

An easy way to remember the order of all of the layers is to use a mnemonic, or acronym. Here is my favorite:

> **P**lease **D**o **N**ot **T**ouch **S**teve's **P**et **A**lligator

## Layers

> These layers are organized, from top to bottom, for what is closest to the end user all the way to shooting the information down on the network.

- Application
- Presentation
- Session
- Transport
- Network
- Data Link - Switches and logical data transfer
- Physical - Physical wiring that connects stuff together

## Application Layer

> The layer the user interacts with, through programs and user interfaces.

The User is interacting with this layer; this layer includes the computer programs of which self contain the protocols of your message. For example, a web browser like Brave accepts and sends messages via HTTP, while an email browser like Outlook
sends and receives messages via SMTP.

To create and read these messages, the Application Layer relies on the Presentation Layer (Operating System)

## Presentation Layer

> Translate application/program requests into instructions for the computer hardware.

The layer that the Operating System and drivers sit on. It's below programs, but hosts a software that allows those programs to interact with the computer hardware. The Operating System is then responsible for translating those requests to low-level and network operations, such as encryption for transmission via the Session layer.

## Session Layer

> Creates a communication session between computers' software processes.

This layer contains system metadata for:

- How long both parties should wait for a response
- How large is the data that should be sent
- Termination of the session at the end of the communication

## Transport Layer

> Coordinates the data to transfer between end systems.

This layer contains the transmission protocol, such as TCP or UDP. IP and packet direction is handled by the next layer, the Network layer.

TCP is responsible for data delivery once the IP address has been found.

## Network Layer

> Transport the data to the digital address where it needs to go. (IP Addresses)

This is where all the magic happens. Routers operate on this layer. IP addresses, DHCP, NAT, etc.

## Data Link Layer

> Provide the transport for the data to the physical address where it needs to go. (MAC Addresses)

This layer provides the physical network infrastructure (LAN) that navigates the data. This includes switches. Switches then use ARP (Address Resolution Protocol) to store IP addresses and MAC addresses and translate requests between the two.

This layer is made up of two sublayers:

- Link Control Layer (LCL layer)
- MAC Layer (Media Access Control layer)

### Link Control Layer

Manages traffic over the physical medium using a Line protocol. The Line protocol is a specified set of possible bit sequences that will guarantee that two ends of a communication link will be able to pass information between them in an understandable way.

### MAC Layer

It's the Ethernet layer, basically how MAC addresses are translated to ports.

Switches contain a key-value set of data in memory that includes pairs of MAC Addresses and ports.

Once a valid MAC address has been identified in a data string, it routes that data to the appropriate port.

## Physical Layer

> Electrical and physical representation of the system.

Cables, computers, patch panels, etc;. The physical hardware necessary to take the data and send it. No logical operations, just plug-ins from point A to point b.

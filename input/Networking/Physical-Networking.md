# Physical Networking

## Overview

This page is a surface level view of physical-level networking devices and terminology.

- [Physical Networking](#physical-networking)
  - [Overview](#overview)
  - [Connecting Computers Together](#connecting-computers-together)
  - [Network Types](#network-types)
  - [Communication Protocol](#communication-protocol)

## Connecting Computers Together

The point of networking is to connect devices together. To do this, internet is transferred in two ways.

1. Wireless Access Points (WAP), otherwise known as WiFi
2. Wired Ethernet Connections

Ethernet is often run through walls, and is inconvenient in most rooms without a port. Most home networks have a wired hub with a bunch of ports on it somewhere, which both the wireless routers and internal wall-wired ethernet cabling eventually get hooked up to.

## Network Types

Every accessible computing or networking device in a network is called a **_node_**. Nodes are a term to represent the concept of a device that contains a certain set of distinguishable characteristics such as an IP address, network protocol, and so on.

Networks vary in size. Here are some examples:

1. Personal Area Network (PAN) - When a group of devices is intended for personal use / storage and is within about 10 meters of one another.
2. Local Area Network (LAN) - When several devices/nodes are collected via a local area switch
3. Wide Area Network (WAN) - When more than one LAN is connected to one another.
   1. Enterprise Network - Data center connects to a wide array of other smaller more distributed LANs and nodes.
   2. ISP / Cloud National Network - Data centers distributed across the country and the world.

SOHO (Small Office / Home Office) Network is another commonly used term for LANs in work-from-home places or small businesses.

## Communication Protocol

There are an astronomical amount of different ways that computers can communicate with one another. To choose one, both parties in a communication decide on a _protocol_, or set of structural guidelines for how the message should be parsed.

Common protocols are:

- Ethernet
- TCP
- HTTP (Web)
- SMTP (Email)

Several protocols are often used together to complete a task.

Protocols are used in many different levels of the [OSI Model](OSI-Model#osi-model). HTTP and SMTP are appliation-level protocols, while TCP and IP are lower-level network-related protocols.

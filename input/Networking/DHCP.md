# What is DHCP

DHCP is what allows local networking to be possible, as it's how computers are assigned IP addresses.

It's also responsible for implementing both [DOC: Subnets](Subnets.md), and [DOC: Gateways](Gateways.md). Make sure you know these before you get started.

## Table of Contents

- [What is DHCP](#what-is-dhcp)
  - [Table of Contents](#table-of-contents)
  - [Overview](#overview)
    - [_Static IP_ [Old way]](#static-ip-old-way)
    - [_Dynamic IP_ [Modern way]](#dynamic-ip-modern-way)
  - [WHERE'S MY DHCP SERVER?](#wheres-my-dhcp-server)
    - [Home Network](#home-network)
    - [Business Network](#business-network)
  - [Assigning an Initial IP to your DHCP Server](#assigning-an-initial-ip-to-your-dhcp-server)
  - [DHCP Server's "Scope"](#dhcp-servers-scope)
  - [DHCP Local Computer IP Leases](#dhcp-local-computer-ip-leases)
  - [Reservations](#reservations)

## Overview

DHCP - Dynamic Host Configuration Protocol

IP addresses are strings of numbers that identify a PC on a network. Because of this, all computers on a network are required to have an IP address. Otherwise, your network controller or switch would have no idea where to send packets to.

IP can be assigned in two ways: Static and Dynamic.

### _Static IP_ [Old way]

Each computer is manually configured to contain an IP address, and is typed in through operating system settings. (This also includes subnet masks, and default gateway)

### _Dynamic IP_ [Modern way]

A computer gets its network identifiers from a separate server, a DHCP (Dynamic Host Configuration Protocol) server. This server configures the host, by generating and assigning that computer the following:

- IP Address
- Subnet Mask
- Default Gateway
- DNS Server

## WHERE'S MY DHCP SERVER?

Your ISP has one DHCP server somewhere on their network and you have one DHCP server somewhere on your network.

What and where your local DHCP server is depends on what type of network it you are on.

### Home Network

In a home network, that is your router. Your router is the main hub of your Local Area Network that transfers things between your local devices and what it recieves from other computers across the internet.

To accomplish splitting up access between public and private networks, routers have two NICs, or Network Interface Cards. These two divide your network into a public and privately accessible network. One NIC will face your ISP and its IP address will be assigned by your ISP. The other NIC/s will face your network and will be controlled by your network.

### Business Network

In a business network, often times there are many distributed LANs across floors, buildings, and sites. Because of this, the DHCP service usually runs on a dedicated server; which is usually also the one responsible for DNS.

## Assigning an Initial IP to your DHCP Server

The ISP assigns an IP to the device you're using to run a local DHCP service. That device is responsible for similar duties to the router defined in [Home Network](#home-network). This can either be a router or a server propped up by your business.

Then, internal LAN computers contact your local DHCP service device to then be assigned IP addresses inside your private network. The response contains the above list of identifiable attributes in [Dynamic IP](#dynamic-ip-modern-way).

## DHCP Server's "Scope"

A DHCP Server has to know how many devices it's allowed to hand IPs to. A scope is a range of IP addresses that a DHCP server is allowed to hand out.

- > Start IP Address: - 10.0.0.1
- > End IP Address: - 10.0.0.100

Inside that range, the network administrator can assign IPs to either decrease from the maximum or count up from the minimum. It's configurable.

## DHCP Local Computer IP Leases

Since DHCP servers have a limited scope of IP addresses to hand out, the addresses of local computers are temporary for the time of their _lease_.

When computers are set up into a network, the DHCP server gives them an IP address. It's only valid for a particular time period, and has to be renewed at the end of that time period. When a computer fails to renew its IP address lease, the associated address becomes available again to be re-assigned to a new computer.

## Reservations

A _reservation_ ensures that a specific computer or device will always be given the same IP address.

These reservations are typically given to static assets such as network printers, servers, routers, etc. Computers that aren't going anywhere.

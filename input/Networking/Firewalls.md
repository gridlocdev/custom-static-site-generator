# Firewalls

Firewalls are sets of instructions in hardware or software to protect a computer network from potentially malicious incoming traffic.

- [Firewalls](#firewalls)
  - [Overview](#overview)
  - [How do Firewalls work?](#how-do-firewalls-work)
  - [Outward Traffic](#outward-traffic)
  - [Firewall Rules](#firewall-rules)
  - [Types of Firewalls](#types-of-firewalls)
    - [Host-based Firewall](#host-based-firewall)
    - [Network-based Firewall](#network-based-firewall)
  - [State + Firewalls](#state--firewalls)
    - [Stateful firewalls](#stateful-firewalls)
    - [State-less firewalls](#state-less-firewalls)
  - [Firewall + OSI Layers](#firewall--osi-layers)

## Overview

A firewall is a system that is designed to prevent unauthorized access from entering a private network.

It creates a safety barrier from a private network and the public internet. Out on the internet, there are hackers and malicious traffic that try to penetrate into a private network to cause harm. A Firewall is the main component on a network to prevent this.

## How do Firewalls work?

A Firewall blocks unwanted traffic by filtering on a set of rules. The filters can be set on things like IP addresses, Domain names, Protocols, Programs, Ports, and Key words.

This set of rules is called an **Access Control List**. The firewall parameters are usually determined and applied by the network administrator.

## Outward Traffic

Not only can you prevent traffic inwards to a firewall, you also use firewalls to prevent traffic outwards. It wouldn't make much sense to allow network users to send packets to somewhere that the firewall would then block the response from.

## Firewall Rules

Here is an example of the security history output of an Access Control List.

| Permission | IP Address | Protocol | Destination | Port |
| ---------- | ---------- | -------- | ----------- | ---- |
| ALLOW      | ANY        | TCP      | ANY         | 80   |
| ALLOW      | ANY        | TCP      | ANY         | 25   |
| ALLOW      | ANY        | TCP      | ANY         | 110  |
| DENY       | ANY        | UDP      | ANY         | 23   |
| DENY       | ANY        | TCP      | ANY         | 3389 |

IP addresses and destinations are never "ANY", but for the purposes of simplicity they've been omitted here. From the stuff that's been denied, we can assume one of the below scenarios:

- Either the ports 23 and 3389 are blocked
- UDP is a blocked protocol and access to port 3389 is blocked

## Types of Firewalls

In virtually every network, there are two types or layers of firewalls in place.

- Host-based (Individual computers)
- Network-based (upstream Network devices)

### Host-based Firewall

It's a _Software_ firewall that you install on a computer. It protects that computer _only_ and nothing else. It's commonly bundled in with virus protection like Windows Defender or Norton Antivirus.

### Network-based Firewall

It's a combination of hardware and software. It operates at the network layer. It's placed between a private network and the public internet. Unlike a host-based firewall, a network-based firewall protects the entire network. This is done by applying those Access Control List rules to the traffic that comes in for the _entire_ network.

The hardware that usually is used to create firewalls comes in 3 forms:

- Stand-alone firewall: A physical switch box for wired connections
- Router firewall: A router that contains firewall software
- Cloud firewall: A cloud provider provides firewalls as a service, using one of the above two

## State + Firewalls

**State** is something that the computer remembers for the purposes of using later.

For example, on an operating system's taskbar there are a list of programs. That OS data is state-ful, as it organizes data to be used to render for the user to use it later.

In the context of a firewall, state is used to remember things related to the kinds of packets being sent through. The way it handles it depends just on how much the computer would like to remember to help make decisions.

### Stateful firewalls

A Stateful firewall is what you get when you need to have records of past network transactions.

It's a firewall that applies additional logic to validate requests based on an ACL but also additional filtering rules.

As an example of something it needs to remember; the number of packets sent from an a recent address is used for protecting against DDOS (Distributed Denial Of Service) attacks.

A Stateful firewall:

- Remembers information between states
- Context-sensitive (Takes context into account for decisions)
- Is more powerful than stateless

### State-less firewalls

A state-less firewall is a cheaper and faster-running version, but does not store any metadata about requests. It only uses an ACL to filter traffic based on a set of rules and that is it. Realistically, that makes it vulnerable to a number of different cyber-attack styles.

- Doesn't remember information between states
- Context-free (Has no context for decisions)
- Less powerful than stateful

## Firewall + OSI Layers

As mentioned earlier, a firewall can be present in the form of both hardware and software. This concept is related to where that type of firewall sits in the [OSI Model](OSI-Model).

Generally, **Network-based** firewalls sit at layer 3 or 4 of the OSI Model in the Network and Transport layer. Home routers usually contain a firewall present in the hardware.

Layer 7 firewalls are present at the Application layer, and those are the **Host-based** firewalls. Generally provided by the antivirus software, it acts on network request threats at the software level.

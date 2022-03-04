# Subnets and Subnet Masks

Subnets, or sub-networks, are smaller physical or virtual networks.

- [Subnets and Subnet Masks](#subnets-and-subnet-masks)
  - [Overview](#overview)
  - [Why do we need a _Subnet_?](#why-do-we-need-a-subnet)
  - [Subnet Masks](#subnet-masks)
  - [Network Address Classes (DEPRECATED)](#network-address-classes-deprecated)
    - [Overview of Classes](#overview-of-classes)
    - [Identifying a Class](#identifying-a-class)
    - [Private IP Digits Allowed per class](#private-ip-digits-allowed-per-class)
  - [CIDR (Classless Inter-Domain Routing)](#cidr-classless-inter-domain-routing)
    - [CIDR Overview](#cidr-overview)
    - [Subnet Masks with CIDR](#subnet-masks-with-cidr)
    - [The Catch](#the-catch)

## Overview

A subnet, or subnetwork, is a smaller network inside a network. It's used to split up a network into more easily routeable sections of IP addresses.

## Why do we need a _Subnet_?

Networks need to be divided and organized in a way that makes traffic efficient and manageable. If you have a thousand devices on a network, it's almost a given that you will need a number of subnets.

Subnets organize a list of IPs into a logical group, and are indexed by location to provide faster and decentralized communication.

As an example, imagine if you tried to fit 1,000 students into a single classroom.

## Subnet Masks

A Subnet Mask is a binary representation of the number of IP addresses that the subnetwork contains, and is used to identify the subnetwork that a device's private IP belongs to for an upstream parent network device.

Masks rely on bits and bytes to translate the IP in memory to an acceptable range. This is explained more in depth in [Subnet Masks with CIDR](#subnet-masks-with-cidr)

> If a device's private IP is 192.1.1.23 and you apply a default class C subnet mask of 255.255.255.0 to it, your end gateway address would be 192.1.1.0.

## Network Address Classes (DEPRECATED)

Classes without CIDR in networks haven't been used in over a decade in favor of the newer CIDR format. But, for the most part, the way that subnets are provisioned by ISPs is similar nowadays. Knowing this also helps simplify masks and addresses.

### Overview of Classes

IP addresses are divided into _classes_, organized by size and named with a corresponding alphabetical letter identifier.

### Identifying a Class

The three major address classes are A, B, and C.

You can identify which network address class a particular IPv4 address is by looking at its first section of digits.

- Class A (Millions of devices) : 0 - 127
- Class B (Thousands of devices) : 128 - 191
- Class C (Regular amount of devices): 192 - 223

### Private IP Digits Allowed per class

Every public IP address gateway requires enough editable digits at the end to fit the number of devices it needs to host privately.

> If you needed to host 2,000 devices on a network and you had a network address class that only reserved the last three digits, you would not be able to.
>
> Range: 192.1.1.0 -> 192.1.1.999

Therefore, each class has the following set of malleable digits that it can assign to its private nodes.

- Class A = `0.XXX.XXX.XXX`
- Class B = `128.111.XXX.XXX`
- Class C = `192.111.111.XXX`

## CIDR (Classless Inter-Domain Routing)

### CIDR Overview

In 1993, a new class-less way of representing subnets was created called CIDR (pronounced "_cider_"). In the current day, this is the standard way of doing subnetworks.

### Subnet Masks with CIDR

A Subnet Mask narrows down a series of network addresses to a few values. With class-based masks, you really didn't have any way of assigning a variable amount of addresses other than by sections.

Here are the class-ful subnet masks, and their **Network Prefix Lengths**.

- A: 255.0.0.0 = /8
- B: 255.255.0.0 = /16
- C: 255.255.255.0 /24

There are 8 **bits** in a **byte**, and each bit can have one of two values; 0 and 1. A byte represents a number including and between 0 and 255, as there are 256 combinations of the binary placements in an 8 bit byte. 2^8 = 256, binary = 11111111.

An IP address in memory is a sequence of these bytes, ranging from 0 to 255. A class-ful mask only takes advantage of uniquely grouping addresses by masking a number of **_bytes_**, and not **_bits_**.

So, in order to mask bytes, we've replaced class-based masking with a bit-wise identifier instead called a **Network Prefix Length**. This length represents the number of 1s to include in a binary string of bits which then corresponds to an appropriate variable mask length.

Masks are applied from the beginning forwards, which means a greater length of our prefix (bitwise mask length) corresponds to a smaller amount of IP addresses.

> If you have a prefix of /28 bits, that represents 28 0s and the rest as 1s in your mask. IPv4 addresses contain 32 bits, as they contain 4 bytes of 8 bits.
>
> 00000000.00000000.00000000.00001111

Translating the above binary example to a real address mask would be:

0.0.0.(16)

Since masks translate existing addresses from zero counting up, this mask is then converted to its inverse.

255.255.255.(255-16=239)
255.255.255.239

### The Catch

The numbered IP that your subnet mask is modifying needs to be a valid bitwise binary address after it gets modified.

To achieve this, we just need to make sure that our numbers are a factor of the result of our Network Prefix Length's binary number output. In short, the math we did up above to determine how many IP addresses are available.

In the case of /28, this would mean our last digit needs to be a factor of 16 like 0, 16, 32, and so on.

> As an example: If you would like to create 3 subnets of 16 IP addresses, you could create the following IPv4 CIDR blocks.
>
> - Subnet 1 Block: 10.0.1.0/28
> - Subnet 2 Block: 10.0.1.16/28
> - Subnet 3 Block: 10.0.1.32/28

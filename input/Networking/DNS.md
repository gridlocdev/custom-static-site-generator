# DNS (Domain Name System)

DNS is how computers can match a human-named URL to a computer's IP address

- [DNS (Domain Name System)](#dns-domain-name-system)
  - [Overview](#overview)
  - [Where is my DNS Server?](#where-is-my-dns-server)
  - [What usual steps are taken when I connect to a web page?](#what-usual-steps-are-taken-when-i-connect-to-a-web-page)
  - [ISP Domain Discovery](#isp-domain-discovery)
    - [**1. Root Servers**](#1-root-servers)
    - [**2. TLD Servers**](#2-tld-servers)
    - [**3. Authoritative DNS Server**](#3-authoritative-dns-server)
    - [**4. ISP Resolver Caching and Response**](#4-isp-resolver-caching-and-response)
  - [End Note](#end-note)

## Overview

Computers store the its identification as a number, such as a MAC Address or IP address. But, what about a human-readable version?

DNS Resolves domain names to I.P. addresses. This is used to find the appropriate device when you type in a website URL (Uniform Resource Locator)

## Where is my DNS Server?

Most home routers wear many hats, such as DHCP server, default gateway, and also as DNS servers. These above three in an enterprise or VLAN often times are on separate devices.

## What usual steps are taken when I connect to a web page?

When connecting to a website or domain via a Domain Name, your computer will contact your local DNS server (Domain Name System) to kick things off.

The ISP and your local DNS server is responsible for caching IP addresses and domain names so that your computer can easily retrieve them for later use. Most of the time, either one of these devices will have this domain's IP cached. Finding the URL this way is called a **_Recursive_** DNS query.

> If you would like to see your local DNS server's cached addresses and IPs in Windows 10, type:
>
> `ipconfig /displaydns`

But, in the case that it is not cached, there is a process that your ISP's resolver takes to find and deliver back the appropriate IP address for that domain. This is called an **_iterative_** DNS query

> TLDR: Your local DNS server and your ISP's resolver search their cache to try and find a domain-IP pair. If not, the following ISP domain discovery begins.

If the ISP's resolver cache does not contain a domain name and IP pair, it sends it to a **Root Server**.

## ISP Domain Discovery

### **1. Root Servers**

This server is on the top of the hierarchy. There are only 13 sets around the world, and collectively are operated by 12 different organizations. These are geographically placed around the world, and the closest one to you takes your ISP's resolver's request.

This contains and responds with the network locations for a list of Top Level Domain servers. The ISP resolver then checks over there.

### **2. TLD Servers**

The TLD (Top Level Domain) servers are responsible for knowing who has the IP addresses for sites at a particular domain extension(A singular domain extension like .com, .net, .org, etc).

When an internet domain is registered with a registrar, the domain and the IP of a  Authoritative DNS server is stored onto a TLD server.

Once a domain and Authoritative DNS server pair is found, it is sent back to your ISP resolver to be queried for an IP.

### **3. Authoritative DNS Server**

Responsible for knowing everything about the domain, including the IP address.

This server finds the IP address for that domain name and sends back a response with that included to the ISP's Resolver.

### **4. ISP Resolver Caching and Response**

Once your ISP Resolver has an IP and domain pair, it is cached and stored for re-use so that subsequent domain location requests will be sent using the data from its cache.

## End Note

If at any step of Domain Discovery it does not sufficiently find details about the domain, the appropriate server will respond to your ISP resolver with an error and the discover process will end.

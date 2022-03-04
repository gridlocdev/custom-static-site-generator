# NAT: Network Address Translation

- [NAT: Network Address Translation](#nat-network-address-translation)
  - [Overview](#overview)
  - [IPv4](#ipv4)
  - [2 Types of IPv4 addresses](#2-types-of-ipv4-addresses)
  - [Translation](#translation)
  - [IPv6](#ipv6)

## Overview

NAT is used in routers to translate a set of IP addresses to another set of IP addresses.

It helps preserve the limited amount of IPv4 public IP addresses present around the world.

It translates your private IP addresses to a Public IP address used to make a request.

## IPv4

When it was created, the engineers had no idea so many people / devices would be using it. Even though there are 4 billion available addresses, they thought that would be enough, but it definitely was not.

To allow for more than 4 billion devices, NAT was created to allow translation between public and private ip addresses so that IPs can be assigned appropriately.

## 2 Types of IPv4 addresses

To see what the difference between public and private IP addresses is, see my document [DOC: Public and Private IP Addresses](DHCP#Home-Network)

They're Public and Private IP addresses. One's visible to your DHCP server and other devices in your network, and the Public IP address is only on your publically visible network endpoint.

## Translation

NAT translates:

- Private to public
- Public to private

## IPv6

The next generation of IP addresses.
Every device will have its own public IP address.

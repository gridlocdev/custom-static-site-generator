# Gateways

- [Gateways](#gateways)
  - [Overview](#overview)
  - [Protocol Conversion](#protocol-conversion)
  - [Default Gateway](#default-gateway)
  - [Packet Switching](#packet-switching)

## Overview

A gateway is a physical device that sits at the **edge of a network**, and is used to facilitate communication between two or more similar OR dissimilar networks.

Typically, this device has two NICs, or Network Interface Cards, that are connected to two separate networks. A very common example of this device is a router, or a switch.

## Protocol Conversion

Different networks can contain different sets of protocols, so the gateway contains software to make messages compatible with the receiving network.

Most of the time, your protocols will be the same; over TCP/IP. But, others might be one of the following:

- Ethernet
- UDP
- Other proprietary internal network protocol

## Default Gateway

A default gateway is the node in your computer network that serves as the point of contact to other networks when no other route specification matches the destination IP address of a packet.

For Small business or Home networks, this is usually your router.

For larger networks, often times they have several gateways that communicate with one another to send packets amongst themselves to the appropriate destination.

## Packet Switching

Gateways use what is known as **Packet Switching**. Instead of sending messages all in one go, it is divided into smaller pieces that are each sent individually.

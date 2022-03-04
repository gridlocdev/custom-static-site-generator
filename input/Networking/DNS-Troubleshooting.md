# DNS Troubleshooting

This document outlines commonly used tools and methods for troubleshooting DNS issues.

- [DNS Troubleshooting](#dns-troubleshooting)
  - [Overview](#overview)
  - [Troubleshoot an IP](#troubleshoot-an-ip)
    - [nslookup](#nslookup)
    - [dig](#dig)
    - [host](#host)
  - [Troubleshoot a Connection](#troubleshoot-a-connection)
    - [ping](#ping)
  - [Online tools](#online-tools)

## Overview

To troubleshoot DNS issues, there are plenty of options that could help you discover the problem. Here are the most popular and practical for your needs.

## Troubleshoot an IP

### nslookup

**nslookup** checks against DNS servers to return the IP address for a URL as well as any aliases the site may go by.

### dig

In Linux and MacOS, there is a command line tool for querying DNS nameservers. It can identify IP address records, record the query route as it obtains answers from an authoritative nameserver, and diagnose other dns problems.

It is also available for Windows on the author's website.

### host

This is also a linux command, and returns the IPv4 and IPv6 addresses for a website URL.

## Troubleshoot a Connection

### ping

If you would like to see how quickly a server responds to a request, you can send it a **ping** command.

> ping www.google.com

## Online tools

There are also online tools available to do the same and some extra things like the command line counterparts, a quick google search will yield you many options.

# Proxy Servers

Proxies and VPNs are used to provision an external machine service to send your requests rather than having them come from your local machine's IP.

- [Proxy Servers](#proxy-servers)
  - [Overview](#overview)
  - [Benefits](#benefits)
    - [Privacy](#privacy)
    - [Speed](#speed)
    - [Saves Bandwidth](#saves-bandwidth)
    - [Activity Logging](#activity-logging)
  - [Drawbacks](#drawbacks)
  - [VPNs](#vpns)
  - [Types of Proxy Servers](#types-of-proxy-servers)
    - [DNS](#dns)
    - [HTTP](#http)
    - [SOCKS](#socks)
    - [HTTPS](#https)
  - [Reverse Proxies](#reverse-proxies)
    - [Load Balancing](#load-balancing)
    - [Caching](#caching)
    - [Security](#security)
    - [SSL acceleration](#ssl-acceleration)

## Overview

A Proxy Server is a server that acts as a man-in-the-middle for internet requests. It's a server that acts on behalf of the user's requests.

Here are the benefits of using a Proxy Server.

## Benefits

### Privacy

Allows you to surf the internet anonymously, as it hides your IP address. Hiding in the way that it acts by default as your gateway to outside internet requests. You send requests to it, then it sends requests outwards to wherever the request needs to go and acts as a stand-in computer.

### Speed

In an enterprise if users frequently access the same site, a proxy server can _cache_ that site and increase the speed of requests.

### Saves Bandwidth

It also saves bandwidth, as with local-network cached contents you do not need to go out to the internet to retrieve those resources.

### Activity Logging

Since computers are sending requests to a server that acts on behalf of the users, they can also store the activity that the users are doing. When a company's employees are surfing the internet, that proxy server can keep retrievable logs of where that employee is going.

## Drawbacks

A proxy server does not regularly encrypt traffic on its own. The Proxy Server is responsible for re-routing requests, not necessarily hiding the request contents. This has benefits, such as increasing speed (not having to encrypt and decrypt contents saves CPU time), but also drawbacks as attackers that want to retrieve data from requests can do so with Man-In-The-Middle attacks.

## VPNs

VPNs are similar to proxy servers, and you encrypt content sent to and it decrypts your content. Once that data reaches the VPN it no longer is usually encrypted (since a VPN provider would also somehow need to provide the receiving party some sort of encryption key, which defeats the purpose of using a VPN in the first place). VPNs are slower than regular proxy servers for reasons mentioned above, as it has to take CPU time to encrypt and decrypt contents.

It's very useful when your data is sensitive and you have internally accessible items. VPN stands for Virtual **Private** Network.

A VPN is different from a proxy server in that it is capable of routing and anonymising ALL of your network traffic, not just Web requests.

## Types of Proxy Servers

[Here's the article that has the stuff that I'm using to finish this document](https://privacy.net/proxy-servers-vs-vpns/)

### DNS

A DNS proxy is a network node that can cache commonly accessed URL + IP address key-value pairs for easy future lookup. Home routers can be set up to do this, since they act themselves as an internal proxy.

This can also be applied to other externally located proxy services, such as things in another country for that server to act on your behalf.

### HTTP

This is the most common proxy server. You send an HTTP request to it, and it sends a mirrored request to somewhere else with its own credentials in the request/response header.

A common use case for an HTTP proxy is to bypass office or school firewalls to access blocked content such as social media platforms.

You can download this type of proxy software as a browser extension, which will do automatic re-routes with your requests for you.

### SOCKS

SOCKS proxies are similar to HTTP proxies, but for non-browser applications. It's a wider range proxy server that handles not just HTTP but also other types of requests by establishing a generic connection protocol (TCP) and transferring packets that way.

There is a secure version of this called SOCKS5, which only allows authorized users to access the server. It cuts down the "who", but not the "what"; as the request messagess are still not encrypted. It's not as secure as a VPN, but it's a reasonable solution for internal networks for its speed.

### HTTPS

HTTPS proxies are HTTP proxies with encrypted messages. But, it's different from a VPN as HTTP proxies do not require authentication. VPNs install some type of client on the user's machine that creates the connection on-site, while proxies simply are a network location that you send things to and from.

## Reverse Proxies

Just like how you can have a server act as your intermediary, so can external servers that are sending things to clients.

A Reverse Proxy typically has a number of features:

### Load Balancing

Reverse Proxies can act as Load Balancers, but only when you have it set up to do so.

Load balancing is when a server balances inbound requests across two or more web servers to spread the load. It's commonly referred to as a **_Load Balancer_**.

See [DOC: Load Balancing](Load-Balancers) for more details.

### Caching

Reverse Proxies can cache content from the web server(s) behind it to reduce web server load and deliver static content back to the requester without having to get the data from the web server(s).

### Security

It can protect the web server(s) by preventing direct access from the internet.

Since reverse proxies handle inbound requests on behalf of servers, it can also do similar things for security in that it can parse requests for potentially malicious code.

### SSL acceleration

A reverse proxy, if defined to do so, can also take the SSL encryption CPU load away from the web servers. This helps to speed up serverresponse time.

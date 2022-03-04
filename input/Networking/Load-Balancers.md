# Load Balancers

Load Balancers are intermediate servers in a web architecture that route traffic and distribute requests among a set of servers.

- [Load Balancers](#load-balancers)
  - [Overview](#overview)
  - [Algorithms](#algorithms)
    - [Round Robin (RR)](#round-robin-rr)
      - [Regular](#regular)
      - [Weighted Round Robin](#weighted-round-robin)
    - [Load Based](#load-based)
      - [Least Connections](#least-connections)
      - [Resource Based](#resource-based)
  - [Benefits of Load Balancers](#benefits-of-load-balancers)
    - [Scalability](#scalability)
    - [Availability](#availability)
    - [Flexibility / Convenience](#flexibility--convenience)

## Overview

Load Balancers are intermediate servers in a web architecture that route traffic and distribute requests among a set of servers. See [DOC: Proxy Servers](Proxy-Servers) for more specifics on how a server does this.

A set of servers grouped is called a _pool_.

## Algorithms

Since a Load Balancer's job is to distribute requests to multiple computers, it can do it in a number of ways. Here are the main types of ways that are used in the field.

### Round Robin (RR)

This is the simplest and most popular of the algorithm types, but it has flaws.

#### Regular

The Load Balancer will cycle between the pool servers in order that they are defined, one at a time. As an example, if you have servers A, B, and C, the order will look like this:

1. A
2. B
3. C
4. A
5. B
6. ...

Regular Round Robin does distribute requests, but it doesn't take into account the existing sessions or any other necessary items to route requests.

#### Weighted Round Robin

A Weighted Round Robin algorithm works the same way as the Regular one does, except that a server administrator applies a weight to how many requests a server in the pool can perform. This is useful in cases where you are running different levels of machines, and still need to transfer requests between them.

For a simplified example, assume that an enterprise has a cluster of three servers:

• Server A can handle 15 requests per second, on average
• Server B can handle 10 requests per second, on average
• Server C can handle 5 requests per second, on average

Next, assume that the load balancer receives 6 requests.

• 3 requests are sent to Server A
• 2 requests are sent to Server B
• 1 request is sent to Server C.

In this manner, the weighted round robin algorithm distributes the load according to each server’s capacity.

### Load Based

This strategy takes into account the load of your servers. If one is overburdened, it will send requests to the other one.

There are two categories to divert load:

#### Least Connections

Which machines in the pool have the least amount of active connections? When the TCP handshake happens between the client and the server, a connection is established and the resources are in transit. The Least Connections algorithm just counts the current connections and distributes things appropriately. Since both servers serve the same content, the connection's eventual response payload size is equivalent among load balanced servers.

#### Resource Based

Monitors the machines and checks for CPU levels/utilization, disk space, memory levels. Some metric that exists on those machines that is reported back to the Load balancer so it can make its appropriate judgements to determine who to send traffic to.

## Benefits of Load Balancers

### Scalability

With a load balancer, you can provision more than a singular server to route and handle requests. This allows you to scale to as many requests as you need, given you have the number of servers available.

### Availability

When one of the web servers crash, the Load Balancer will know to re-route requests to other currently up and running machines. Since there is likely a machine running, this gets rid of downtime.

### Flexibility / Convenience

A load balancer allows you to have a single URL for multiple servers, which is much more convenient than having people connect using different URLs.

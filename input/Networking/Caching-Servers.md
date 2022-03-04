# Caching Servers

Caching is about pre-storing a reused result of an operation (web page, database call, etc.) so that future requests return faster.

- [Caching Servers](#caching-servers)
  - [When should we cache?](#when-should-we-cache)
  - [Examples of when caching would be useful](#examples-of-when-caching-would-be-useful)
    - [HTTP Caching](#http-caching)
    - [Database](#database)
  - [Cache Hit / Cache Miss](#cache-hit--cache-miss)

## When should we cache?

We should cache when any of the following criteria is met:

1. When the underlying computation is slow
2. When the computation will run multiple times
3. When the output is the same for a particular input
4. When your hosting provider charges for DB access

## Examples of when caching would be useful

There are two usual use cases for caching, both on a web server to pre-fetch database content and also in a CDN to cache static web pages and serve those from nodes around the world.

### HTTP Caching

CDNs are used to more easily and quickly distribute website pages to users in different locations around the world from a server in or near their location to improve speed.

In order for the CDN node servers to know what content to serve, it needs to cache the content so it can itself deliver it many times. Once it is cached, that set of static files is delivered to the close-regional users that make web requests for that site.

### Database

Caching database results saves both time for computation, and money if you're using a cloud database hosting provider.

If a database takes ~50ms to compute and return the results of a particular query, that means that database is only able to compute 20 results per second. Instead, if the result of that query is sent to the web server and stored in cache memory in a hash-table, it can be retrieved and sent as many times as needed with no necessary database request round-trip.

## Cache Hit / Cache Miss

A server caches content for the intent to re-use that stored content later. To store and retrieve, it needs to be able to make the decision to serve fresh data or to serve a cached copy.

When a server returns its cached content, that is a **cache hit**. When it instead has to go and make the initial retrieval, that is called a **cache miss**.

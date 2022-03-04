# HTTP

HTTP is the main protocol used for computers to send data on the World Wide Web.

- [HTTP](#http)
  - [Overview](#overview)
  - [Main Features](#main-features)
    - [Connectionless / Stateless](#connectionless--stateless)
    - [Media Independency](#media-independency)
  - [HTTPS](#https)
  - [HTTP Methods](#http-methods)
  - [Request / Response](#request--response)
    - [Headers](#headers)
      - [**General Fields**](#general-fields)
      - [**Response Fields (Server)**](#response-fields-server)
      - [**Request Fields (Client)**](#request-fields-client)
  - [HTTP Status Codes](#http-status-codes)
    - [Ranges](#ranges)
    - [Important Status Codes](#important-status-codes)
  - [Body](#body)

## Overview

HTTP is arguably the most common one of the main application-level protocols. It is used to deliver data on the World Wide Web.

This data can be HTML files, image files, query results, etc. It specifies a formal standard for how web clients and web servers can construct and exchange this data with one another.

## Main Features

### Connectionless / Stateless

Every request is completely independent. In the communication protocol itself, it does not include any record of previous transactions.

You can (and it's common practice to) record things on the client and server machines when it gets there for things like cookies, sessions, etc; if you need that type of information, but nothing inherently about the protocol stashes or persists any connectivity record information.

### Media Independency

Any type of data can be sent by HTTP as long as both the client and the server agree on and know how to handle the data content.

To do this, it is required for the client as well as the server to specify the content type using the appropriate MIME-type. The mime type is just a string representation of the data type that you're sending, like ".js", ".mp4", ".txt", and so on. Here is a [LINK: MDN - Common MIME Types](https://developer.mozilla.org/en-US/docs/Web/HTTP/Basics_of_HTTP/MIME_types/Common_types)

## HTTPS

HTTPS stands for _**H**yper **T**ext **T**ransfer **P**rotocol: **S**ecure_

The _Secure_ means that all data that is sent back and forth is encrypted by SSL (Secure Sockets Layer) or TLS (Transport Layer Security).

## HTTP Methods

I'll omit HTTP methods here, because taking notes on something I already know isn't as much use to me. If someone other than myself is reading this, here is a resource to learn about HTTP methods [LINK: MDN - HTTP request methods](https://developer.mozilla.org/en-US/docs/Web/HTTP/Methods)

## Request / Response

HTTP requests are split up into two parts, a **header**, and a **body**.

### Headers

A **header** contains metadata that could be used to assist with processing the request. Portions of the metadata could be things that matter to both the client and the web server, or from only one to the other.

The following is a list of the basic header fields that you can send as part of an HTTP request.

#### **General Fields**

- Request URL
  - The URL you are requesting
- Request Method
  - GET/POST/etc.
- Status Code
  - See [SECTION: Response Codes](#response-codes)
- Remote Address
  - IP of the remote computer
- Referrer Policy
  - Info on the previous page you were at if it's a link

#### **Response Fields (Server)**

- Server
  - Apache/NGINX
- Set-Cookie
  - Send small pieces of data called cookies from the server to the client
- Content-Type
  - Type of data contained in the body (html, jpg, application/json, etc.)
- Content-Length
  - Length in octets (8-bit bytes)
- Date

#### **Request Fields (Client)**

- Cookies
  - Cookie that is previously sent by the server
- Accept-xxx
  - Types of these things that the client is able to understand
  - Examples
    - Encoding
    - Charset
    - Language
- Content-Type
  - Type of data contained in the body (html, jpg, application/json, etc.)
- Content-Length
  - Length in octets (8-bit bytes)
- Authorization
  - Here you can put a token or some other client identifier that is used by the server to know who you are
- User-Agent
  - Long string that has to do with the software that the user is using (Browser, Operating System, etc.)
- Referrer
  - Info on the previous page you were at if it's a link

## HTTP Status Codes

### Ranges

| Number | Type          | Description                              |
| ------ | ------------- | ---------------------------------------- |
| 1xx    | Informational | Request received / processing            |
| 2xx    | Success       | Successfully Received                    |
| 3xx    | Redirect      | Further action must be taken             |
| 4xx    | Client Error  | Request does not have what it needs      |
| 5xx    | Server Error  | Server failed to fulfill a valid request |

### Important Status Codes

| Code | Description |
| --- | --- |
| 200 | OK |
| 201 | OK created |
| 301 | Moved to new URL |
| 304 | Not modified (cached version) |
| 400 | Bad request |
| 401 | Unauthorized |
| 404 | Not Found |
| 500 | Internal Server Error |

## Body

This is where the thing you're trying to send will be. Beit an html page, an image, or some other type of data, the raw format will be here. The type is mentioned in the request header so that the receiving computer is able to read it.

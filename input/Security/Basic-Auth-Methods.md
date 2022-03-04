# Security: Basic Authorization / Authentication

For the most part, implementing security on the web is complicated enough that utilizing an external entity (e.g. an identity provider or an authorization server/service) is the best and easiest option.

The modern protocols are designed to make fulfilling servers' authorization needs to these entities more streamlined and easier.

## Table of Contents

- [Security: Basic Authorization / Authentication](#security-basic-authorization--authentication)
  - [Table of Contents](#table-of-contents)
  - [What is "auth"?](#what-is-auth)
  - [Basic authentication](#basic-authentication)
  - [SAML](#saml)
    - [SAML Assertions](#saml-assertions)
    - [What is SAML 2.0?](#what-is-saml-20)
  - [OAuth](#oauth)
    - [Key Entities](#key-entities)
    - [Important Key OAuth Terms](#important-key-oauth-terms)
    - [OAuth 2.0 User Authentication / Authorization Flow](#oauth-20-user-authentication--authorization-flow)
    - [OpenID Connect](#openid-connect)
      - [ID Tokens and JWT](#id-tokens-and-jwt)
  - [Other notable authentication protocols](#other-notable-authentication-protocols)
    - [LDAP](#ldap)
    - [Kerberos](#kerberos)
    - [RADIUS](#radius)

## What is "auth"?

_Auth_ can refer to either **Authentication**, **Authorization**, or both.

**Authentication** is the verification of a user's identity, mainly for the purposes of identifying who to _authorize_ in an application.

**Authorization** is the process of identifying and provisioning the resources that a user or service requests access to.

Authentication and authorization on the internet is usually provisioned using one of the following methods:

- Basic auth
- SAML
- OAuth
- LDAP
- Kerberos
- RADIUS

The following are key terms to note, and are used frequently as part of the above methods:

- Keys
- Tokens
- JWT

The general principle behind internet security is to allow computing systems to operate while themselves and the data they transport is free from a state of danger or threat.

To accomplish this, data must use a series of algorithms to translate into formats for both data exchange, data integrity, and storage. See [Key Data Terms](data-key-terms.md) for more information: this note covers _encryption_, _encoding_, and _hashing_.

## Basic authentication

At the most basic level, the purpose of authentication is to use an input to validate the integrity of the user input. The basic bare-bones authentication sends, for example, username and password in plaintext and verifies that against an existing set of plaintext credentials.

This accomplishes authentication, but has no measures of security in place to prevent compromise of the data on the machine and in transit. A great number of low-skill cyber-attacks can compromise credentials in plaintext format.

```JSON
{
    'username': 'ExampleUser123'
    'password': 'TotallySecurePassword1'
}
```

## SAML

SAML (Security Assertion Markup Language) is an XML-based protocol commonly used in enterprise or legacy systems for Single Sign-On (SSO) **authentication**.

This system is commonly used for authenticating a user once for the use of multiple applications.

This protocol has three main entities:

- **Principal** (User Agent): The requesting user's web browser
- **Service Provider** (SP): The application the user is accessing
- **Identity Provider** (IDP): A third party service provider providing an identity federation service; such as Active Directory, Okta, or Auth0

The general process flow is this:

1. The **Service Provider** sends a webpage to the **Principal**
2. The **Principal** attempts to sign on, sending a login message back to the **Service Provider**
3. The **Service Provider** sends a request on behalf of authenticating the Principal to the **Identity Provider**
4. The **Identity Provider** creates a _SAML Assertion_; a document that contains the authorization status of the Principal's credentials,
5. The **Identity Provider** sends this document back to the **Service Provider**
6. The **Service Provider** conducts the appropriate action for successfully authenticated users, and sends a successful login response to the **Principal**
7. The **Principal** then engages with the content as an authenticated user

### SAML Assertions

A _SAML Assertion_ is a document that contains the authorization status of the Principal's credentials, containing all the information necessary for a service provider to confirm user identity. This includes the source of the assertion, the time it was issued, and the conditions that make the assertion valid.

### What is SAML 2.0?

SAML 2.0 is the modern standard for this type of identity federation service,  released in 2005. It contains some backwards compatibility with previous releases of the service (SAML ~1.1), which may be common in legacy software that uses this standard.

## OAuth

OAuth is an **authorization** framework to enable secure scoped access to one or more delegated application resource(s). In combination with an authorization framework (such as Open ID Connect {OIDC}), this allows scoped access to applications without the need for users to give their password each time to each application.

The modern standard for this protocol is OAuth 2.0, which was re-written from the ground-up. It is not backwards compatible with the previous releases OAuth 1.0 and 1.1.

### Key Entities

Here are the key entities in the OAuth transaction:

- **Resource Owner (User)**: The owner of the identity, which is the user making the request
- **Client Application**: The user accessed application that would like to perform actions on behalf of the user
- **Authorization Server**: The third-party auth server that contains the account that the user would like access provisioned for
- **Resource Server**: The third-party application that would like to perform actions on behalf of the user

### Important Key OAuth Terms

Here are some additional key terms:

- **Redirect URI (Callback URL)**: The URL that the user is directed to after user permission is sent back to the **client application**
- **Response Type**: The type of response the client expects to receive (e.g. an authorization code)
- **Scope**: The granular permissions the client wants (access to data or to perform actions e.g. read/update/delete items, read profile, etc)
- **Consent**: The permission box presented to the user through the **client application** application confirming that they authorize the scope of permissions the application wants to do
- **Client ID**: This ID is used to identify the **client application** with the **authorization server**
- **Client Secret**: A secret password that only the **client application** and the **authorization server** knows; which is used to securely share information behind the scenes
- **Authorization Code**: A short-lived temoporary code that the **authorization server** sends back to the **client application**. The **client application** then sends a bundle of the **authorization code** and the **Client Secret** back to the **authorization server** in exchange for an **access token**
- **Access token**: The key the **client application** will use from that point forward to communicate with the **resource server**.

### OAuth 2.0 User Authentication / Authorization Flow

1. The resource owner sends a request to the client application asking for authentication.
2. The client application redirects the browser to the authorization server, and includes with that request the following pieces of information: [**Client ID**, **Redirect URI**, **Response Type**, **Scope(s)**].
3. The authorization server verifies the identity of the resource owner, and if the resource owner's identity is not found it will ask for a login.
4. If a successful authorization, the authorization server presents a **consent** form listing the permissions it wishes to grant the client application to do on behalf of the resource owner.
5. The authorization server redirects the resource owner's page back to the client application using the **Redirect URI (Callback URL)** along with a temporary **authorization code**. This code can then be exchanged for an **access token**.
6. The client application then sends the following information back to the authorization server: [**Authorization code**, **Client ID**, **Client Secret**], and asks for an **access token** in return.
7. The authorization server sends back the **access token** to the client application.
8. The client application then sends over the **access token** to the resource server, which then will use that to perform actions on behalf of the resource owner when requested from the client application.

> Here is a great tutorial that dives more into detail:
>
> [An Illustrated Guide to OAuth and OpenID Connect](https://www.youtube.com/watch?v=t18YB3xDfXI)

### OpenID Connect

OAuth 2.0 only provides a service for _authorization_, or providing the authority for a server to have access to do particular actions. But, how does the authorization server know _who_ the user is?

**Open ID Connect**, or **OIDC** for short, is an extension to OAuth 2.0 that adds an authentication layer. It allows client applications to confirm an end user's identity using authentication by reaching out to an authorization server. This enables **Single Sign-On (SSO)** capabilities, where once logged in a user does not have to re-log in to other services that authenticate with the same identity provider.

OpenID's user flow remains the same as the vanilla OAuth version, but with a few additions.

- The scope sent to the authorization server by the client application is set to "OPENID"
- When the authorization server sends back its authorization code, it also sends back something called an **ID Token**.

#### ID Tokens and JWT

This token is in the format of a JSON Web Token, or JWT for short. A JWT is a highly obfuscated string of characters in a JSON (JavaScript Object Notation) file, of which the client application can de-obfuscate and extract the user's information from.

The information inside an ID token is called  **Claims**. This information typically includes some of the following:

- Issued by
- Issued at (time)
- Expiration
- User ID

Using the access token, if needed, the client application can request additional information from the authorization server such as an email address.

## Other notable authentication protocols

> I may at some point expand on this section if there is information I need to know in the future.
>
> If you are interested in any of these, please seek a more fully-featured overview.

Here are some additional but commonly used tools in identity management systems:

### LDAP

LDAP (Lightweight Directory Access Protocol), is a protocol used for authenticating against directories inside an internal network.

This is commonly used in enterprise scenarios to provision access to computers and other virtual assets.

### Kerberos

Kerberos is a network authentication protocol created by MIT in the late 1980s, and is currently the basis for Microsoft's Active Directory user authentication system.

### RADIUS

RADIUS (Remote Authentication Dial-In User Service), is a fully-featured network access framework for what is described as a "AAA" schema.

- Authentication
- Authorization
- Accounting (Logging of user activity)

# Standard Data Security Processes and Terminology

Before knowing about security, it is important to know about a few key computing terms: **encoding**, **encryption**, **hashing**, and **obfuscation**.

## Encoding

Encoding is the process of using a **codec** to convert data in one file type to another for the purposes of data exchange or minimizing the storage a file takes.

A **codec** is a compression technology and has two components: an **encoder** to compress the files, and a **decoder** to decompress. A codec allows a file format to be compatible with systems, as it enables the end resulting format to mean something to the machine.

Some examples of codecs are ASCII, URL Encoding, and base64.

## Encryption

Encryption is the process of using a **cipher** to transform data in a way that conceals it from anyone else but the recipient and the sender.

A **cipher** is a data protection technology that algorithmically converts data into _ciphertext_, which to parties without a decryptor cipher key is an un-readable format. Each party in an encryption exchange contains a key, which either encrypts the original message contents into ciphertext, or decrypts the ciphertext into the original message contents.

There are two methodologies used for encryption, **symmetric** and **asymmetric**.

### Symmetric

Symmetric encryption is where both parties have a copy of the same key (called a **secret key**) which is capable of both decrypting and encrypting messages in the same way.

This encryption type is used in cases where both parties are able to obtain the secret key without transmitting a copy to any intermediary parties in the middle. For example, when a credit card company sends a card in the mail to a card owner, that card contains a magnetic strip that contains the binary information of the secret key which a card reader then is able to scan and transmit to the appropriate party.

The most widely used process for Symmetric encryption is **_AES_** encryption.

### Asymmetric

In an Asymmetric exchange, both parties have a set of two keys. One is used for encryption (the **public key**), and the other is used for decryption (the **private key**).

In a data exchange with Asymmetric encryption, the parties generally conduct the following sets of steps:

1. The parties both generate a set of keys, one public and one private for the uses of encrypting and decrypting their content.
2. The parties trade public keys, so they can encrypt messages that the other recipient can unpack and read it securely.
3. One party encrypts the message to send using the other party's public key, and then sends the encrypted message over the internet to the recipient using the appropriate networking protocol.
4. The receiving party uses the private key to decrypt the content.

This is secure, provided both parties are on a network where a malicious third party is not able to impersonate one of the two in the exchange. A _man-in-the-middle_ attack is where a third party generates his/her own private/public key pair and injects themselves into the middle of the transaction, attempting to fool one of the parties into sending data they can encrypt with their own keys.

The most widely used process for Symmetric encryption is **_RSA_** encryption.

## Hashing

Hashing is the process of using a **hash function** to obfuscate the data to a fixed length size for the purposes of verifying the authenticity of integrity of inputs.

A hash function has a few key principles:

- It is a one-way process, and is not reversible. The original input cannot be derived from the hashed value.
- It is re-produceable. Each time the hash function hashes an identical input, it creates the same output.
- Each hash value is unique to a single input value. Two non-identical inputs can never create the same output.

There are a couple main uses for hashing:

1. When data has changed, the entire hash value drastically changes. This makes seaching for changes through indexing the contents of a database incredibly quick.
2. Storing and authenticating sensitive data: A hashed value cannot be un-hashed, meaning it's able to be stored in a format that can only be compared to for the purposes of authentication through comparing a newly hashed value with the list of existing hash values.

## Obfuscation

Obfuscation is the process of using an algorithm to scramble data for the purposes of making it unreadable. This process is part of Encryption and Hashing, but also exists outside of that in other types of use cases.

A common use case is obfuscating the source code of websites before sending it to the client browser so that potential malicious recipients cannot easily read through the code and find security vulnerabilities.

Another use case is when malicious actors create a virus or malware, the code is usually obfuscated so that security programs or engineers cannot easily decipher the contents.

Here are some examples of algorithms used for obfuscation:

### Bitwise operator ciphers

Transforming the contents of a message in binary using a logical operator like XOR and a key containing a binary value to comapre to

### Simple Substitution ciphers

Convert plaintext to a custom alphabet output using a specific set of input-output alphanumeric key values.

### Caesar ciphers

Shift the alphabet a number of places up or down, and output the result of the plaintext alphanumeric characters in the new position in the alphabet.

The standard form of the Caesar cipher is the ROT13 (Rotate by 13 places), where the alphabet is shifted 13 places. The number 13 is significant because the alphabet has 26 letters and regardless of the direction you move each letter ends up on the exact opposite half of the alphabet.

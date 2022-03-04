# Scripting Repetitive Tasks

## Overview

DevOps engineers work closely with developers, and there are often necessary things that are repetitive to do.

Such as:

- Backups
- System Monitoring
- Cron Jobs
  - *Cron jobs are a Linux utility that schedules a command or script to run on your server automatically at a specified time and date.*

## Choosing a Language

When it comes to choosing how you implement scripting a task, there are two main types of programming  languages to choose: **Interpreted** and **Compiled** languages.

### Interpreted Languages

Interpreted languages are passed to another program on the computer that knows how to read it, and the code that runs is done inside that running program instance.

These types of languages are typically used in combination with a specific execution environment like JavaScript in the V8 browser engine, PowerShell in Windows, or BASH in Linux.

Some examples to look at for DevOps are:

- BASH
- PowerShell

### Compiled Languages

Compiled languages are converted to machine code by a *compiler*, and executed on the computer memory in the exact form it was written in.

You would typically use compiled languages for creating new programs and extending existing ones. With the use of packages, you can typically use these as well to conduct regular system tasks.

Some examples to look at for DevOps are:
  
- Python (Most popular in today's DevOps space)
- Go
- Ruby

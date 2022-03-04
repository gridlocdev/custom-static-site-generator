# Configuration Management

Managing the infrastructure for an application often means performing repetitive or easily automate-able tasks on the environments over time. Additionally, often times administrators need to do the same task or series of tasks manually for multiple servers.

**Configuration Management** is the process of using automation and automated tasks to manage infrastructure more easily. To accomplish this, there are a few popular options for tools to use:

- Ansible
- Jenkins
- Chef
- Puppet

## Repetitive Tasks

These types of tasks can be things like:

- Updating the installed software to a specific version
- Managing user/group permissions on a physical or virtual server
- Starting/stopping individual services
- Creating backups
- Rebooting

## How management tooling works

Depending on the tool you use, typically you do one of the following tasks:

- Configure your set of servers / resources using a language like YAML
- Configure one or more tasks using either a template language like YAML or using a programming language that the target server has installed like Bash, PowerShell, Python, or Ruby
- Using the tool, use the appropriate GUI or CLI button/command to run the tasks

### Agentless vs Agents

When choosing a tool and getting started, it's important to note if the tool requires using an **Agent**.

To execute tasks on the machine, you can run them using a long-running or short-lived process on the machine known as an **Agent**, or you can execute them remotely over SSH which is known as **Agentless** (since SSH-executed tasks do not require an agent to run)

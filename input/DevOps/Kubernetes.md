# Introduction to Kubernetes

Kubernetes is an open-source Container Orchestration tool created by Google, and is currently the most popular tool in the industry for organizing and managing containers.

Before we start, there is an important distinction to make between what tools are available to use while creating your Container cluster. A **Host** is a term for the environment that _hosts_ your application, be it configured on a bare metal operating system or a Virtual Machine. Some tools are built to deploy to **_multiple_** hosts, and others are built to just deploy to a **_singular_** host for the use of local testing.

## Multi-Host Orchestration Tools

Docker and Kubernetes have their own orchestration frameworks, which are substitutes for one another. But, each has their strengths and weaknesses.

- Kubernetes: Great for medium-large scale deployments, wide degree of functionality and large user community. But, has a pretty steep learning curve for beginners.
- Docker Swarm: Great for smaller-scale deployments, easier usability and is much faster to set up. But, it has limited functionality and does not have as large of a user community.

## Single-Host Orchestration Tools

Both Docker and Kubernetes have created tools to allow for deploying a set of containers to just the host machine that it is running on for local development.

I would recommend picking the one that corresponds to the Multi-Host orchestration tool you choose. For Kubernetes use **MiniKube**, and for Docker Swarm use **Docker Compose**. Aligning your single and multi-host tools makes re-using what you wrote for your IaC scripts quite easy.

- MiniKube: Kubernetes's tool to test local Kubernetes cluster deployments
- Docker Compose: Docker's tool to spin up multiple individually defined containers on a single host machine

> Here is a great StackOverflow post about the differences between Docker, Docker Compose, and Kubernetes. Understanding which tool is used when is important when setting up a containerization strategy.
>
> [External Link: StackOverflow - What's the difference between Docker Compose and Kubernetes?](https://stackoverflow.com/questions/47536536/whats-the-difference-between-docker-compose-and-kubernetes)

## Clusters in Kubernetes

As web applications are divided into smaller microservices, they're also regularly hosted on separate machines. To accomplish the task of organizing all of this, we use a **Cluster**.

### What is a Cluster?

A container **Cluster** is a defined set of hosting infrastructure that you use to run your containers. The defined clusters themselves are not tied to individual machines, but rather a template in how they should be organized and hosted.

Each machine in a _cluster_ can either be a virtual machine or the usual physical computer operating directly with the physical hardware through the operating system, as is the case with usual hosting environments.

A cluster contains two types of resources:

- **Nodes**: Worker machines that run the containerized applications
- **Control Plane**: Coordinates the nodes on the cluster

### Nodes

Each individual virtual or physical machine in a Cluster is called a **Node**.

Each of these cluster nodes contains a running process that helps coordinate with the rest of the containers through the cluster's _Control Plane_.

### Control Planes

The Control plane coordinates activities in the cluster, such as:

- Scheduling applications
- Maintaining application state
- Scaling applications
- Rolling out new updates

When an action is needed, which can be either directly detected by Kubernetes or manually entered through the Kubernetes API by a human, the Control Plane sends these updates to the awaiting worker node processes and conducts the appropriate action.

### Creating a Cluster

For developing and testing clusters, there are a number of tools available. Kubernetes provides one called _MiniKube_, which is used to create Kubernetes clusters on a local machine for testing and development.

If you would like to create a cluster using MiniKube on your own machine, you need to do a few things:

1. Decide the best _hypervisor_ for your environment that you would like to use, such as VirtualBox, Docker, or Hyper-V
2. For MiniKube, make sure that your computer operating system or processor aligns with the supported MiniKube drivers for your hypervisor of choice. This list of supported drivers is here: [External Link: MiniKube - Supported Drivers](https://minikube.sigs.k8s.io/docs/drivers/)
3. Make sure that the setting for Virtualization is enabled in your BIOS settings.
4. Install Kubernetes
5. Install MiniKube

Once MiniKube is installed and configured, the commands on the tool are now accessible through the command line using the command line identifier ```minikube``` to execute the MiniKube shell commands.

## Container Orchestration

Containers changed the way that application architecture is hosted. In recent times, applications on the web have been broken down into smaller services called _microservices_. Each of these microservices in an application stack is not run via web server software directly touching the operating system, but instead is run on an isolated system runtime known as a [Container](../Containers/Index.md).

To define your set of Containers to be deployed and managed at scale, the most feasible option is to use a Container Orchestration tool. There are a number of popular Container Orchestration tools, here are the most notable ones:

- Kubernetes
- Docker Swarm
- Nomad
- Amazon ECS

Since Container Orchestration is about organizing and connecting individual containers, learning how those individual containers work first is an important step to begin to understand Orchestration: [Containers with Docker](../Containers/Index.md)

For the purposes of my notes, I'll be taking a look at Kubernetes as it is the industry standard for Container Orchestration.

### Orchestration Terminology

- **_Clusters_** are groups of physical servers or VMs (Virtual Machines), the computer infrastructure that the containers are running on.
- **_Pods_** are groups of deployed containers, which can be distributed among any number of servers in a _cluster_.
- **_Kubernetes_** is a container orchestration framework created by Google.
- **_MiniKube*** is a tool created by Google to create Kubernetes clusters on a local machine for testing and development.
- **_Control Plane*** is a process that coordinates collaborative actions on or between all of the nodes in a Kubernetes cluster.
- **_Nodes*** are each individual worker machine in a _cluster_

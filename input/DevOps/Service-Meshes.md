# Service Mesh

## Overview

In the industry application-style shift of moving away from monolithic-style applications and towards microservices, a number of issues are present in the vanilla implementation of a micro-services architecture.

Breaking out an application stack into multiple separate network-related instances means you often will need to repeat portions of supporting functionality outside of the business logic of each service. This can include things like:

- Communications Logic
- Security Logic
- Retry Logic
- Logging

A **Service Mesh** is a contains a way of abstracting away that supporting logic into a repeat-able and deploy-able set of resources for your containerized application services.

Tools built to create and configure Service Meshes are usually tightly connected with a container orchestration framework like Kubernetes or Docker Swarm. This is because both the Service Meshes and an orchestration framework use the schema of the set of containers to know what to deploy to.

> There is a lot more to cover here, I would recommend viewing [External Link: TechWorld with Nana - Istio & Service Mesh](https://www.youtube.com/watch?v=16fgzklcF7Y) to learn more.

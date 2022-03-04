# CI/CD (Continuous Integraton + Continuous Delivery)

CI/CD is an automated process to build, test, stage, and deploy code to a hosting environment.

- [CI/CD (Continuous Integraton + Continuous Delivery)](#cicd-continuous-integraton--continuous-delivery)
  - [Overview](#overview)
  - [Continuous Integration](#continuous-integration)
  - [Continuous Delivery](#continuous-delivery)
  - [CI/CD Pipelines](#cicd-pipelines)
    - [Build Pipelines](#build-pipelines)
    - [Release Pipelines](#release-pipelines)
  - [Popular CICD Tools](#popular-cicd-tools)

## Overview

Developers create code for applications in a text editor. But, how does that application code go from source control onto a web server so that it can be served on the web?

## Continuous Integration

Continuous Integration (CI) is a practice of automating the integration of code changes from multiple developers into a single software project.

Developers push code into what's known as **Source Control**, a code versioning tool that allows for keeping track of changes over time. Versioning code allows for multiple developers to easily work on the same codebase.

When code is checked in, you can trigger an automatic process. This can include automated unit tests, scanning the code for security vulnerabilities, or our next step Continuous Delivery.

## Continuous Delivery

Continuous Delivery is used to deliver that code to either a staging destination or a server environment where you intend to host the application. An automated script will include the server location to deploy to, your application code, and any other series of steps that are needed beforehand like spinning up your infrastructure via an IaC (Infrastructure as Code) script.

## CI/CD Pipelines

A Pipeline is a series of steps that must be performed in order to deliver a new version of software. This can include build and release pipelines.

### Build Pipelines

A type of pipeline for CI typically:

- Builds the code, checking for compilation errors
- Performs tests
- Pulls in appropriate packages from a package manager like npm, pip, or NuGet
- Scans the code for security vulnerabilities

### Release Pipelines

A type of pipeline for CD typically:

- Spins up the appropriate Cloud infrastructure via an IaC script (if applicable)
- Performs the file deployment of the software application assets to an environment (development, test, or production)

## Popular CICD Tools

There are many tools that can be used for integrating and automating deployments. Here are the most popular ones:

- Jenkins
- GitHub Actions
- Azure DevOps
- Circle CI
- TeamCity
- GitLab CI

Each of these has their pros and cons, such as the ease of use, scale of features, and integration with existing Cloud providers. For example, Jenkins pipelines must be written in Groovy which allows for increased complexity and flexibility for deploying to many different kinds of environments; but also can lend itself to taking more time and effort than using Azure DevOps's UI-based tool for creating pipelines.

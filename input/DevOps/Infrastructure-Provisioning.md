# Infrastructure Provisioning

Web applications are becoming more compartmentalized into individual services, often referred to as _microservices_.

When lots of these small services are grouped together for an application, it can become difficult to do the initial setup of resources as well as deploy changes to one or more services in the bunch that need updating or re-deployment.

To accomplish this task, there are tools designed specifically to help define the infrastructure that you need to deploy. These tools are known as **Infrastructure as Code** tools.

## Popular Options

Some IaC tools are agnostic, and others are designed for specific cloud providers.

- Terraform (Platform-agnostic)
- Azure ARM Templates (Azure)
- AWS CloudFormation Templates (AWS)
- Deployment Manager Templates (GCP)

## What is a template?

To actually define the set of resources you want to deploy, you typically create a file in a data configuration language that describes which resources to deploy. The files you create to do this are known as _templates_.

### Template languages

The language templates are written in can vary by the tool you use, but typically is either written in:

- A standard language like JSON or YAML
- A DSL (Domain-specific language), which is a higher-level abstraction to more easily write in for a specific infrastructure provisioning tool such as _Bicep_ for Azure resource templates and _HCL_ (Hashicorp Configuration Language) for Terraform templates.

### Example template

For example of what a template typically is composed of, here is a basic Terraform HCL file template:

<!-- The below code is not actually in lua, but just gives reasonably close syntax highlighting to .tf files as well as comments. -->

```lua
-- Hosted on AWS
provider "aws" {}

-- Declarative variables
variable cidr_blocks {}
variable avail_zone {}

-- Individual resource identifiers
resource "aws_vpc" "myapp-vpc" {
  cidr_block = var.cidr_blocks[0].cidr_block
  tags = {
    Name: var.cidr_blocks[0].name
  }
}
```

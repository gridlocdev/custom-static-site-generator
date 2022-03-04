# YAML Introduction and Basic Commands

## Overview

YAML is a human-readable data-serialization language. It is commonly used for configuration files and in applications where data is being stored or transmitted.

YAML = YAML Ain't Markup Language

In the DevOps world, it is used for all sorts of things.

- Docker Compose Files
- CI/CD Pipeline Files
- Kubernetes Pod Files

Here are some examples of the primary features of YAML's syntax:

- [YAML Introduction and Basic Commands](#yaml-introduction-and-basic-commands)
  - [Overview](#overview)
  - [Key-value pairs](#key-value-pairs)
  - [Comments](#comments)
  - [Objects](#objects)
  - [Lists](#lists)
  - [Booleans](#booleans)
  - [Advanced Lists](#advanced-lists)
  - [Kubernetes Example](#kubernetes-example)
  - [Multi-Line Strings](#multi-line-strings)
  - [Environment Variables](#environment-variables)
  - [Placeholders](#placeholders)
  - [Components](#components)

## Key-value pairs

```yaml
app: user-authentication
port: 9000
version: 1.7
```

Strings can come in three formats

```yaml
item1: user-authentication
item2: 'user-authentication'
item3: "user-authentication"
```

Line Breaks need to be enclosed in a string like this

```yaml
item: "user-authentication \n"
```

## Comments

```yaml
# This is a comment
```

Make sure to use comments to section apart your YAML file for readability.

## Objects

```yaml
microservice:
  app: user-authentication
  port: 9000
  version: 1.7
```

This is an object named "Microservice" with attributes app, port, and version. Attribute relationships in YAML are defined by indentation.

## Lists

```yaml
microservices:
  - app: user-authentication
    port: 9000
    version: 1.7
  - app: shopping-cart
    port: 9002
    version: 1.9
```

You can also express the list separators on its own line.

```yaml
microservices:
  - 
    app: user-authentication
    port: 9000
    version: 1.7
  - 
    app: shopping-cart
    port: 9002
    version: 1.9
```

## Booleans

```yaml
boolean-types:
  - 
    boolean-true: true
    boolean-false: false
  - 
    boolean-true: yes
    boolean-false: no
  - 
    boolean-true: on
    boolean-false: off
```

## Advanced Lists

You can add strings as values to a list. The key is its preceding hierarchy node.

```yaml
Fruit-Basket:
  - Apple
  - Banana
```

You can define lists inside other items by indenting as you would expect.

```yaml
Basket:
  Fruits:
    - Apple
    - Banana
  Vegetables:
    - Broccoli
    - Carrots
    - Lettuce
```

You can also express lists in an array-type form.

```yaml
Basket:
  Fruits: [Apple, Banana]
  Vegetables: [Broccoli, Carrots, Lettuce]
```

## Kubernetes Example

Here is an example file in Kubernetes.

```yaml
apiVersion: v1
kind: Pod
metadata:
  name: nginx
  labels:
    app: nginx
spec:
  containers: 
  - 
    name: nginx-container
    image: nginx
    ports: 
    - containerPort: 80
    volumeMounts: 
    - name: nginx-vol
      mountPath: /usr/nginx/html
  - 
    name: sidecar-container
    image: some-image
    command: ["/bin/sh"]
    args: ["-c", "echo Hello from the sidecar container; sleep 300"]    
```

## Multi-Line Strings

To preserve file line breaks:

```yaml
multilineString: |
  mitochondria is the 
  powerhouse 
  of the 
  cell

# The compiler will read this as
# 
# multilineString: mitochondria is the 
#                  powerhouse 
#                  of the 
#                  cell
```

To do the opposite and interpret multiple file lines as one string:

```yaml
multilineString: > 
  mitochondria is the 
  powerhouse 
  of the 
  cell

# The compiler will read this as 
# multilineString: mitochondria is the powerhouse of the cell
```

Example use case:

If you'd like to define several shell commands to execute in a row, you would do it like this

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: mosquitto-config-file
data:
  mosquitto.conf: |
    log_dest stdout
    log_type all
    log_timestamp true
    listener 9001
```

Also, you could come into contact with something that looks like the following:

```yaml
command:
  - sh
  - c
  - |
    #!/usr/bin/env bash -e
    http() {
      local path="${1}"
      set -- -XGET -s --fail
      # some more stuff here
      curl -k "$@" "http://localhost:5601${path}"
    }
    http "/app/kibana"
```

## Environment Variables

In YAML, you can access environment variables by using a **dollar sign** symbol.
> $

In the following example, we use an environment variable that contains a database password.

```yaml
command: 
  - /bin/sh
  - -ec
  - >-
    mysql -h 127.0.0.1 -u root -p$MYSQL_ROOT_PASSWORD -e 'SELECT 1'
```

## Placeholders

When you use a platform like Ansible, Helm, or Azure Pipelines, sometimes there are values that specific platform can provide. On compiling the YAML, it evaluates these expressions and places in the appropriate values. To specify where and what insert for those, you define it with either single or double curly braces:

<!-- I've added some raw processing here since Jekyll doesn't know how to render double curly braces inside of code blocks. -->

{% raw %}

- {{ }}
- { }

{% endraw %}

<!-- {% raw %} -->
```yaml
aliVersion: v1
kind: Service
metadata:
  name: {{ .Values.service.name }}
spec: 
  selector: 
    app: {{ .Values.service.app }}
  ports:
  - 
    protocol: TCP
    port: {{ .Values.service.port }}
    targetPort: {{ .Values.service.targetport }}
```
<!-- {% endraw %} -->

## Components

If you have separate YAML that you want to separate out, you use three dashes.

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: mosquitto-config-file
data:
  mosquitto.conf: |
    log_dest stdout
    log_type all
    log_timestamp true
    listener 9001

--- 

Grocery-List:
  Fruits: [Apple, Banana]
  Vegetables: [Broccoli, Carrots, Lettuce]
```

# Gridlocdev's custom Static Site Generator

A simple and barebones Static Site Generator based on .NET and Markdig. This generator builds HTML from markdown with sanitization, and applies a presentation template with some styling and navigation controls.

This repo contains both the generator itself as well as the generated `./wwwroot` folder of my particular site hosted on [Azure Static Web Apps](https://azure.microsoft.com/en-us/services/app-service/static/).

## How the site's Markdown files are structured

Each folder contains a _home_ page, which contains a short description and a set of links to other pages in the folder.

Here's an example of what the folder structure could look like:

```
├── Index.md
├── Folder1
│   ├── Index.md
│   ├── ~.md
│   └── ~.md
├── Folder2
│   ├── Index.md
│   └── ~.md
```

## Config Layout

Here is a brief description of what the keys in the `app.config` configuration file are used for in the site generation script:

| Key | Description |
| --- | --- |
| InputFolder | Where to find the Markdown files used as input |
| OutputFolder | Where to put resulting static HTML files |
| DefaultDocumentName | In the [folder structure](#how-the-sites-markdown-files-are-structured) for the Markdown files, this is the name of the _home_ file for each folder section |

# Simple .NET SSG

A simple and bare-bones Static Site Generator using Markdig, which takes all of the Markdown files in a folder, sanitizes them, and converts them into HTML files.

## Config

In `app.config`, there are two notable keys:

- The `InputFolder` folder is where to put Markdown files
- The `OutputFolder` folder is where the resulting HTML files are built to

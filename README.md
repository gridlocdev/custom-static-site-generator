# Gridlocdev's custom Static Site Generator

A simple and bare-bones Static Site Generator based on .NET. This generator builds HTML from markdown with sanitization, and applies a presentation template with some styling and navigation controls.

## Config

In `app.config`, there are a few notable keys:

- The `InputFolder` folder is where to put Markdown files
- The `OutputFolder` folder is where the resulting HTML files are built to
- The `DefaultDocumentName` is the name of the file that represents the entry-point to a folder's contents, usually containing a table of contents with links to the other files.

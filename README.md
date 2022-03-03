# Simple .NET SSG

A simple and bare-bones Static Site Generator using Markdig, which takes all of the Markdown files in a folder, sanitizes them, and converts them into HTML files.

## Config

In `app.config`, there are a few notable keys:

- The `InputFolder` folder is where to put Markdown files
- The `OutputFolder` folder is where the resulting HTML files are built to
- The `DefaultDocumentName` is the name of the file that represents the entry-point to a folder's contents, usually containing a table of contents with links to the other files.

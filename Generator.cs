using static System.Configuration.ConfigurationManager;
using Markdig;
using Ganss.XSS;
using HtmlAgilityPack;

try
{
    // Validate the configuration file's input and output directory paths exist
    bool valid = true;
    if (!File.GetAttributes(AppSettings["InputFolder"]!).HasFlag(FileAttributes.Directory))
    {
        System.Console.WriteLine($"The file \"{AppSettings["InputFolder"]}\" isn't a directory! Please revise the app.config file's value for key \"InputFolder\".");
        valid = false;
    }
    else if (!File.GetAttributes(AppSettings["OutputFolder"]!).HasFlag(FileAttributes.Directory))
    {
        System.Console.WriteLine($"The file \"{AppSettings["OutputFolder"]}\" isn't a directory! Please revise the app.config file's value for key \"OutputFolder\".");
        valid = false;
    }
    if (!valid)
        Environment.Exit(0);
}
catch (FileNotFoundException ex)
{
    string output = Path.HasExtension(ex.FileName)
    ? $"One of the folder keys in the app.config file is to a direct file! Please modify the key containing the value \"{Path.GetFileName(ex.FileName)}\" to its parent directory or another appropriate directory location."
    : $"Directory \"{ex.FileName}\" was not found." + ex.Message;

    System.Console.WriteLine(output);
    Environment.Exit(0);
}
catch (ArgumentNullException)
{
    System.Console.WriteLine($"One of the key inputs from the app.config file has been modified or removed. Please make sure there are nodes for both keys \"InputFolder\" and \"OutputFolder\"");
    Environment.Exit(0);
}

// Get a list of the relative paths of all Markdown files in the `input` folder
var inputRelativePaths = Directory.GetFiles(AppSettings["InputFolder"]!, "*.md", SearchOption.AllDirectories)
.Select(path => path.Remove(0, AppSettings["InputFolder"]!.Length));

// Clear each HTML file in the output folder each run. Not the most elegant solution, but it works.
System.Console.WriteLine("Clearing output directory...");
string pattern = "*.html";
foreach (string file in Directory.GetFiles(AppSettings["OutputFolder"]!, pattern, SearchOption.AllDirectories))
    File.Delete(file);

// Configure the Markdown render pipeline with all advanced extensions active
var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
var sanitizer = new HtmlSanitizer();
// Allow `id` through sanitization to allow for same-document hyperlinks to headers generated with `id` attributes
sanitizer.AllowedAttributes.Add("id");

// Build each Markdown file into a sanitized and templated HTML file
foreach (var relativePath in inputRelativePaths)
{
    var input = new
    {
        FilePath = Path.Join(AppSettings["InputFolder"], relativePath),
        Directory = Path.GetDirectoryName(Path.Join(AppSettings["InputFolder"], relativePath)),
        Content = File.ReadAllText(Path.Join(AppSettings["InputFolder"], relativePath))
    };
    var output = new
    {
        FilePath = Path.Join(AppSettings["OutputFolder"], Path.ChangeExtension(relativePath, ".html")),
        Directory = Path.GetDirectoryName(Path.Join(AppSettings["OutputFolder"], relativePath))
    };

    System.Console.WriteLine($"Building {output.FilePath}...");

    string preSanitizedContent = Markdown.ToHtml(input.Content, pipeline);
    string sanitizedContent = sanitizer.Sanitize(preSanitizedContent);

    // Refactor Markdown file links (.md) to HTML (.html) file links
    var docContent = new HtmlDocument();
    docContent.LoadHtml(sanitizedContent);

    var links = docContent.DocumentNode.SelectNodes("//a[@href]");
    if (links is not null)
    {
        foreach (HtmlNode link in links)
        {
            string linkValue = link.GetAttributeValue("href", "");
            if (
                !String.IsNullOrEmpty(linkValue) &&
                !linkValue.StartsWith("http://") &&
                !linkValue.StartsWith("https://") &&
                linkValue.EndsWith(".md")
                )
            {
                string linkElementBeforeExtensionChange = link.OuterHtml;
                link.SetAttributeValue("href", Path.ChangeExtension(linkValue, ".html"));
                sanitizedContent = sanitizedContent.Replace(linkElementBeforeExtensionChange, link.OuterHtml);
            }
        }
    }

    if (!Directory.Exists(output.Directory))
        Directory.CreateDirectory(output.Directory!);

    var templateDocument = new HtmlDocument();
    templateDocument.Load("./template/template.html");

    // Inject sanitized page content
    templateDocument.GetElementbyId("ssg-inject-content").InnerHtml = sanitizedContent;

    // Build and inject a subheader into the sidebar representing the current topic
    var subheaderTitle = Path.GetDirectoryName(relativePath)!.TrimStart('/');
    subheaderTitle = String.IsNullOrEmpty(subheaderTitle) ? "Home" : subheaderTitle;
    templateDocument.GetElementbyId("ssg-inject-sidebar-subheader").InnerHtml = subheaderTitle;

    // Build and inject sidebar navigation links
    var relativePathFilePaths = Directory.GetFiles(input.Directory!, "*.md", SearchOption.TopDirectoryOnly);
    foreach (var file in relativePathFilePaths)
    {
        HtmlNode newSidebarLink;
        if (Path.GetFileNameWithoutExtension(output.FilePath) == Path.GetFileNameWithoutExtension(file))
            newSidebarLink = HtmlNode.CreateNode($"<li><a href=\"./{Path.ChangeExtension(Path.GetFileName(file), ".html")}\"><strong>{Path.GetFileNameWithoutExtension(file)}</strong></a></li>");
        else
            newSidebarLink = HtmlNode.CreateNode($"<li><a href=\"./{Path.ChangeExtension(Path.GetFileName(file), ".html")}\">{Path.GetFileNameWithoutExtension(file)}</a></li>");

        templateDocument.GetElementbyId("ssg-inject-sidebar-links").AppendChild(newSidebarLink);
    }

    // Build the breadcrumb path based on the relative file location
    int pathIndex = 0;
    var splitRelativePath = relativePath.Split("/");
    foreach (var splitPathString in splitRelativePath)
    {
        string linkText;
        string linkHref;
        HtmlNode newSidebarLink;
        string defaultDocumentFileName = AppSettings["DefaultDocumentName"] + ".html";

        if (splitPathString == String.Empty)
        {
            // Build "Home" link element for the start of the path (empty)
            linkText = "Home";
            linkHref = String.Concat(Enumerable.Repeat("../", splitRelativePath.Length - 2)) + defaultDocumentFileName;
            newSidebarLink = HtmlNode.CreateNode($"<li><a href=\"{linkHref}\">{linkText}</a></li>");
        }
        else if (Path.HasExtension(splitPathString))
        {
            // Build ending text element with no link for the current file's name
            linkText = Path.GetFileNameWithoutExtension(splitPathString);
            newSidebarLink = HtmlNode.CreateNode($"<li>{linkText}</li>");
        }
        else
        {
            // Build ending breadcrumb with a link to the previous folder
            linkText = splitPathString;
            linkHref = String.Concat(Enumerable.Repeat("../", splitRelativePath.Length - (pathIndex + 2))) + defaultDocumentFileName;
            newSidebarLink = HtmlNode.CreateNode($"<li><a href=\"{linkHref}\">{linkText}</a></li>");
        }

        templateDocument.GetElementbyId("ssg-inject-breadcrumb-links").AppendChild(newSidebarLink);
        pathIndex++;
    }

    // Copy stylesheet to output folder
    var stylesheetDestinationPath = AppSettings["OutputFolder"] + "/" + "style.css";
    var stylesheetSourcePath = "./template/style.css";

    if (!File.Exists(stylesheetDestinationPath))
        File.Copy(stylesheetSourcePath, stylesheetDestinationPath);
    else if (!File.Equals(stylesheetSourcePath, stylesheetDestinationPath))
    {
        File.Delete(stylesheetDestinationPath);
        File.Copy(stylesheetSourcePath, stylesheetDestinationPath);
    }

    // Inject styles and favicon
    var outputRelativePathToRoot = String.Concat(Enumerable.Repeat("../", splitRelativePath.Length - 2));

    templateDocument.GetElementbyId("ssg-inject-stylesheet").SetAttributeValue("href", outputRelativePathToRoot + "style.css");
    templateDocument.GetElementbyId("ssg-inject-favicon").SetAttributeValue("href", outputRelativePathToRoot + "gridlocdev-logo.svg");

    templateDocument.Save(output.FilePath);
}

File.Copy("./azure/staticwebapp.config.json", Path.Join(AppSettings["OutputFolder"], "staticwebapp.config.json"));

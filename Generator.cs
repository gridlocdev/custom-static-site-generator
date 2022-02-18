using static System.Configuration.ConfigurationManager;
using Markdig;
using Ganss.XSS;
using HtmlAgilityPack;
using System.Text;

try
{
    // Validate the file or directory paths exist
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

// Collect the relative paths (relative to the input folder) of every file in the input folder
var relativePaths = Directory.GetFiles(AppSettings["InputFolder"]!, "*.md", SearchOption.AllDirectories)
.Select(path => path.Remove(0, AppSettings["InputFolder"]!.Length));

// Configure the Markdown render pipeline with all advanced extensions active
var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
var sanitizer = new HtmlSanitizer();
// Allow `id` through sanitization to allow for same-document hyperlinks to headers generated with `id` attributes
sanitizer.AllowedAttributes.Add("id");

foreach (var relativePath in relativePaths)
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

    System.Console.WriteLine($"Building {input.FilePath}...");

    string preSanitizedContent = Markdown.ToHtml(input.Content, pipeline);
    string sanitizedContent = sanitizer.Sanitize(preSanitizedContent);

    if (!Directory.Exists(output.Directory))
        Directory.CreateDirectory(output.Directory!);


    System.Console.WriteLine($"Templating {output.FilePath}...");

    var templateDocument = new HtmlDocument();
    templateDocument.Load("./template/template.html");

    // var injectElements = new
    // {
    //     // sidebar = templateDocument.GetElementbyId("ssg-inject-sidebar-links"),
    //     breadcrumbs = templateDocument.GetElementbyId("ssg-inject-breadcrumb-links"),
    //     content = templateDocument.GetElementbyId("ssg-inject-content")
    // };

    // Build sidebar navigation links
    var relativePathFilePaths = Directory.GetFiles(input.Directory!, "*.md", SearchOption.TopDirectoryOnly);

    foreach (var file in relativePathFilePaths)
    {
        HtmlNode newSidebarLink = HtmlNode.CreateNode($"<li><a href=\"./{Path.ChangeExtension(Path.GetFileName(file), ".html")}\">{Path.GetFileNameWithoutExtension(file)}</a></li>");
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


    //System.Console.WriteLine($"Successfully templated {output.FilePath}");

    templateDocument.Save(output.FilePath);

    System.Console.WriteLine($"Successfully built {output.FilePath}");
}
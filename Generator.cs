using static System.Configuration.ConfigurationManager;
using Markdig;
using Ganss.XSS;

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
sanitizer.AllowedAttributes.Add("id");

foreach (var relativePath in relativePaths)
{
    string inputFileName = Path.Join(AppSettings["InputFolder"], relativePath);
    string outputFileName = Path.ChangeExtension(AppSettings["OutputFolder"] + relativePath, ".html");

    System.Console.WriteLine($"Building {inputFileName}...");

    string content = File.ReadAllText(inputFileName);
    string preSanitizedOutput = Markdown.ToHtml(content, pipeline);
    string sanitizedOutput = sanitizer.Sanitize(preSanitizedOutput);

    if (!Directory.Exists(Path.GetDirectoryName(outputFileName)))
        Directory.CreateDirectory(Path.GetDirectoryName(outputFileName)!);

    File.WriteAllText(outputFileName, sanitizedOutput);

    System.Console.WriteLine($"Successfully built {outputFileName}");
}
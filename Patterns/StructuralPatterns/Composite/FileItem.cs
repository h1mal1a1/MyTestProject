namespace MyTestProject.Patterns.StructuralPatterns.Composite;
public class FileItem(string name) : IFileSystemItem
{
    private readonly string _name = name;

    public void Print(string indent = "")
    {
        Console.WriteLine($"{indent}- File: {_name}");
    }
}
namespace MyTestProject.Patterns.StructuralPatterns.Composite;
public class FolderItem(string name) : IFileSystemItem
{
    private readonly string _name = name;
    private readonly List<IFileSystemItem> _items = [];

    public void Add(IFileSystemItem item)
    {
        _items.Add(item);
    }

    public void Print(string indent = "")
    {
        Console.WriteLine($"{indent}+ Folder: {_name}");
        foreach (IFileSystemItem item in _items)
        {
            item.Print($"{indent}  ");
        }
    }
}
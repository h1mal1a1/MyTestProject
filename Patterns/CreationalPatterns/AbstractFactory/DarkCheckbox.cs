namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

public class DarkCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a dark checkbox.");
    }
}
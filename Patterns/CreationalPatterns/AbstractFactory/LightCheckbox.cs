namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

public class LightCheckbox : ICheckbox
{
    public void Render()
    {
        Console.WriteLine("Rendering a light checkbox.");
    }
}
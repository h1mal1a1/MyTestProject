namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

public class DarkButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a dark button.");
    }
}
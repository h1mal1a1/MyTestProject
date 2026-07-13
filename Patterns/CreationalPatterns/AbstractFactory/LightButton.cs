namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;
public class LightButton : IButton
{
    public void Render()
    {
        Console.WriteLine("Rendering a light button.");
    }
}
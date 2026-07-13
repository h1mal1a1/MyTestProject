namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

public class LightUiFactory : IUiFactory
{
    public IButton CreateButton() => new LightButton();
    public ICheckbox CreateCheckbox() => new LightCheckbox();
}
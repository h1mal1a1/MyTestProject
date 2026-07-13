namespace MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

public class DarkUiFactory : IUiFactory
{
    public IButton CreateButton() => new DarkButton();
    public ICheckbox CreateCheckbox() => new DarkCheckbox();
}
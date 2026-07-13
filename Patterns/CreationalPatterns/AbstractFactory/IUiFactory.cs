using MyTestProject.Patterns.CreationalPatterns.AbstractFactory;

//абстрактная фабрика - это порождающий паттерн проектирования, который предоставляет интерфейс для создания семейств связанных или зависимых объектов без указания их 
// конкретных классов.  
public interface IUiFactory
{
    IButton CreateButton();
    ICheckbox CreateCheckbox();
}
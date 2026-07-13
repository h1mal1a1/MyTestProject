using MyTestProject.Patterns.CreationalPatterns.AbstractFactory;
using MyTestProject.Patterns.CreationalPatterns.FactoryMethod;
using MyTestProject.Patterns.CreationalPatterns.Builder;
using MyTestProject.Patterns.CreationalPatterns.Singleton;
using MyTestProject.Patterns.CreationalPatterns.Prototype;
namespace MyTestProject.Patterns.CreationalPatterns;
public class Creational
{
    // Создать один объект через фабричный метод
    private static void TestFactory()
    {
        /*
        Когда использовать?
        Когда нужно создавать разные реализации одного интерфейса, не привязывая клиентский код к конкретным классам.
        */
        NotificationService service = new();
        service.Send("email", "Hello, this is an email notification!");
        service.SendWithFactory("sms", "Hello, this is an SMS notification!");
    }
    
    // Создать семейство связанных объектов
    private static void TestAbstractFactory()
    {
        /*
        Чем отличается от Factory Method?
        Factory Method создаёт один продукт, Abstract Factory создаёт семейство связанных продуктов.
        */
        IUiFactory factory = new DarkUiFactory();
        IButton button = factory.CreateButton();
        ICheckbox checkbox = factory.CreateCheckbox();
        button.Render();
        checkbox.Render();
    }
    
    // Пошагово собрать сложный объект
    private static void TestBuilder()
    {
        /*
        Зачем нужен?
        Чтобы удобно создавать сложные объекты с большим количеством параметров, особенно если часть параметров необязательная.
        */
        var report = new ReportBuilder()
            .WithTitle("Jhin report")
            .WithPeriod("Jule 2026")
            .IncludeCharts()
            .IncludeSummary()
            .WithFormat("PDF")
            .Build();
        Console.WriteLine($"Report Title: {report.GetType().Name}");
        Console.WriteLine($"Report Title: {report.Title}");
    }
    
    // Гарантировать один экземпляр
    private static void TestSingleton()
    {
        /*
        Почему может быть опасен?
        Потому что создаёт глобальное состояние.
        В многопоточном или веб-приложении это может привести к ошибкам, если singleton хранит изменяемые данные.
        */
        var settings = AppSettings.Instance;
        Console.WriteLine($"App Name: {settings.AppName}");
    }
    
    // Создать объект копированием другого объекта
    private static void TestPrototype()
    {
        /*
        Что важно учитывать?
        Нужно понимать разницу между поверхностным(Shallow copy) и глубоким копированием(Deep copy).
        Поверхностная копия копирует сам объект, но вложенные reference-type поля остаются общими. Например, список Tags может остаться один и тот же.
        Глубокая копия копирует и сам объект, и вложенные объекты.

        Tags = new List<string>(product1.Tags); - это deep copy, потому что создаётся новый список, а не копируется ссылка на старый.
        Tags = product1.Tags; - это shallow copy, потому что копируется ссылка на старый список.
        */
        var baseProduct = new Product
        {
            Name = "Cream",
            Price = 1000,
            Tags = ["cosmetic", "face"]
        };

        var copy = baseProduct.Clone();
        copy.Name = "New Cream";
        copy.Tags.Add("new"); 
    }

    public static void RunAllTests()
    {
        TestFactory();
        TestAbstractFactory();
        TestBuilder();
        TestSingleton();
        TestPrototype();
    }   
}
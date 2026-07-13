using MyTestProject.Patterns.StructuralPatterns.Adapter;
using MyTestProject.Patterns.StructuralPatterns.Decorator;
using MyTestProject.Patterns.StructuralPatterns.Facade;
using MyTestProject.Patterns.StructuralPatterns.Proxy;
using MyTestProject.Patterns.StructuralPatterns.Composite;

namespace MyTestProject.Patterns.StructuralPatterns
{
    public class Structural
    {
        /// <summary>
        /// Adapter нужен, когда у тебя есть один интерфейс, а существующий класс имеет другой интерфейс, и ты хочешь использовать этот класс в своем коде без изменения его.
        /// </summary>
        private static void TestAdapter()
        {
            IPaymentService paymentService = new StripePaymentAdapter(new StripeApi());
            paymentService.Pay(100);
        }

        private static void TestBridge()
        {
            
        }

        /// <summary>
        /// Composite нужен, когда у тебя есть древовидная структура объектов, и ты хочешь работать с отдельными объектами и группами объектов одинаково.
        /// Примеры: папка и файл, категория и подкатегории, HTML-элементы и их дочерние элементы и тд
        /// </summary>
        private static void TestComposite()
        {
            var root = new FolderItem("root");
            var images = new FolderItem("images");
            images.Add(new FileItem("logo.png"));
            images.Add(new FileItem("banner.png"));
            var docs = new FolderItem("docs");
            docs.Add(new FileItem("readme.txt"));
            root.Add(images);
            root.Add(docs);
            root.Add(new FileItem("appsettings.json"));
            root.Print();
            //Встерчаются в: дерево категорий товаров, дерево меню, дерево комментариев, структура файлов.
        }

        /// <summary>
        /// Decorator добавляет объекту новое поведение, не изменяя его класс. Главная идея: оборачиваем объект в другой объект, который добавляет новое поведение.
        /// </summary>
        private static void TestDecorator()
        {
            INotifier notifier = new EmailNotifier();
            notifier = new LoggingNotifierDecorator(notifier);
            notifier = new RetryNotifierDecorator(notifier);
            notifier.Send("Hello");
            /*
            В ASP.NET Core очень похожая идея используется в middleware pipeline:
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseMiddleware<CustomMiddleware>();
            */
        }

        /// <summary>
        /// Facade предоставляет простой интерфейс к сложной системе классов, библиотеке или фреймворку. Он скрывает сложность системы и предоставляет клиенту простой 
        /// интерфейс.
        /// </summary>
        private static void TestFacade()
        {
            OrderFacade orderFacade = new(new StockService(), new PaymentService(), new EmailService());
            orderFacade.CreateOrder(1, 10, 1500);
        }

        private static void TestFlyweight()
        {
            
        }

        /// <summary>
        /// Proxy - это заместитель объекта. Он имеет такой же интерфейс, как и настоящий объект, но контролирует доступ к нему. То есть клиент думает, что работает с настоящим
        /// объектом, но на самом деле обращается к прокси. Нужен, когда нужно контролировать доступ к объекту, например, для ленивой инициализации, контроля доступа 
        /// или кэширования.
        /// </summary>
        private static void TestProxy()
        {
            IProductService productService = new CachedProductServiceProxy(new ProductService());
            Console.WriteLine(productService.GetProductName(10)); // Загружает из ProductService и кэширует
            Console.WriteLine(productService.GetProductName(10)); // Загружает из кэша

            /*
            Отличие Proxy от Decorator в том, что Proxy контролирует доступ к объекту, а Decorator добавляет новое поведение объекту. 
            В Proxy клиент думает, что работает с настоящим объектом, но на самом деле обращается к прокси. 
            В Decorator клиент работает с настоящим объектом, но обернутым в декоратор, который добавляет новое поведение.    
            */
        }

        public static void RunAllTests()
        {
            Console.WriteLine("Testing Adapter Pattern:");
            TestAdapter();
            Console.WriteLine("\r\nTesting Bridge Pattern:");
            TestBridge();
            Console.WriteLine("\r\nTesting Composite Pattern:");
            TestComposite();
            Console.WriteLine("\r\nTesting Decorator Pattern:");
            TestDecorator();
            Console.WriteLine("\r\nTesting Facade Pattern:");
            TestFacade();
            Console.WriteLine("\r\nTesting Flyweight Pattern:");
            TestFlyweight();
            Console.WriteLine("\r\nTesting Proxy Pattern:");
            TestProxy();
        }
    }
}
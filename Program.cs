using MyTestProject.Patterns.CreationalPatterns;
using MyTestProject.Patterns.StructuralPatterns;
using MyTestProject.Patterns.BehavioralPatterns;


namespace MyTestProject
{
    public class Program
    {


        public async static Task<int> Main()
        {
            await Events.Runner.RunAllTests();
            return 1;//тесты на делегаты

            return 1;
            // Creational.RunAllTests();//отвечают за создание объектов
            Structural.RunAllTests();//отвечают за структуру объектов
            Behavioral.RunAllTests();//отвечают за поведение объектов(как взаимодействуют объекты между собой)
            return 0;
        }
    }
}
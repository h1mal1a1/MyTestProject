using MyTestProject.Patterns.CreationalPatterns;
using MyTestProject.Patterns.StructuralPatterns;
using MyTestProject.Patterns.BehavioralPatterns;
using MyTestProject.Algorithms.T02Sorting;

namespace MyTestProject
{
    public class Program
    {


        public static int Main()
        {
            int[] numbers = [5, 3, 4, 1];
            Console.WriteLine(string.Join(',', numbers.Select(x => Convert.ToString(x))));
            numbers = BubbleSort.OptimizedSort(numbers);
            Console.WriteLine(string.Join(',', numbers.Select(x => Convert.ToString(x))));
            //Events.Runner.RunAllTests();//тесты на делегаты

            return 1;
            // Creational.RunAllTests();//отвечают за создание объектов
            Structural.RunAllTests();//отвечают за структуру объектов
            Behavioral.RunAllTests();//отвечают за поведение объектов(как взаимодействуют объекты между собой)
            return 0;
        }
    }
}
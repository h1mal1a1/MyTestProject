using MyTestProject.Patterns.CreationalPatterns;
using MyTestProject.Patterns.StructuralPatterns;
using MyTestProject.Patterns.BehavioralPatterns;
using MyTestProject.Algorithms.T02Sorting;

namespace MyTestProject
{
    public class Program
    {
        public static async Task<int> Main()
        {
            int[] numbers = [5, 3, 4, 1];

            Console.WriteLine(string.Join(", ", numbers));

            numbers = BubbleSort.OptimizedSort(numbers);

            Console.WriteLine(string.Join(", ", numbers));

            await Events.Runner.RunAllTests();

            // Creational.RunAllTests(); // отвечают за создание объектов
            Structural.RunAllTests();    // отвечают за структуру объектов
            Behavioral.RunAllTests();    // отвечают за поведение объектов

            return 0;
        }
    }
}
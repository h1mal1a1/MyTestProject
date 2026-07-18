using MyTestProject.Patterns.CreationalPatterns;
using MyTestProject.Patterns.StructuralPatterns;
using MyTestProject.Patterns.BehavioralPatterns;
using MyTestProject.Algorithms.T02Sorting;

namespace MyTestProject
{
    public class Program
    {
        public void RunAlgorithms()
        {
            int[] numbers = [5, 3, 4, 1];

            Console.WriteLine(string.Join(", ", numbers));

            numbers = BubbleSort.OptimizedSort(numbers);

            Console.WriteLine(string.Join(", ", numbers));
        }

        public static async Task RunEvents()
        {
            await Events.Runner.RunAllTests();
        }

        public static void RunPatterns()
        {
            // Creational.RunAllTests(); // отвечают за создание объектов
            Structural.RunAllTests();    // отвечают за структуру объектов
            Behavioral.RunAllTests();    // отвечают за поведение объектов
        }

        public static async Task RunAsync()
        {
            Async.Runner runner = new();
            await runner.RunTasks();
        }
        public static async Task<int> Main()
        {
            await RunAsync();
            return 0;
        }
    }
}
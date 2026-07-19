using MyTestProject.Patterns.CreationalPatterns;
using MyTestProject.Patterns.StructuralPatterns;
using MyTestProject.Patterns.BehavioralPatterns;
using MyTestProject.Algorithms.T02Sorting;

namespace MyTestProject
{
    public class Program
    {
        public static void RunAlgorithms()
        {
            int[] numbers = [5, 3, 4, 1];

            Console.WriteLine(string.Join(", ", numbers));

            numbers = SelectionSort.Sort(numbers);

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
        public static int Main()
        {
            RunAlgorithms();
            return 0;
        }
    }
}
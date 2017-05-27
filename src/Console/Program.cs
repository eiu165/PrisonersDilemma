using Arena;
using Service;

namespace ConsoleNamespace
{
    class Program
    {
        static void Main(string[] args)
        {

            var generation = new Generation(new PlayerFactory());

            generation.Run();
            System.Console.ReadLine();
        }
    }
}

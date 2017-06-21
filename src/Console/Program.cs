
using Service;

namespace ConsoleNamespace
{
    class Program
    {
        static void Main(string[] args)
        {

            var botService = new BotService(new Bot.Factory.BotFactory()); 
            var generation = new Generation(botService);

            generation.Run(); 
        }
    }
}

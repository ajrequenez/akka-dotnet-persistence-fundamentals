using Akka.Actor;

namespace PersistenceGameConsole;

class Program
{


    static void Main(string[] args)
    {
        Console.WriteLine("Starting Actor System...");

        ActorSystem actorSystem = ActorSystem.Create("Game");
        DisplayInstruction();

        while (true)
        {
            Thread.Sleep(2000); // ensure console color set back to white
            Console.ForegroundColor = ConsoleColor.White;

            var action = Console.ReadLine();

            var playerName = action?.Split(' ')[0];
            var command = action?.Split(' ')[1];
            var param = action?.Split(' ')[2];

            if(!string.IsNullOrEmpty(playerName) && !string.IsNullOrEmpty(command))
            {
                if (command.Contains("create"))
                {
                    CreatePlayer(playerName);
                }
                else if (command.Contains("hit"))
                {
                    var damage = 1;
                    int.TryParse(param, out damage);
                    HitPlayer(playerName, damage);
                }
                else if (command.Contains("display"))
                {
                    DisplayPlayer(playerName);
                }
                else if (command.Contains("error"))
                {
                    ErrorPlayer(playerName);
                }
            }
            else
            {
                Console.WriteLine("Unknown command");
            }
        }
    }

    private static void DisplayInstruction()
    {
        Thread.Sleep(1000);
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine("Available commands:");
        Console.WriteLine("<playername> create");
        Console.WriteLine("<playername> hit");
        Console.WriteLine("<playername> display");
        Console.WriteLine("<playername> error");

    }

    private static void CreatePlayer(string playerName)
    {
        DisplayHelper.WriteLine($"{playerName} created");
    }

    private static void HitPlayer(string playerName, int damage)
    {
        DisplayHelper.WriteLine($"{playerName} took {damage} damage!!");
    }

    private static void DisplayPlayer(string playerName)
    {
        DisplayHelper.WriteLine($"{playerName} displayed");
    }

    private static void ErrorPlayer(string playerName)
    {
        DisplayHelper.WriteLine($"oops!!");
    }
}


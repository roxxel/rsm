using System.Drawing;
using Console = Colorful.Console;

namespace RSM.Handlers;

public class HelpHandler
{
    public static async Task Handle(string leftOver = null)
    {
        WriteCommand("rsm add", "Interactively asks to add server");
        WriteCommand("rsm connect <server_name>", "Connects to server with given name");
    }

    private static void WriteCommand(string command, string description)
    {
        Console.Write(command, Color.IndianRed);
        Console.Write(" - ");
        Console.Write(description + "\n", Color.Purple);
    }
}
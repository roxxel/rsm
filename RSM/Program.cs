using System.Text;
using RSM.Handlers;
using Sharprompt;

Prompt.Symbols.Prompt = new Symbol("🤔", "?");
Prompt.Symbols.Done = new Symbol("😎", "V");
Prompt.Symbols.Error = new Symbol("😱", ">>");
Prompt.ThrowExceptionOnCancel = true;
Console.OutputEncoding = Encoding.UTF8;

var handlers = new Dictionary<string, HandleCommand>()
{
    {"add", AddHandler.Handle},
    {"connect", ConnectHandler.Handle},
    {"help", HelpHandler.Handle},
};

var commandlineArguments = Environment.GetCommandLineArgs();
var command = commandlineArguments.ElementAtOrDefault(1);

if (!handlers.TryGetValue(command ?? "NONE", out var handler))
{
    Console.WriteLine($"Command '{command ?? "NONE"}' isn't recognized. Run rsm help to see usage");
    return;
}

await handler(string.Join(" ", commandlineArguments[2..]));


delegate Task HandleCommand(string leftOver = null);

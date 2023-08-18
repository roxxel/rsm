using System.Diagnostics;
using TextCopy;
using WindowsInput;
using WindowsInput.Native;

namespace RSM.Handlers;

public class ConnectHandler
{
    public static async Task Handle(string leftOver = null)
    {
        string serverName = leftOver;
        var server = JsonStorage.Collection.Find(x => x.Name == leftOver).FirstOrDefault();
        if (server == null)
        {
            Console.WriteLine($"Couldn't find server with name \"{leftOver}\"");
        }

        var proc = Process.Start(new ProcessStartInfo()
        {
            FileName = "ssh",
            WorkingDirectory = Directory.GetCurrentDirectory(),
            Arguments = $"{server.Username}@{server.Host}" + (server.UsesPrivateKey ? $" -i \"{server.PrivateKeyLocation}\"" : "")
        });
        //Not sure if this works, I have no server that uses password authorization
        if (!server.UsesPrivateKey)
        {
            await Task.Delay(1000);
            new InputSimulator().Keyboard.TextEntry(server.Pasword);
            new InputSimulator().Keyboard.KeyPress(VirtualKeyCode.RETURN);
        }
        await proc.WaitForExitAsync();
    }
}
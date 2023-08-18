using Sharprompt;

namespace RSM.Handlers;
#pragma warning disable CS8601 // Possible null reference assignment.

public class AddHandler
{
    public static async Task Handle(string leftOver = null)
    {
        var name = Prompt.Input<string>("Name your server", validators: new[] { Validators.Required() });
        var host = Prompt.Input<string>("Enter host you wish to connect", validators: new[] { Validators.Required() });
        var port = Prompt.Input<int>("Enter port of your server", defaultValue: 22, validators: new[] { Validators.Required() });
        var username = Prompt.Input<string>("Enter username", validators: new[] { Validators.Required() });
        var isPrivateKeyConnection = Prompt.Confirm("Do you connect to your server with private key?");
        string connectionCredentials = "";
        if (isPrivateKeyConnection)
            connectionCredentials = Prompt.Input<string>("Enter path to your private key", validators: new[] { Validators.Required() });
        else 
            connectionCredentials = Prompt.Input<string>("Enter your password", validators: new[] { Validators.Required() });

        Console.WriteLine(
            $"Name: {name}\n" +
            $"Host: {host}\n" +
            $"Port: {port}\n" +
            $"Username: {username}\n" +
            $"Connection with Password: {(!isPrivateKeyConnection ? "True" : "False")}");
        var isRight = Prompt.Confirm("Is this right?");
        if (!isRight)
        {
            await Handle(leftOver);
            return;
        }
        JsonStorage.Collection.InsertOne(new Server()
        {
            Name = name,
            Host = host,
            Username = username,
            Pasword = isPrivateKeyConnection ? null : connectionCredentials,
            Port = port,
            PrivateKeyLocation = isPrivateKeyConnection ? connectionCredentials : null
        });
        Console.WriteLine("Added new server!");
    }
}
#pragma warning restore CS8601 // Possible null reference assignment.

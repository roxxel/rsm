namespace RSM;

public class Server
{
    public string Name { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string Username { get; set; }
    public string Pasword { get; set; }
    public string PrivateKeyLocation { get; set; }
    public bool UsesPrivateKey => PrivateKeyLocation != null;
}
namespace Phoenix.Console
{
    public sealed class AppSettings
    {
        public Connection Connection { get; set; }
    }

    public sealed class Connection
    {
        public string Value { get; set; }
        public bool? Secure { get; set; }
    }
}
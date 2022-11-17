namespace Alize.Platform.Infrastructure.Options
{
    public class EmailOptions
    {
        public const string Email = "Email";
        public string Client { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Host { get; set; } = string.Empty;
        public string SenderEmail { get; set; } = string.Empty;
        public int Port { get; set; }
    }
}

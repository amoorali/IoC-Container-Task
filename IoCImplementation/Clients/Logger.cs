namespace IoCImplementation.Clients
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            // Here you can implement the logic to log the message, e.g., to a file or console
            Console.WriteLine($"Log: {message}");
        }
    }
}

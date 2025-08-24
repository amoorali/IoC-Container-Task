namespace IoCImplementation.Clients
{
    public class ClientSecond : IClient
    {
        public int Id { get; set; } = 2;
        public string Name { get; set; } = "Majid";

        public void LogMessage(string message)
        {
            // Simulate logging
            Console.WriteLine($"ClientSecond: {message}");
        }
    }
}

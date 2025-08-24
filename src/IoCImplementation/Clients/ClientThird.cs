namespace IoCImplementation.Clients
{
    public class ClientThird : IClient
    {
        public int Id { get; set; } = 3;
        public string Name { get; set; } = "Matin";

        public void LogMessage(string message)
        {
            // Simulate logging
            Console.WriteLine($"ClientThird: {message}");
        }
    }
}

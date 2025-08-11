namespace IoCImplementation.Clients
{
    public class ClientFirst : IClient
    {
        public int Id { get; set; } = new Random().Next(1, 100);
        public string Name { get; set; } = "Amir";

        private readonly ILogger _logger;

        public ClientFirst(ILogger logger)
        {
            _logger = logger;
        }

        public void LogMessage(string message)
        {
            _logger.Log($"ClientFirst: {message}");
        }
    }

}

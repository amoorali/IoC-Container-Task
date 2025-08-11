namespace IoCImplementation.Clients
{
    public interface IClient
    {
        int Id { get; set;  }
        string Name { get; set;  }

        void LogMessage(string message);
    }
}

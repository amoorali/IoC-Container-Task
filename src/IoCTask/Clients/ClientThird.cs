namespace IoCTask.Clients
{
    public class ClientThird : IClient
    {
        public int Id { get; set; } = new Random().Next(1, 100);
        public string Name { get; set; } = "Matin";
    }
}

namespace IoCTask.Clients
{
    public class ClientFirst : IClient
    {
        public int Id { get; set; } = new Random().Next(1, 100);
        public string Name { get; set; } = "Amir";
    }
}

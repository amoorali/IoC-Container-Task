using System.Numerics;
using IoCTask.Clients;


namespace IoCTask.Services
{
    public record ClientDto(int Id, string Name);

    public class ClientsService(IEnumerable<IClient> _clients)
    {
        public List<ClientDto> GetClients()
        {
            return _clients
                .Select(client => new ClientDto(client.Id, client.Name))
                .ToList();
        }

        public ClientDto? GetClientById(int id)
        {
            var client = _clients.FirstOrDefault(client => client.Id == id);
            return client is null ? null : new ClientDto(client.Id, client.Name);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using IoCTask.Services;
using IoCTask.Clients;

namespace IoCTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController(ClientsService _clientsService) : ControllerBase
    {

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var _clients = _clientsService.GetClients();
            return _clients is null ? NotFound("No clients are available.") : Ok(_clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var _client = _clientsService.GetClientById(id);
            return _client is null ? NotFound($"The client with id {id} is not found.") : Ok(_client);
        }

    }
}

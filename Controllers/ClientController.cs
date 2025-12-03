using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("Client")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost("Add")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult AddClient(ClientDTO request)
        {
            _clientService.AddClient(request);
            return Ok();
        }
        [HttpGet("Get")]
        [Produces("application/json")]
        public ActionResult GetClientByName(string сlientName)
        {
            Client client = _clientService.GetClientByName(сlientName);
            if (client == null)
            {
                return NotFound(new { message = "Client Not Found"});
            }
            return Ok(client);
        }
        [HttpPut("Change")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult UpdateClient(ClientChangeDTO request)
        {
            _clientService.UpdateClient(request);
            return Ok();
        }
        [HttpDelete("Delete/{clientCode}")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult DeleteClient(int clientCode)
        {
            _clientService.DeleteClient(clientCode);
            return Ok();
        }
        [HttpGet("GetAll")]
        [Produces("application/json")]
        public IEnumerable<Client> GetAllClients()
        {
            List<Client> clients = _clientService.GetAllClients();
            return clients;
        }
    }
}

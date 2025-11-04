using Fiscalizator.FiscalizationClasses.Dto;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fiscalizator.Controllers
{
    [ApiController]
    [Route("api/Client")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }
        [HttpPost]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult AddClient(ClientDTO request)
        {
            _clientService.AddClient(request);
            return Ok();
        }
        [HttpGet]
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
        [HttpPut("{clientCode}")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult UpdateClient(int clientCode, ClientDTO request)
        {
            _clientService.UpdateClient(clientCode, request);
            return Ok();
        }
        [HttpDelete("{clientCode}")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult DeleteClient(int clientCode)
        {
            _clientService.DeleteClient(clientCode);
            return Ok();
        }
    }
}

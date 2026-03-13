using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Produces("application/json"), Consumes("application/json")]
        [Authorize(Roles = "GlobalAdmin")]
        public ActionResult AddClient(ClientDTO request)
        {
            _clientService.AddClient(request);
            return Ok();
        }

        [HttpPut]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult UpdateClient(ClientChangeDTO request)
        {
            _clientService.UpdateClient(request);
            return Ok();
        }

        [HttpDelete]
        [Produces("application/json")]
        public ActionResult DeleteClient(ClientDeleteDTO clientDeleteDTO)
        {
             _clientService.DeleteClient(clientDeleteDTO);
             return Ok();
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
             var clients = _clientService.GetAllClients();
             return Ok(clients);

        }
    }
}

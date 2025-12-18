using Fiscalizator.FiscalizationClasses.Dto.Client;
using Fiscalizator.FiscalizationClasses.Entities;
using Fiscalizator.FiscalizationClasses.Services;
using Fiscalizator.FiscalizationClasses.Validators.Exceptions;
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
            try
            {
                _clientService.AddClient(request);
                return Ok();
            }
            catch (ClientException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpPut("Change")]
        [Produces("application/json"), Consumes("application/json")]
        public ActionResult UpdateClient(ClientChangeDTO request)
        {
            try
            {
                _clientService.UpdateClient(request);
                return Ok();
            }
            catch (ClientException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpDelete("Delete/{clientCode}")]
        [Produces("application/json")]
        public ActionResult DeleteClient(ClientDeleteDTO clientDeleteDTO)
        {
            try
            {
                _clientService.DeleteClient(clientDeleteDTO);
                return Ok();
            }
            catch (ClientException ex)
            {
                return BadRequest(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }

        [HttpGet("GetAll")]
        [Produces("application/json")]
        public ActionResult<IEnumerable<Client>> GetAllClients()
        {
            try
            {
                var clients = _clientService.GetAllClients();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred: " + ex.Message);
            }
        }
    }
}

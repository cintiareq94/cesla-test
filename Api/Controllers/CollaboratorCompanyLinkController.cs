using CollaboratorTest._2._Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorCompanyLinkController : ControllerBase
    {
        private readonly ICollaboratorCompanyService _collaboratorCompanyService;
  

    public CollaboratorCompanyLinkController(ICollaboratorCompanyService collaboratorCompanyService)
        {
            _collaboratorCompanyService = collaboratorCompanyService;
        }

        [HttpGet("GetAllCollaboratorCompanyLinks")]
        public async Task<IActionResult> GetAll()
        {
            var collaboratorCompanyLinks = await _collaboratorCompanyService.GetAll();
                return Ok(collaboratorCompanyLinks);
        }


        [HttpGet("GetAllCollaboratorCompanyLinksEnabled")]
        public async Task<IActionResult> GetAllEnabled()
        {
            var collaboratorCompanyLinks = await _collaboratorCompanyService.GetAllEnabled();
            return Ok(collaboratorCompanyLinks);
        }


        [HttpGet("GetLinkById/{id:long}")]
        public async Task<IActionResult> GetLinkById(long id)
        {
            var result = await _collaboratorCompanyService.GetLinkById(id);

            if (result == null)
            {
                return NotFound($"CollaboratorCompanyLink with ID {id} not found.");
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCollaboratorCompanyLink/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _collaboratorCompanyService.DeleteCollaboratorCompanyLink(id);
            return Ok();
        }
    }
}

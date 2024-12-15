using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _collaboratorService;

        public CollaboratorsController(ICollaboratorService collaboratorService)
        {
            _collaboratorService = collaboratorService;
        }

        [HttpGet("GetAllCollaborators")]
        public async Task<IActionResult> GetAll()
        {
            var collaborators = await _collaboratorService.GetAll();
            return Ok(collaborators);
        }

        [HttpGet("GetAllEnabled")]
        public async Task<IActionResult> GetAllEnabled()
        {
            var collaborators = await _collaboratorService.GetAllEnabled();
            return Ok(collaborators);
        }

        [HttpGet("GetCollaboratorById/{id:long}")]
        public async Task<IActionResult> GetCollaboratorById(long id)
        {
            var result = await _collaboratorService.GetCollaboratorById(id);

            if (result == null)
                return NotFound($"Collaborator with ID {id} not found.");

            return Ok(result);
        }

        [HttpPost("AddCollaborator")]
        public async Task<IActionResult> Add(CollaboratorCompanyLinkRequestDto dto)
        {
            var collaboratorId = await _collaboratorService.AddCollaborator(dto);

            return CreatedAtAction(nameof(GetCollaboratorById), new { id = collaboratorId }, null);
        }

        [HttpPut("UpdateCollaborator/{collaboratorId:long}")]
        public async Task<IActionResult> Update(long collaboratorId, CollaboratorCompanyLinkRequestDto dto)
        {
            await _collaboratorService.UpdateCollaborator(collaboratorId, dto);

            return Ok();
        }
    }
}
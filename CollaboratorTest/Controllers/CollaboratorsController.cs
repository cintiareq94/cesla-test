using CollaboratorTest.Application.DTO;
using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollaboratorTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        private readonly ICollaboratorService _service;

        public CollaboratorsController(ICollaboratorService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCollaborators")]
        public async Task<IActionResult> GetAll()
        {
            var collaborators = await _service.GetAllAsync();
            return Ok(collaborators);
        }


        [HttpGet("GetAllEnabled")]
        public async Task<IActionResult> GetAllEnabled()
        {
            var collaborators = await _service.GetAllEnabledAsync();
            return Ok(collaborators);
        }

        [HttpGet("GetCollaboratorById/{id:long}")]
        public async Task<IActionResult> GetById(long id)
        {
            var collaborator = await _service.GetByIdAsync(id);
            if (collaborator == null) return NotFound();

            return Ok(collaborator);
        }

        [HttpPost("AddCollaborator")]
        public async Task<IActionResult> Add(CollaboratorRequestDto dto)
        {
            var collaborator = await _service.AddAsync(dto);

            var response = new CollaboratorResponseDto
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                Email = collaborator.Email,
                Phone = collaborator.Phone,
                Address = collaborator.Address,
                Document = collaborator.Document,
                Role = collaborator.Role,
                Department = collaborator.Department,
                IsEnabled = collaborator.IsEnabled,
            };

            return Ok(response);
        }

        [HttpPut("UpdateCollaborator/{id:long}")]
        public async Task<IActionResult> Update(long id, CollaboratorRequestDto dto)
        {
            var collaborator = await _service.UpdateAsync(id, dto);

            var response = new CollaboratorResponseDto
            {
                Id = collaborator.Id,
                Name = collaborator.Name,
                Email = collaborator.Email,
                Phone = collaborator.Phone,
                Address = collaborator.Address,
                Document = collaborator.Document,
                Role = collaborator.Role,
                Department = collaborator.Department,
                IsEnabled = collaborator.IsEnabled,
            };
           
            return Ok(response);
        }

        [HttpDelete("DeleteCollaborator/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}

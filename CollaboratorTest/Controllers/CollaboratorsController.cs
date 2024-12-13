using CollaboratorTest.Application.DTO.Requests;
using CollaboratorTest.Application.Handlers.Commands;
using CollaboratorTest.Application.Handlers.Queries;
using Microsoft.AspNetCore.Mvc;
using CollaboratorTest.Application.Queries.Collaborator;
using CollaboratorTest.Application.Commands.Collaborator.CollaboratorTest.Application.Commands;
using CollaboratorTest.Application.Commands.Collaborator;

namespace CollaboratorTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : ControllerBase
    {
        private readonly GetCollaboratorsHandler _getCollaboratorsHandler;
        private readonly GetEnabledCollaboratorsHandler _getEnabledCollaboratorsHandler;
        private readonly GetCollaboratorByIdHandler _getCollaboratorByIdHandler;
        private readonly AddCollaboratorHandler _addCollaboratorHandler;
        private readonly UpdateCollaboratorHandler _updateCollaboratorHandler;
        private readonly DeleteCollaboratorHandler _deleteCollaboratorHandler;

        public CollaboratorsController(
            GetCollaboratorsHandler getCollaboratorsHandler,
            GetEnabledCollaboratorsHandler getEnabledCollaboratorsHandler,
            GetCollaboratorByIdHandler getCollaboratorByIdHandler,
            AddCollaboratorHandler addCollaboratorHandler,
            UpdateCollaboratorHandler updateCollaboratorHandler,
            DeleteCollaboratorHandler deleteCollaboratorHandler)
        {
            _getCollaboratorsHandler = getCollaboratorsHandler;
            _getEnabledCollaboratorsHandler = getEnabledCollaboratorsHandler;
            _getCollaboratorByIdHandler = getCollaboratorByIdHandler;
            _addCollaboratorHandler = addCollaboratorHandler;
            _updateCollaboratorHandler = updateCollaboratorHandler;
            _deleteCollaboratorHandler = deleteCollaboratorHandler;
        }

        [HttpGet("GetAllCollaborators")]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCollaboratorsQuery();
            var collaborators = await _getCollaboratorsHandler.HandleAsync(query);
            return Ok(collaborators);
        }

        [HttpGet("GetAllEnabled")]
        public async Task<IActionResult> GetAllEnabled()
        {
            var query = new GetEnabledCollaboratorsQuery();
            var collaborators = await _getEnabledCollaboratorsHandler.HandleAsync(query);
            return Ok(collaborators);
        }

        [HttpGet("GetCollaboratorById/{id:long}")]
        public async Task<IActionResult> GetCollaboratorById(long id)
        {
            var query = new GetCollaboratorByIdQuery(id);
            var result = await _getCollaboratorByIdHandler.HandleAsync(query);

            if (result == null)
                return NotFound($"Collaborator with ID {id} not found.");

            return Ok(result);
        }

        [HttpPost("AddCollaborator")]
        public async Task<IActionResult> Add(CollaboratorRequestDto dto)
        {
            var command = new AddCollaboratorCommand
            {
                Name = dto.Name,
                Address = dto.Address,
                Email = dto.Email,
                Department = dto.Department,
                Role = dto.Role,
                Phone = dto.Phone,
                Document = dto.Document,
                IsEnabled = dto.IsEnabled
            };

            var collaboratorId = await _addCollaboratorHandler.HandleAsync(command);

            return CreatedAtAction(nameof(GetCollaboratorById), new { id = collaboratorId }, null);
        }

        [HttpPut("UpdateCollaborator/{id:long}")]
        public async Task<IActionResult> Update(long id, CollaboratorRequestDto dto)
        {
            var command = new UpdateCollaboratorCommand
            {
                Id = id,
                Name = dto.Name,
                Address = dto.Address,
                Email = dto.Email,
                Department = dto.Department,
                Role = dto.Role,
                Phone = dto.Phone
            };

            await _updateCollaboratorHandler.HandleAsync(command);

            return NoContent();
        }

        [HttpDelete("DeleteCollaborator/{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteCollaboratorCommand { Id = id };
            await _deleteCollaboratorHandler.HandleAsync(command);
            return NoContent();
        }
    }
}

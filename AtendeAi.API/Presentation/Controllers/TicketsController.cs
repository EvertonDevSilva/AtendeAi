using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace AtendeAi.API.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController(ITicketService service, IValidator<TicketDTO> validator) : ControllerBase
    {
        private readonly ITicketService service = service;
        private readonly IValidator<TicketDTO> validator = validator;

        [HttpGet]
        public async Task<List<TicketResponseDTO>> GetAsync()
        {
            return await service.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<TicketResponseDTO> GetByIdAsync(int id)
        {
            return await service.GetByIdAsync(id);
        }

        [HttpGet("Filter")]
        public async Task<List<TicketResponseDTO>> GetFilterAsync(string? title, string? ticketNumber, DateTime? createAt, DateTime? updatedAt)
        {
            return await service.GetFilterAsync(title, ticketNumber, createAt, updatedAt);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TicketDTO value)
        {
            var result = await validator.ValidateAsync(value);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await service.PostAsync(value);
            return Ok();
            //return CreatedAtAction(nameof(GetByIdAsync), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] TicketDTO value)
        {
            var result = await validator.ValidateAsync(value);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            await service.PutAsync(id, value);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await service.DeleteAsync(id);
            return Ok();
        }
    }
}

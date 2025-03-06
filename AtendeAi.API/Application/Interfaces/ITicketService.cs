using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Application.Interfaces
{
    public interface ITicketService
    {
        Task<List<TicketResponseDTO>> GetAsync();
        Task<TicketResponseDTO> GetByIdAsync(int id);
        Task<List<TicketResponseDTO>> GetFilterAsync(string? title, string? ticketNumber, DateTime? createAt, DateTime? updatedAt);
        Task PostAsync(TicketDTO dto);
        Task PutAsync(int Id, TicketDTO dto);
        Task DeleteAsync(int Id);
    }
}

using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Infrastructure.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetFilterAsync(string? title, string? ticketNumber, DateTime? createAt, DateTime? updatedAt);
        Task PostAsync(Ticket entity);
        Task PutAsync(Ticket entity);
        Task DeleteAsync(Ticket entity);
        Task<string> CreateTicketNumber();
    }
}

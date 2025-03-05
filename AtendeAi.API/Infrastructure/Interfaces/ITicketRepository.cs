using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Infrastructure.Interfaces
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAsync();
        Task<Ticket> GetByIdAsync(int id);
        Task<List<Ticket>> GetFilterAsync(Ticket entity);
        Task PostAsync(Ticket entity);
        Task PutAsync(Ticket entity);
        Task DeleteAsync(Ticket entity);
    }
}

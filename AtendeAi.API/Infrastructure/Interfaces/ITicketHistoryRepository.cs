using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Infrastructure.Interfaces
{
    public interface ITicketHistoryRepository
    {
        Task<List<TicketHistory>> GetAsync();
        Task<TicketHistory> GetByIdAsync(int id);
        Task<List<TicketHistory>> GetFilterAsync(TicketHistory entity);
        Task PostAsync(TicketHistory entity);
        Task PutAsync(TicketHistory entity);
        Task DeleteAsync(TicketHistory entity);
    }
}

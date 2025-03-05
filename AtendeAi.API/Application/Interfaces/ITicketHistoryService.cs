using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Application.Interfaces
{
    public interface ITicketHistoryService
    {
        Task<List<TicketHistory>> GetAsync();
        Task<TicketHistory> GetByIdAsync(int id);
        Task<List<TicketHistory>> GetFilterAsync(TicketHistory entity);
        Task PostAsync(TicketHistory entity);
        Task PutAsync(int Id);
        Task DeleteAsync(int Id);
    }
}

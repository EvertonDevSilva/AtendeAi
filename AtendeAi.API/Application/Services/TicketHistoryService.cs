using AtendeAi.API.Application.Interfaces;
using AtendeAi.API.Domain.Entities;
using AtendeAi.API.Infrastructure.Interfaces;

namespace AtendeAi.API.Application.Services
{
    public class TicketHistoryService(ITicketHistoryRepository repository) : ITicketHistoryService
    {
        private readonly ITicketHistoryRepository repository = repository;
        public async Task<List<TicketHistory>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<List<TicketHistory>> GetFilterAsync(TicketHistory entity)
        {
            return await repository.GetFilterAsync(entity);
        }

        public async Task PostAsync(TicketHistory entity)
        {
            await repository.PostAsync(entity);
        }

        public async Task PutAsync(int Id)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");
            await repository.PutAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");
            await repository.DeleteAsync(entity);
        }
    }
}

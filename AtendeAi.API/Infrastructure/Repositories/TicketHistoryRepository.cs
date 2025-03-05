using AtendeAi.API.Domain.Entities;
using AtendeAi.API.Infrastructure.Data;
using AtendeAi.API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtendeAi.API.Infrastructure.Repositories
{
    public class TicketHistoryRepository(AppDbContext context) : ITicketHistoryRepository
    {
        private readonly AppDbContext context = context;

        public async Task<List<TicketHistory>> GetAsync()
        {
            return await context.TicketHistories.ToListAsync();
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
            var response = await context.TicketHistories.FindAsync(id);
            if (response is null)
            {
                throw new Exception("Not found");
            }

            return response;
        }

        public async Task<List<TicketHistory>> GetFilterAsync(TicketHistory entity)
        {
            return await context.TicketHistories.Where
                (t => 
                      (t.TicketId == entity.TicketId || entity.TicketId > 0) ||
                      (t.Status == entity.Status || entity.Status > 0) ||
                      (t.CurrentDepartmentId == entity.CurrentDepartmentId || entity.CurrentDepartmentId > 0) ||
                      (t.EmployeeId == entity.EmployeeId || entity.EmployeeId > 0) ||
                      (t.CreatedAt == entity.CreatedAt || entity.CreatedAt == DateTime.MinValue) ||
                      (t.CreatedAt == entity.CreatedAt || entity.CreatedAt == DateTime.MinValue)
                ).ToListAsync();
        }

        public async Task PostAsync(TicketHistory entity)
        {
            await context.TicketHistories.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task PutAsync(TicketHistory entity)
        {
            context.TicketHistories.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TicketHistory entity)
        {
            context.TicketHistories.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

using AtendeAi.API.Domain.Entities;
using AtendeAi.API.Infrastructure.Data;
using AtendeAi.API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtendeAi.API.Infrastructure.Repositories
{
    public class TicketRepository(AppDbContext context) : ITicketRepository
    {
        private readonly AppDbContext context = context;

        public async Task<List<Ticket>> GetAsync()
        {
            return await context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var response = await context.Tickets.FindAsync(id);
            if (response is null)
            {
                throw new Exception("Not found");
            }

            return response;
        }

        public async Task<List<Ticket>> GetFilterAsync(Ticket entity)
        {
            return await context.Tickets.Where
                (t => 
                      (t.TicketNumber == entity.TicketNumber || string.IsNullOrWhiteSpace(entity.TicketNumber)) ||
                      (t.Title == entity.Title || string.IsNullOrWhiteSpace(entity.Title)) ||
                      (t.CreatedAt == entity.CreatedAt || entity.CreatedAt == DateTime.MinValue) ||
                      (t.CreatedAt == entity.CreatedAt || entity.CreatedAt == DateTime.MinValue)
                ).ToListAsync();
        }

        public async Task PostAsync(Ticket entity)
        {
            await context.Tickets.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task PutAsync(Ticket entity)
        {
            context.Tickets.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket entity)
        {
            context.Tickets.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}

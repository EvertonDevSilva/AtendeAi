using AtendeAi.API.Domain.Entities;
using AtendeAi.API.Infrastructure.Data;
using AtendeAi.API.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AtendeAi.API.Infrastructure.Repositories
{
    public class TicketRepository(AppDbContext context) : ITicketRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<Ticket>> GetAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            var response = await _context.Tickets.SingleOrDefaultAsync(t => t.Id == id);
            return response is null ? throw new Exception("Not found") : response;
        }

        public async Task<List<Ticket>> GetFilterAsync(string? title, string? ticketNumber, DateTime? createAt, DateTime? updatedAt)
        {
            return await _context.Tickets.Where
                (t => 
                      (t.TicketNumber == ticketNumber || string.IsNullOrWhiteSpace(ticketNumber)) 
                      && (t.Title == title || string.IsNullOrWhiteSpace(title)) 
                      && (t.CreatedAt == createAt || createAt == DateTime.MinValue || createAt == null) 
                      && (t.UpdatedAt == updatedAt || updatedAt == DateTime.MinValue || updatedAt == null)
                ).ToListAsync();
        }

        public async Task PostAsync(Ticket entity)
        {
            await _context.Tickets.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task PutAsync(Ticket entity)
        {
            _context.Tickets.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket entity)
        {
            _context.Tickets.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<string> CreateTicketNumber()
        {
            var dataHoje = DateTime.UtcNow.ToString("yyyyMMdd");
            var prefixo = $"TCK-{dataHoje}-";

            var ultimoChamado = await _context.Tickets
                .Where(t => t.TicketNumber.StartsWith(prefixo))
                .OrderByDescending(t => t.TicketNumber)
                .FirstOrDefaultAsync();

            int novoNumero = 1; // Se não houver chamado no dia, começa com 1

            if (ultimoChamado != null)
            {
                var partes = ultimoChamado.TicketNumber.Split('-');
                if (int.TryParse(partes.Last(), out int ultimoNumero))
                {
                    novoNumero = ultimoNumero + 1;
                }
            }

            var novoNumeroChamado = $"TCK-{dataHoje}-{novoNumero:D3}";

            return novoNumeroChamado;

        }
    }
}

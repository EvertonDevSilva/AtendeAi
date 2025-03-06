using AtendeAi.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtendeAi.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=db_atende_ai_api.db");
        }

        public required DbSet<Department> Departments { get; set; }
        public required DbSet<Employee> Employees { get; set; }
        public required DbSet<Ticket> Tickets { get; set; }
        public required DbSet<TicketHistory> TicketHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

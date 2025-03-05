using AtendeAi.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AtendeAi.API.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=db_atende_ai_api.db");
        }

        public required DbSet<Department> Departments;
        public required DbSet<Employee> Employees;
        public required DbSet<Ticket> Tickets;
        public required DbSet<TicketHistory> TicketHistories;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

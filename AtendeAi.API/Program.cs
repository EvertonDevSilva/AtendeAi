
using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Application.Interfaces;
using AtendeAi.API.Application.Services;
using AtendeAi.API.Application.Validators;
using AtendeAi.API.Infrastructure.Data;
using AtendeAi.API.Infrastructure.Interfaces;
using AtendeAi.API.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AtendeAi.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //builder.Services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlite("Data Source=db_atende_ai_api.db"));

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<ITicketService, TicketService>();
            builder.Services.AddScoped<ITicketHistoryService, TicketHistoryService>();

            builder.Services.AddScoped<ITicketRepository, TicketRepository>();
            builder.Services.AddScoped<ITicketHistoryRepository, TicketHistoryRepository>();
            builder.Services.AddScoped<AppDbContext>();

            builder.Services.AddTransient<IValidator<TicketDTO>, TicketValidator>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}

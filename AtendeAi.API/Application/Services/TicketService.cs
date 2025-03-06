using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Application.Interfaces;
using AtendeAi.API.Application.Mappings;
using AtendeAi.API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace AtendeAi.API.Application.Services
{
    public class TicketService(ITicketRepository repository) : ITicketService
    {
        private readonly ITicketRepository repository = repository;

        public async Task<List<TicketResponseDTO>> GetAsync()
        {

            var response = await repository.GetAsync();
            var dto = TicketMapper.ListTicketToListTicketDTO(response);
            return dto;
        }


        public async Task<TicketResponseDTO> GetByIdAsync(int id)
        {
            var entity = await repository.GetByIdAsync(id);
            var dto = TicketMapper.TicketToTicketDTO(entity);
            return dto;
        }

        public async Task<List<TicketResponseDTO>> GetFilterAsync(string? title, string? ticketNumber, DateTime? createAt, DateTime? updatedAt)
        {
            var response =  await repository.GetFilterAsync(title, ticketNumber, createAt, updatedAt);
            var dto = TicketMapper.ListTicketToListTicketDTO(response);
            return dto;
        }

        public async Task PostAsync(TicketDTO value)
        {
            var entity = TicketMapper.TicketDtoToTicket(value);
            entity.TicketNumber = await CreateTicketNumber();
            entity.CreatedAt = DateTime.Now;
            await repository.PostAsync(entity);
        }

        public async Task PutAsync(int Id, TicketDTO value)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");

            entity.Title = value.Title;
            entity.Description = value.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await repository.PutAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");
            await repository.DeleteAsync(entity);
        }

        private async Task<string> CreateTicketNumber()
        {
            return await repository.CreateTicketNumber();
        }
    }
}

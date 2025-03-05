using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Application.Interfaces;
using AtendeAi.API.Application.Mappings;
using AtendeAi.API.Infrastructure.Interfaces;

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

        public async Task<List<TicketResponseDTO>> GetFilterAsync(TicketFilterDTO input)
        {
            var entity = TicketMapper.TicketFilterDtoToTicket(input);
            var response =  await repository.GetFilterAsync(entity);
            var dto = TicketMapper.ListTicketToListTicketDTO(response);
            return dto;
        }

        public async Task PostAsync(TicketDTO input)
        {
            var entity = TicketMapper.TicketDtoToTicket(input);
            await repository.PostAsync(entity);
        }

        public async Task PutAsync(int Id, TicketDTO input)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");

            entity.Title = input.Title;
            entity.Description = input.Description;
            entity.UpdatedAt = DateTime.UtcNow;

            await repository.PutAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            var entity = await repository.GetByIdAsync(Id) ?? throw new Exception("Not found");
            await repository.DeleteAsync(entity);
        }
    }
}

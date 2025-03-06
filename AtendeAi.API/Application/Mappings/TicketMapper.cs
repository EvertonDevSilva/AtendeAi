using AtendeAi.API.Application.DTOs;
using AtendeAi.API.Domain.Entities;

namespace AtendeAi.API.Application.Mappings
{
    public class TicketMapper
    {
        public static List<Ticket> ListTicketDtoToListTicket(List<TicketDTO> dtos)
        {
            var entity = new List<Ticket>();
            dtos.ForEach(dto =>
            {
                entity.Add(new Ticket 
                    {
                        Title = dto.Title,
                        Description = dto.Description
                    }
                );
            });

            return entity;
        }

        public static List<TicketResponseDTO> ListTicketToListTicketDTO(List<Ticket> entities)
        {
            var ticketDtos = new List<TicketResponseDTO>();
            entities.ForEach(entity =>
            {
                ticketDtos.Add
                (
                    new TicketResponseDTO
                    {
                         Id = entity.Id,
                         TicketNumber = entity.TicketNumber,
                         Title = entity.Title,
                         Description = entity.Description,
                         CreatedAt = entity.CreatedAt,
                         UpdatedAt = entity.UpdatedAt
                    }
                );
            });

            return ticketDtos;
        }

        public static TicketResponseDTO TicketToTicketDTO(Ticket entity)
        {
            return new TicketResponseDTO 
            {
                Id = entity.Id,
                TicketNumber = entity.TicketNumber,
                Title = entity.Title,
                Description = entity.Description,
                CreatedAt = entity.CreatedAt,
                UpdatedAt = entity.UpdatedAt
            };
        }

        public static Ticket TicketDtoToTicket(TicketDTO dto)
        {
            return new Ticket
            {
                Title = dto.Title,
                Description = dto.Description
            };
        }
    }
}

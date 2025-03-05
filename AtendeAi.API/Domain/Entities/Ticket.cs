namespace AtendeAi.API.Domain.Entities
{
    public class Ticket : EntityBase
    {
        public string TicketNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

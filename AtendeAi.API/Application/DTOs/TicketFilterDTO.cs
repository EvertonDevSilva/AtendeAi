namespace AtendeAi.API.Application.DTOs
{
    public class TicketFilterDTO
    {
        public string TicketNumber { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}

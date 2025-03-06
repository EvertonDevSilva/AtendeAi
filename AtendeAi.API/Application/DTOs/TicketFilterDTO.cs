namespace AtendeAi.API.Application.DTOs
{
    public class TicketFilterDTO
    {
        public string? TicketNumber { get; set; }
        public string? Title { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

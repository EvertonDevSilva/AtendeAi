namespace AtendeAi.API.Domain.Entities
{
    public class TicketHistory : EntityBase
    {
        public int TicketId { get; set; }
        public Ticket? Ticket { get; set; }
        public ETicketStatus Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        public int CurrentDepartmentId { get; set; }
        public Department? CurrentDepartment { get; set; }
    }
}

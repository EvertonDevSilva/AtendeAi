namespace AtendeAi.API.Domain.Entities
{
    public class Employee : EntityBase
    {
        public string Name { get; set; } = string.Empty;
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}

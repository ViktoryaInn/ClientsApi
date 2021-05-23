using System;

namespace ClientsApi.Schemas
{
    public class PassportDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string Series { get; set; }
        public string Number { get; set; }
        public string Giver { get; set; }
        public DateTime? DateIssued { get; set; }
        public string BirthPlace { get; set; }
    }
}
using System;
using ClientsApi.Enums;

namespace ClientsApi.Schemas
{
    public class JobDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public double MonIncome { get; set; }
        public string FioManager { get; set; }
        public string Tin { get; set; }
        public DateTime? DateEmp { get; set; }
        public DateTime? DateDismissal { get; set; }
        public string Site { get; set; }
        public JobType? Type { get; set; }

        public AddressDto Address { get; set; }

        public string[] PhoneNumbers { get; set; }
    }
}
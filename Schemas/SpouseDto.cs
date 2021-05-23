using System;
using ClientsApi.Enums;

namespace ClientsApi.Schemas
{
    public class SpouseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? Dob { get; set; }

        public PassportDto Passport { get; set; }
        
        public MaritalStatus? MaritalStatus { get; set; }
        public EducationType? TypeEducation { get; set; }
        
        public AddressDto LivingAddress { get; set; }
        public AddressDto RegAddress { get; set; }
        
        public ChildDto[] Children { get; set; }
        public JobDto[] Jobs { get; set; }

        public double GeneralExp { get; set; }
        public double CurFieldExp { get; set; }
        
        public Status? Status { get; set; }
        public EmployeeType? TypeEmp { get; set; }
        public double MonIncome { get; set; }
        public double MonExpences { get; set; }
        
        public Guid[] Files { get; set; }
        public Guid[] Documents { get; set; }
        
        public CommunicationDto[] Communications { get; set; }
    }
}
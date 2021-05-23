using System;
using ClientsApi.Attributes;
using ClientsApi.Enums;
using ClientsApi.Interfaces;

namespace ClientsApi.Schemas
{
    public class ClientDto : ISearchable
    {
        [Sorter] public Guid Id { get; set; }
        [Sorter] public DateTime CreatedAt { get; set; }
        [Sorter] public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        [Sorter] [Searcher] public string Name { get; set; }
        [Sorter] [Searcher] public string Surname { get; set; }
        [Sorter] [Searcher] public string Patronymic { get; set; }
        
        [Sorter] public DateTime? Dob { get; set; }

        public PassportDto Passport { get; set; }
        public SpouseDto Spouse { get; set; }
        public AddressDto LivingAddress { get; set; }
        public AddressDto RegAddress { get; set; }
        public ChildDto[] Children { get; set; }
        public JobDto[] Jobs { get; set; }

        [Sorter] public double GeneralExp { get; set; }
        [Sorter] public double CurFieldExp { get; set; }

        public Status? Status { get; set; }
        public EmployeeType? TypeEmp { get; set; }
        public MaritalStatus? MaritalStatus { get; set; }
        public EducationType? TypeEducation { get; set; }
        
        [Sorter] public double MonIncome { get; set; }
        [Sorter] public double MonExpences { get; set; }

        public Guid[] Files { get; set; }
        public Guid[] Documents { get; set; }

        public CommunicationDto[] Communications { get; set; }
    }
}
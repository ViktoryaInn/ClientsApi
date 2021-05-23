using System;
using System.Collections.Generic;
using ClientsApi.Enums;
using ClientsApi.Interfaces;

namespace ClientsApi.Models
{
    public class Client : ISoftEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime? Dob { get; set; }

        public Passport Passport { get; set; }

        public Guid? SpouseId { get; set; }
        public Client Spouse { get; set; }
        
        public MaritalStatus? MaritalStatus { get; set; }
        public EducationType? TypeEducation { get; set; }
        
        public Guid? LivingAddressId { get; set; }
        public Address LivingAddress { get; set; }
        public Guid? RegAddressId { get; set; }
        public Address RegAddress { get; set; }
        
        public ICollection<Child> Children { get; set; }
        public ICollection<Job> Jobs { get; set; }
        
        public double GeneralExp { get; set; }
        public double CurFieldExp { get; set; }
        
        public Status? Status { get; set; }
        public EmployeeType? TypeEmp { get; set; }
        public double MonIncome { get; set; }
        public double MonExpences { get; set; }
        
        public Guid[] Files { get; set; }
        public Guid[] Documents { get; set; }
        
        public ICollection<Communication> Communications { get; set; }
    }
}
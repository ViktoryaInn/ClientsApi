using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ClientsApi.Enums;
using ClientsApi.Interfaces;

namespace ClientsApi.Models
{
    public class Job : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string CompanyName { get; set; }
        public string JobTitle { get; set; }
        public double MonIncome { get; set; }
        public string FioManager { get; set; }
        public string Tin { get; set; }
        public DateTime DateEmp { get; set; }
        public DateTime DateDismissal { get; set; }
        public string Site { get; set; }
        public JobType? Type { get; set; }
        public Guid? AddressId { get; set; }
        public virtual Address Address { get; set; }
        
        public Guid ClientId { get; set; }
        public virtual Client Client { get; set; }
        public string[] PhoneNumbers { get; set; }
    }
}
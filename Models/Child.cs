using System;
using System.Text.Json.Serialization;
using ClientsApi.Interfaces;

namespace ClientsApi.Models
{
    public class Child : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateTime Dob { get; set; }
        
        [JsonIgnore]
        public Guid ParentId { get; set; }
        [JsonIgnore]
        public virtual Client Parent { get; set; }
    }
}
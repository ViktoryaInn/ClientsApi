using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using ClientsApi.Interfaces;

namespace ClientsApi.Models
{
    public class Passport : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        [RegularExpression(@"^\d{4}$")]
        public string Series { get; set; }
        [RegularExpression(@"^\d{3} \d{3}$")]
        public string Number { get; set; }
        public string Giver { get; set; }
        public DateTime? DateIssued { get; set; }
        public string BirthPlace { get; set; }

        [JsonIgnore]
        public Guid ClientId { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
    }
}
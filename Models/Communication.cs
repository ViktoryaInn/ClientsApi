using System;
using System.Text.Json.Serialization;
using ClientsApi.Enums;

namespace ClientsApi.Models
{
    public class Communication
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public CommunicationType Type { get; set; }
        public string Value { get; set; }
        
        [JsonIgnore]
        public Guid ClientId { get; set; }
        [JsonIgnore]
        public virtual Client Client { get; set; }
    }
}
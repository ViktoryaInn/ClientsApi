using System;
using ClientsApi.Interfaces;
using ClientsApi.Schemas;

namespace ClientsApi.Models
{
    public class User : IEntity
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
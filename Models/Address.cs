using System;
using System.ComponentModel.DataAnnotations;
using ClientsApi.Interfaces;

namespace ClientsApi.Models
{
    public class Address : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public string ZipCode { get; set; }
        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Region is required")]
        public string Region { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Street is required")]
        public string Street { get; set; }
        [Required(ErrorMessage = "House is required")]
        public string House { get; set; }
        public string Block { get; set; }
        public string Apartment { get; set; }
    }
}
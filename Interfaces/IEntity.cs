using System;
using System.Dynamic;

namespace ClientsApi.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime UpdatedAt { get; set; }
    }
}
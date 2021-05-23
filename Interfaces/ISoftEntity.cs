using System;

namespace ClientsApi.Interfaces
{
    public interface ISoftEntity : IEntity
    {
        DateTime? DeletedAt { get; set; }
    }
}
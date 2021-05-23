using System;
using ClientsApi.Enums;

namespace ClientsApi.Schemas
{
    public class CommunicationDto
    {
        public Guid Id { get; set; }
        public CommunicationType Type { get; set; }
        public string Value { get; set; }
    }
}
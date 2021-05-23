using ClientsApi.Interfaces;
using ClientsApi.Models;
using ClientsApi.Schemas;
using Mapster;

namespace ClientsApi.Services
{
    public static class MappingConfiguration
    {
        public static void ConfigureMapper()
        {
            TypeAdapterConfig.GlobalSettings.Default.PreserveReference(true);
            
            TypeAdapterConfig.GlobalSettings
                .ForDestinationType<IEntity>()
                .Ignore(e => e.CreatedAt)
                .Ignore(e => e.UpdatedAt)
                .Ignore(e => e.Id);

            TypeAdapterConfig.GlobalSettings
                .ForType<ClientDto, Client>()
                .Ignore(c => c.SpouseId);

            TypeAdapterConfig.GlobalSettings
                .ForDestinationType<ISoftEntity>()
                .Ignore(e => e.DeletedAt);
        }
    }
}
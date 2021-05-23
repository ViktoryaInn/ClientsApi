using System;
using System.Linq;
using ClientsApi.Enums;
using ClientsApi.Interfaces;
using ClientsApi.Models;
using ClientsApi.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace ClientsApi.Services
{
    public static class DbSetExtension
    {
        public static IIncludableQueryable<Client, Client> IncludeAll(this IQueryable<Client> set)
        {
            return set.Include(c => c.Passport)
                .Include(c => c.Jobs)
                    .ThenInclude(j => j.Address)
                .Include(c => c.LivingAddress)
                .Include(c => c.RegAddress)
                .Include(c => c.Spouse);
        }
    }
}
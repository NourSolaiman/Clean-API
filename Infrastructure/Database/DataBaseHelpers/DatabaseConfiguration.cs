using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database.DatabaseHelpers
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        public void Configure(DbContextOptionsBuilder optionsBuilder, string connectionString)
        {
            optionsBuilder.UseSqlServer(connectionString).AddInterceptors(new CommandLoggingInterceptor()); ;
            // Additional configuration logic here
        }
    }
}
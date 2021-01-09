using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Mensagens.Infra.Contexto
{
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<MyContext>
    {

        private string ConnectionStringName => "PostgreSQL";
        private string GetEnvironment => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        private string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.{GetEnvironment}.json", true)
                .AddEnvironmentVariables()
                .Build();

            return config.GetConnectionString(ConnectionStringName);
        }

        public MyContext CreateDbContext(string[] args)
        {
            var connectionString = GetConnectionString();
            var builder = new DbContextOptionsBuilder<MyContext>();
            builder.UseNpgsql(connectionString);
            return new MyContext(builder.Options);
        }
    }
}
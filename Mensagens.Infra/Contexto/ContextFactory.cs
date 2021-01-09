using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Mensagens.Infra.Contexto
{
    public class ContextFactory : IDesignTimeDbContextFactory<MensagensContext>
    {
        public MensagensContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=localhost; Port=5433; Database=Mensagens; User ID=postgres; Password=postgres;";
            var optionsBuilder = new DbContextOptionsBuilder<MensagensContext>();
            optionsBuilder.UseNpgsql(connectionString);
            return new MensagensContext(optionsBuilder.Options);
        }
    }
}
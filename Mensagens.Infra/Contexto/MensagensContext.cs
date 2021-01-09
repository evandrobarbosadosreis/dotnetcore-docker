using Mensagens.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Infra.Contexto
{
    public class MensagensContext : DbContext
    {
        public DbSet<Mensagem> Mensagens { get; set; }

        public MensagensContext(DbContextOptions<MensagensContext> options) : base(options)
        { }
        
    }
}
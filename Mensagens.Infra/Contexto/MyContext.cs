using Mensagens.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Mensagens.Infra.Contexto
{
    public class MyContext : DbContext
    {
        public DbSet<Mensagem> Mensagens { get; set; }

        public MyContext(DbContextOptions<MyContext> options) : base(options)
        { }
        
    }
}
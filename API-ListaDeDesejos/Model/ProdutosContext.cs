using Microsoft.EntityFrameworkCore;

namespace API_ListaDeDesejos.Model
{
    public class ProdutosContext : DbContext
    {
        public ProdutosContext(DbContextOptions<ProdutosContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<ListaDeDesejos> ListaDeDesejos { get; set; }
        
    }

}

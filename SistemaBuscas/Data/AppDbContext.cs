using Microsoft.EntityFrameworkCore;
using SistemaBuscas.Models;

namespace SistemaBuscas.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options){}

        public DbSet<Condominio> Condominios { get; set; }
        public DbSet<Contato> Contatos { get; set; }
        public DbSet<Debito> Debitos { get; set; }
    }
}

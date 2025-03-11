using api_filmes_senai.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace api_filmes_senai.Context
{
    public class Filmes_Context : DbContext
    {
        public Filmes_Context()
        {
        }

        public Filmes_Context(DbContextOptions<Filmes_Context> options): base(options)
        { 
        }

        // define que as classes se transformarao em tabelas no BD
        
        public DbSet<Genero> Genero { get; set; }
        public DbSet<Filme> Filme { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-U8LA1O3\\SQLEXPRESS; DataBase = filmes; User = sa; Pwd = Senai@134; TrustServerCertificate=true;");
            }
    
        }

    }
}

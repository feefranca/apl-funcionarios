
using apl_api_funcionarios.Models;

using Microsoft.EntityFrameworkCore;

namespace apl_api_funcionarios.Data
{
    public class AplDbContext : DbContext
    {
        public AplDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Telefones> Telefones { get; set; }
        public DbSet<Lider> Liders { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>()
                .HasKey(p => p.cpfFuncionario);
            modelBuilder.Entity<Telefones>()
                .HasKey(p => p.idTelefone);
            modelBuilder.Entity<Lider>()
                .HasKey(p => p.idLider);
            modelBuilder.Entity<Token>()
                .HasKey(p => p.username);
        }
    }
}

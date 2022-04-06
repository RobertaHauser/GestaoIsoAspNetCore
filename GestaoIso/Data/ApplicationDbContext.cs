using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GestaoIso.Data;

namespace GestaoIso.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Dominio> Dominio { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Funcao>().HasOne(c => c.DominioEducacao).WithMany(c => c.FuncaoEducacao).HasForeignKey(c => c.DominioIdEducacao);

            builder.Entity<Dominio>().HasData(new Dominio { DominioId = 1, Descricao = "Analfabeto", Tabela = "Educacao" });
            builder.Entity<Dominio>().HasData(new Dominio { DominioId = 2, Descricao = "Alfabetizado", Tabela = "Educacao" });
            builder.Entity<Dominio>().HasData(new Dominio { DominioId = 3, Descricao = "Fundamental", Tabela = "Educacao" });
            builder.Entity<Dominio>().HasData(new Dominio { DominioId = 4, Descricao = "Médio", Tabela = "Educacao" });
            builder.Entity<Dominio>().HasData(new Dominio { DominioId = 5, Descricao = "Superior", Tabela = "Educacao" });

            builder.Entity<Pessoa>().HasOne(c => c.Funcionario).WithOne(c => c.Pessoa).HasForeignKey<Funcionario>(c => c.PessoaIdFuncionario);

            builder.Entity<Funcionario>().HasOne(c => c.Funcao).WithMany(c => c.Funcionario).HasForeignKey(c => c.FuncaoId);

        }

        public DbSet<GestaoIso.Data.Funcao> Funcao { get; set; }

        public DbSet<GestaoIso.Data.Pessoa> Pessoa { get; set; }

        public DbSet<GestaoIso.Data.Funcionario> Funcionario { get; set; }
    }
}
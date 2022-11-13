using Alura.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>()
                .HasOne(e => e.Cinema)
                .WithOne(c => c.Endereco)
                .HasForeignKey<Cinema>(c => c.EnderecoId);

            builder.Entity<Cinema>()
                .HasOne(c => c.Gerente)
                .WithMany(g => g.Cinemas)
                .HasForeignKey(c => c.GerenteId);

            // Não deixar que o cinema seja excluido com a exclusão do cinema               
            //.OnDelete(DeleteBehavior.Restrict);
            // ou
            // .IsRequired(false);

            builder.Entity<Sessao>()
                .HasOne(s => s.Filme)
                .WithMany(f => f.Sessoes)
                .HasForeignKey(s => s.FilmeId);

            builder.Entity<Sessao>()
               .HasOne(s => s.Cinema)
               .WithMany(c => c.Sessoes)
               .HasForeignKey(s => s.CinemaId);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Gerente> Gerentes { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}

using Alura.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebApi.Data
{
    public class FilmeContext : DbContext
    {
        public FilmeContext(DbContextOptions<FilmeContext> opt) : base(opt)
        {
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}

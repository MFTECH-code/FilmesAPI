using Alura.UsuariosAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alura.UsuariosAPI.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;

        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Criando usuário admin
            var admin = new CustomIdentityUser
            {
                UserName = "admin",
                NormalizedEmail = "ADMIN@EMAIL.COM",
                Email = "admin@email.com",
                NormalizedUserName = "ADMIN",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                Id = 99999
            };

            var hasher = new PasswordHasher<CustomIdentityUser>();

            admin.PasswordHash = hasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" });
            builder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 99998, Name = "regular", NormalizedName = "REGULAR" });
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 });
        }
    }
}

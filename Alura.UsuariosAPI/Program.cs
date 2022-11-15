using Alura.UsuariosAPI.Data;
using Alura.UsuariosAPI.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<UserDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("UsuarioConnection"),
    ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("UsuarioConnection")
)));

builder.Services.AddIdentity<IdentityUser<int>, IdentityRole<int>>()
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

// Configurando como nossa senha pode ser criada
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedEmail = true;
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<EmailService, EmailService>();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseAuthorization();

app.MapControllers();


app.Run();
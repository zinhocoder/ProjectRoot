using ProjectRoot.Services;
using Microsoft.EntityFrameworkCore;
using ProjectRoot.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuração do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuração da chave de token JWT
var key = builder.Configuration["AppSettings:Token"]; // Pega a chave do arquivo appsettings.json

// Verifique se a chave está presente, caso contrário, use uma chave padrão
if (string.IsNullOrEmpty(key) || Encoding.UTF8.GetByteCount(key) < 32)
{
    key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)); // Gera uma chave aleatória de 32 bytes
}

// Registra o TokenService (com a chave)
builder.Services.AddSingleton(new TokenService(key));

// Configuração da autenticação JWT (adicionando ao pipeline de autenticação)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;  // Para facilitar testes locais com HTTP
        options.SaveToken = true;  // Salva o token no contexto de autenticação
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,  // Não valida o emissor do token
            ValidateAudience = false,  // Não valida o público do token
            ValidateLifetime = true,  // Valida a expiração do token
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)) // A chave para validar o token
        };
    });

// Constrói o app
var app = builder.Build();

// Configurações do pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilita o Swagger apenas em ambiente de desenvolvimento
    app.UseSwaggerUI();  // Interface do Swagger para facilitar a documentação
}

app.UseHttpsRedirection();

// Adiciona a autenticação ao pipeline
app.UseAuthentication();  // Habilita a autenticação no pipeline
app.UseAuthorization();   // Habilita a autorização no pipeline

app.MapControllers();  // Mapeia os controllers da API

app.Run();  // Inicia o servidor

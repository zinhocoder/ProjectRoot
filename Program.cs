using ProjectRoot.Services;
using Microsoft.EntityFrameworkCore;
using ProjectRoot.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura��o do banco de dados
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configura��o da chave de token JWT
var key = builder.Configuration["AppSettings:Token"]; // Pega a chave do arquivo appsettings.json

// Verifique se a chave est� presente, caso contr�rio, use uma chave padr�o
if (string.IsNullOrEmpty(key) || Encoding.UTF8.GetByteCount(key) < 32)
{
    key = Convert.ToBase64String(RandomNumberGenerator.GetBytes(32)); // Gera uma chave aleat�ria de 32 bytes
}

// Registra o TokenService (com a chave)
builder.Services.AddSingleton(new TokenService(key));

// Configura��o da autentica��o JWT (adicionando ao pipeline de autentica��o)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;  // Para facilitar testes locais com HTTP
        options.SaveToken = true;  // Salva o token no contexto de autentica��o
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,  // N�o valida o emissor do token
            ValidateAudience = false,  // N�o valida o p�blico do token
            ValidateLifetime = true,  // Valida a expira��o do token
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)) // A chave para validar o token
        };
    });

// Constr�i o app
var app = builder.Build();

// Configura��es do pipeline de middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();  // Habilita o Swagger apenas em ambiente de desenvolvimento
    app.UseSwaggerUI();  // Interface do Swagger para facilitar a documenta��o
}

app.UseHttpsRedirection();

// Adiciona a autentica��o ao pipeline
app.UseAuthentication();  // Habilita a autentica��o no pipeline
app.UseAuthorization();   // Habilita a autoriza��o no pipeline

app.MapControllers();  // Mapeia os controllers da API

app.Run();  // Inicia o servidor

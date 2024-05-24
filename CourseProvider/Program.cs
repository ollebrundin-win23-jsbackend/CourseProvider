using CourseProvider.Contexts;
using CourseProvider.GraphQL;
using CourseProvider.Repos;
using CourseProvider.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //Här sätts default Authenticate schemat i applikationen, till ett Jwt scheme. När autentisering av någon form sker i applikationen kommer man alltså nu utgå från ett Jwt scheme
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // Vi ser även till att samma scheme används när vi eventuellt utför authentication challenges

}).AddJwtBearer(x => //Här lägger vi till och konfigurerar vår JwtBearer
{
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = "Provider",

        ValidateAudience = true,
        ValidAudience = "User",

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Secret")!)), //Det är standard practice att skapa en "Symmetric security key" av vår secret, då det bland annat gör det snäppet säkrare

        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(10)
    };
});
builder.Services.AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization();

builder.Services.AddScoped<CourseRepo>();
builder.Services.AddScoped<CourseService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();

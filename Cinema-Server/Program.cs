using Cinema_Server.Models;
using Cinema_Server.Repositories;
using Cinema_Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Server.Cinema.Interfaces;
using Server.Cinema.Repositories;
using Server.Cinema.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkMySql().AddDbContext<CinemajwtDatabaseContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("admin"), Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.6.5-mariadb"),
        mySqlOptionsAction: mySqlOptions =>
        {
            mySqlOptions.EnableRetryOnFailure();
        });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "https://localhost:7118",
        ValidAudience = "https://localhost:7118",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ma cle secrete"))
    };
});

// REPOSITORIES
builder.Services.AddTransient<ICinemasRepository, CinemasRepository>();
builder.Services.AddTransient<ISallesRepository, SallesRepository>();
builder.Services.AddTransient<IFilmsRepository, FilmsRepository>();
builder.Services.AddTransient<ISeancesRepository, SeancesRepository>();
builder.Services.AddTransient<UsersRepository, UsersRepository>();

// SERVICES
builder.Services.AddTransient<UsersService, UsersService>();
builder.Services.AddTransient<ICinemasService, CinemasService>();
builder.Services.AddTransient<ISallesService, SallesService>();
builder.Services.AddTransient<IFilmsService, FilmsService>();
builder.Services.AddTransient<ISeancesService, SeancesService>();

//Donot forgot to add ConnectionStrings as "dbConnection" to the appsetting.json file
//builder.Services.AddDbContext<DatabaseContext>
//    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("admin")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

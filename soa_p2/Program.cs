using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.IServices;
using Service.Services;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = builder.Configuration;
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<SmtpClient>(serviceProvider =>
{
    string smtpServer = configuration["SmtpConfig:SmtpServer"];
    int smtpPort = Convert.ToInt32(configuration["SmtpConfig:SmtpPort"]);
    string smtpUsername = configuration["SmtpConfig:SmtpUsername"];
    string smtpPassword = configuration["SmtpConfig:SmtpPassword"];
    bool enableSsl = Convert.ToBoolean(configuration["SmtpConfig:EnableSsl"]);

    var smtpClient = new SmtpClient(smtpServer, smtpPort);
    smtpClient.EnableSsl = enableSsl;
    smtpClient.Credentials = new NetworkCredential(smtpUsername, smtpPassword);
    return smtpClient;
});

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyMethod());
});

builder.Services.AddTransient<IPersona, PersonaService>();
builder.Services.AddTransient<IActivo, ActivoService>();
builder.Services.AddTransient<IActivoEmpleado, ActivoEmpleadoService>();
builder.Services.AddTransient<IEmail, CorreoService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();

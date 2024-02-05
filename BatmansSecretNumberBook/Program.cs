global using BatmansSecretNumberBook.Dtos.PersonDto;
global using BatmansSecretNumberBook.Dtos.ContactDto;
global using BatmansSecretNumberBook.Models.PersonModels;
global using BatmansSecretNumberBook.Models.ContactModels;
using BatmansSecretNumberBook.Services.ContactServices;
using BatmansSecretNumberBook.Services.PersonServices;
using BatmansSecretNumberBook.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPersonServiceAsync, PersonService>();
builder.Services.AddScoped<IContactServiceAsync, ContactService>();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

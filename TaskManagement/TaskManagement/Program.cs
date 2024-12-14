using Microsoft.EntityFrameworkCore;
using TaskManagement.Model;
using TaskManagement.Repository;
using TaskManagement.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

builder.Services.RegisterRegistries();
builder.Services.RegisterServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbContext.Database.Migrate(); // Ovo primenjuje sve neprimenjene migracije
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

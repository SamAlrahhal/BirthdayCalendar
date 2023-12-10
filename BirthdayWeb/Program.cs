using BirthdayWeb;
using BirthdayWeb.Data;
using BirthdayWeb.Interfaces;
using BirthdayWeb.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//seed builder
builder.Services.AddScoped<Seed>();
//depency injection
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionstring = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("NO DEFAULT CONNECTION STRING FOUND");
builder.Services.AddDbContext<DataContext>(options =>
{
        options.UseMySQL(connectionstring);
});


var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

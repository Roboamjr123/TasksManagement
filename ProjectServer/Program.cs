using AuthLibrary.Services.Interface;
using AuthLibrary.Services.Repositories;
using DataLibrary.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectServer.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
builder.Services.AddScoped<IProjects, ProjectsRepository>();
builder.Services.AddScoped<ITasks, TasksRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Database
builder.Services.AddDbContext<DataContext>(options => {
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgreSqlConnection"),
    b => b.MigrationsAssembly("ProjectServer")); // Specify the assembly where migrations are defined
});


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

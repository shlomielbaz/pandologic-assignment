using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Domain;
using PA.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

string dbPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../", "PA.Data", "database.db"));

builder.Services.AddDbContext<JobContext>(options =>
    options.UseSqlite($"Filename={dbPath}", options => options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IJobsService, JobsService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCors(o => o.AddPolicy(Constants.CorsApi, builder =>
{
    builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors(Constants.CorsApi);

app.UseAuthorization();

app.MapControllers();

app.Run();


using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PA.Domain;

namespace PA.Data;

public class JobContext : DbContext
{
	public JobContext() : base() { }

    public JobContext(DbContextOptions<JobContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string dbPath = Path.GetFullPath(Path.Combine(Environment.CurrentDirectory, @"../", "PA.Data", "database.db"));

        optionsBuilder.UseSqlite($"Filename={dbPath}", options =>
        {
            options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
        });
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Job> Jobs { get; set; } = default!;
    

    protected override void OnModelCreating(ModelBuilder modelBuilder) {

        modelBuilder.Seed();
    }
}


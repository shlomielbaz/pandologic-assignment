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
        //modelBuilder.Entity<Job>().HasData(
        //    new Job()
        //    {
        //        Id = 1,
        //        Date = new DateTime(2014, 2, 12),
        //        TotalJobs = 3,
        //        TotalViews = 0,
        //        PredictedViews = 0,
        //    },
        //    new Job()
        //    {
        //        Id = 2,
        //        Date = new DateTime(2014, 2, 13),
        //        TotalJobs = 3,
        //        TotalViews = 1,
        //        PredictedViews = 1,
        //    },
        //    new Job()
        //    {
        //        Id = 3,
        //        Date = new DateTime(2014, 2, 14),
        //        TotalJobs = 3,
        //        TotalViews = 2,
        //        PredictedViews = 3,
        //    },
        //    new Job()
        //    {
        //        Id = 4,
        //        Date = new DateTime(2014, 2, 15),
        //        TotalJobs = 11,
        //        TotalViews = 5,
        //        PredictedViews = 3,
        //    },
        //    new Job()
        //    {
        //        Id = 5,
        //        Date = new DateTime(2014, 2, 16),
        //        TotalJobs = 2,
        //        TotalViews = 6,
        //        PredictedViews = 4,
        //    },
        //    new Job()
        //    {
        //        Id = 6,
        //        Date = new DateTime(2014, 2, 17),
        //        TotalJobs = 6,
        //        TotalViews = 7,
        //        PredictedViews = 8,
        //    }
        //);
    }
}


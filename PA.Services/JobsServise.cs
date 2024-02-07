using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PA.Data;
using PA.Domain;

namespace PA.Services;
public class JobsService : IJobsService
{
    private readonly Repository<JobContext> db;

    public JobsService(IRepository<JobContext> repository)
    {
        db = (Repository<JobContext>)repository;
    }

    public void Add(Job entity)
    {
        db.Add<Job>(entity);

        db.Save();
    }

    public void Delete(long id)
    {
        var entity = this.Get(id);
        if (entity != null)
        {
            db.Delete<Job>(entity);
        }
        else
        {
            throw new Exception("The item you ment to delete dosen't exist");
        }
    }

    public bool Exists(long id)
    {
        return this.Get(id) != null;
    }

    public IEnumerable<Job> Get()
    {
        return db.GetList<Job>();
    }

    public Job Get(long id)
    {
        return db.Get<Job>(e => e.Id == id);
    }

    public IEnumerable<Job> GetBy(Expression<Func<Job, bool>> predicate)
    {
        return db.GetList<Job>(predicate);
    }

    public void Update(Job entity)
    {
        try
        {
            db.Update(entity);
        }
        catch (DbUpdateConcurrencyException)
        {
            throw;
        }
    }
}


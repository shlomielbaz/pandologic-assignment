using System.Linq.Expressions;
using PA.Domain;

namespace PA.Services;
public class JobsService : IJobsService
{
    public void Add(Job entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(long id)
    {
        throw new NotImplementedException();
    }

    public bool Exists(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Job> Get()
    {
        throw new NotImplementedException();
    }

    public Job Get(long id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Job> GetBy(Expression<Func<Job, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public void Update(Job entity)
    {
        throw new NotImplementedException();
    }
}


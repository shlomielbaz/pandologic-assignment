using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PA.Domain;

namespace PA.Data;

public class Repository<C> : IDisposable, IRepository<C>
     where C : DbContext, new()
{
    private C? dataContext;

    private static readonly object addEntityObject = new object();

    public virtual C DataContext
    {
        get
        {
            if (dataContext == null)
            {
                dataContext = new C();
            }

            return dataContext;
        }
    }

    public virtual void Add<T>(T entity)
        where T : class
    {
        DataContext.Set<T>().Add(entity);
    }

    public virtual bool Any<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return DataContext.Set<T>().Any(predicate);
    }

    public virtual int Count<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return DataContext.Set<T>().Count(predicate);
    }

    public virtual T Get<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return DataContext.Set<T>().Where(predicate).SingleOrDefault();
    }

    public virtual IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        return DataContext.Set<T>().Where(predicate);
    }

    public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
        Expression<Func<T, TKey>> orderBy)
        where T : class
    {
        return GetList(predicate, OrderByType.Ascending, orderBy);
    }

    public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate,
        OrderByType orderByType, Expression<Func<T, TKey>> orderBy)
        where T : class
    {
        if (orderByType == OrderByType.Ascending)
        {
            return GetList(predicate).OrderBy(orderBy);
        }
        else
        {
            return GetList(predicate).OrderByDescending(orderBy);
        }
    }

    public virtual IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy)
        where T : class
    {
        return GetList<T, TKey>(OrderByType.Ascending, orderBy);
    }

    public virtual IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy)
        where T : class
    {
        if (orderByType == OrderByType.Ascending)
        {
            return GetList<T>().OrderBy(orderBy);
        }
        else
        {
            return GetList<T>().OrderBy(orderBy);
        }
    }

    public virtual IQueryable<T> GetList<T>()
        where T : class
    {
        return DataContext.Set<T>();
    }

    public virtual void Update<T>(T entity) where T : BaseEntity
    {
        var entry = DataContext.Entry<T>(entity);

        if (entry.State == EntityState.Detached)
        {
            var set = DataContext.Set<T>();
            T attachedEntity = set.Find(entity.Id);

            if (attachedEntity != null)
            {
                var attachedEntry = DataContext.Entry(attachedEntity);
                attachedEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }
    }

    public virtual void Delete<T>(T entity)
        where T : class
    {
        DataContext.Set<T>().Remove(entity);
    }

    public virtual void Delete<T>(Expression<Func<T, bool>> predicate)
        where T : class
    {
        T entity = this.Get<T>(predicate);

        if (entity != null)
        {
            this.Delete<T>(entity);
        }
    }

    public async System.Threading.Tasks.Task DeleteAsync<T>(T entity)
        where T : class
    {
        await System.Threading.Tasks.Task.Run(() => Delete<T>(entity));
    }

    public virtual void DeleteAll<T>(ICollection<T> collection)
        where T : class
    {
        DbSet<T> dbSet = DataContext.Set<T>();
        collection.ToList<T>().ForEach(x => dbSet.Remove(x));
    }

    public async System.Threading.Tasks.Task DeleteAllAsync<T>(ICollection<T> collection)
        where T : class
    {
        await System.Threading.Tasks.Task.Run(() => DeleteAll(collection));
    }

    public virtual OperationStatus Save(string message = null)
    {
        OperationStatus operationStatus = new OperationStatus();

        try
        {
            DataContext.SaveChanges();
        }
        catch (DbUpdateException e)
        {
            operationStatus.Status = false;
            operationStatus.Message = message;
            operationStatus.Exception = e;
            return operationStatus;
        }

        operationStatus.Status = true;
        return operationStatus;
    }
    public virtual OperationStatus SaveAync(string message = null)
    {
        OperationStatus operationStatus = new OperationStatus();

        try
        {
            DataContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            operationStatus.Status = false;
            operationStatus.Message = message;
            operationStatus.Exception = exception;
            return operationStatus;
        }

        operationStatus.Status = true;
        return operationStatus;
    }

    public void Dispose()
    {
        if (DataContext != null)
        {
            DataContext.Dispose();
        }
    }
}
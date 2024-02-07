using System.Buffers;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace PA.Domain;

public interface IRepository<C> where C : DbContext
{
    public void Add<T>(T entity) where T : class;
    public bool Any<T>(Expression<Func<T, bool>> predicate) where T : class;
    public int Count<T>(Expression<Func<T, bool>> predicate) where T : class;
    public T Get<T>(Expression<Func<T, bool>> predicate) where T : class;
    public IQueryable<T> GetList<T>(Expression<Func<T, bool>> predicate) where T : class;
    public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy) where T : class;
    public IQueryable<T> GetList<T, TKey>(Expression<Func<T, bool>> predicate, OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class;
    public IQueryable<T> GetList<T, TKey>(Expression<Func<T, TKey>> orderBy) where T : class;
    public IQueryable<T> GetList<T, TKey>(OrderByType orderByType, Expression<Func<T, TKey>> orderBy) where T : class;
    public IQueryable<T> GetList<T>() where T : class;
    public void Update<T>(T entity) where T : BaseEntity;
    public void Delete<T>(T entity) where T : class;
    public void Delete<T>(Expression<Func<T, bool>> predicate) where T : class;
    public System.Threading.Tasks.Task DeleteAsync<T>(T entity) where T : class;
    public void DeleteAll<T>(ICollection<T> collection) where T : class;
    public System.Threading.Tasks.Task DeleteAllAsync<T>(ICollection<T> collection) where T : class;
    public OperationStatus Save(string message);
    public OperationStatus SaveAync(string message);
}


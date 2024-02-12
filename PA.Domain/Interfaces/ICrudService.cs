namespace PA.Domain;
public interface ICrudService<E, VM>
    where E : BaseEntity, new()
    where VM : IViewModel, new()
{
    public IEnumerable<VM> Get();
    public VM Get(long id);
    public E GetEntity(long id);
    public void Update(VM model);
    public void Add(VM model);
    public void Delete(long id);
    public bool Exists(long id);
    // public IEnumerable<VM> GetBy(Expression<Func<E, bool>> predicate);
}
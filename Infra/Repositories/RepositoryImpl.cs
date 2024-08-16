namespace Infra.Repositories;

public class RepositoryImpl<T> : IRepository<T> where T : class
{
    private readonly SqlServerDbContext _dbContext;
    public RepositoryImpl(SqlServerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public T Create(T value)
    {
        var data = _dbContext.Set<T>().Add(value);
        _dbContext.SaveChanges();

        return data.Entity;
    }

    public T Delete(Guid id)
    {
        var data = _dbContext.Set<T>().Remove(FindById(id));
        _dbContext.SaveChanges();

        return data.Entity;
    }

    public IEnumerable<T> FindAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T? FindById(Guid id)
    {
        return _dbContext.Set<T>().Find(id);
    }

    public T Update(Guid id, T value)
    {
        var entidadeExistente = _dbContext
        .Set<T>()
        .Find(id);

        _dbContext.Set<T>().Entry(entidadeExistente).CurrentValues.SetValues(value);
        _dbContext.SaveChanges();

        return entidadeExistente;
    }
}

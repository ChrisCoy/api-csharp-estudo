namespace Infra.Repositories;

public interface IRepository<T>
{
    public IEnumerable<T> FindAll();

    public T? FindById(Guid id);

    public T Create(T value);

    public T Update(Guid id, T value);

    public T Delete(Guid id);
}

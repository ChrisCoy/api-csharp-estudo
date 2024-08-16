
namespace Infra.Repositories;

public interface IUserRepository : IRepository<User>
{
}

public class UsersRepository : RepositoryImpl<User>, IUserRepository
{
    public UsersRepository(SqlServerDbContext dbContext) : base(dbContext)
    {
    }
}

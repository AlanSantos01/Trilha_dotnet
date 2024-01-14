using CleanArchitecture.Domain.Entities;
namespace CleanArchitecture.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<List<User>> GetAll(CancellationToken cancellationToken);
    Task<User> GetByEmail(string email, CancellationToken cancellationToken);

}

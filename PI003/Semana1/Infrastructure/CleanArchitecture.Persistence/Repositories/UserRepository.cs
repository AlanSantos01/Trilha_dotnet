using System.Security.Cryptography.X509Certificates;
using CleanArchitecture.Domain.Interfaces;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Persistence.Repositories;

public class UserRepository : BaseRepository<User> , IUserRepository
{
    public UserRepository(AppDbContext context): base(context){}
    public async Task<User> GetByEmail(string email, CancellationToken cancellationToken){
        return await Context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
    }

}

using ChallengeClean.Domain.Entities;

namespace ChallengeClean.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    
    DbSet<Person> Persons { get; }
    DbSet<Address> Addresses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}

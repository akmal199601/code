using Entities.Models;

namespace Contracts.AccountRepository;

public interface IAccountRepository : IRepositoryBase<Account>
{
    IEnumerable<Account> AccountByOwner(Guid ownerId);
}
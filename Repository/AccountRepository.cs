using Contracts.AccountRepository;
using Entities;
using Entities.Models;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>,IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext) :base (repositoryContext)
    {
        
    }

    public IEnumerable<Account> AccountByOwner(Guid ownerId)
    {
        return FindByCondition(a => a.OwnerId.Equals(ownerId)).ToList();
    }
}
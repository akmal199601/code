using System.Linq.Expressions;
using Entities.Models;

namespace Contracts;

public class IOwnerRepository : IRepositoryBase<Owner>
{
    public IQueryable<Owner> FindAll()
    {
        throw new NotImplementedException();
    }

    public IQueryable<Owner> FindByCondition(Expression<Func<Owner, bool>> expression)
    {
        throw new NotImplementedException();
    }

    public void Create(Owner entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Owner entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Owner entity)
    {
        throw new NotImplementedException();
    }
}
using Contracts;
using Entities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
            
        }
        public IEnumerable<Owner> GetOwners(OwnerParametrs ownerParametrs)
        {
             
            return FindAll()
                .OrderBy(on => on.Name)
                .Skip(ownerParametrs.PageNUmber - 1 * ownerParametrs.PageSize)
                .Take(ownerParametrs.PageSize)
                .ToList();
        }
        public IEnumerable<Owner> GetAllOwners()
        {
            return FindAll()
                .OrderBy(ow => ow.Name)
                .ToList();
        }
        public Owner GetOwnerById(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
                .FirstOrDefault();
        }

        public Owner GetOwnerWithDetails(Guid ownerId)
        {
            return FindByCondition(owner => owner.OwnerId.Equals(ownerId))
                .Include(ac => ac.Accounts)
                .FirstOrDefault();
        }
        public void CreateOwner(Owner owner)
        {
            CreateOwner(owner);
        }
        public void UpdateOwner(Owner owner)
        {
            UpdateOwner(owner);
        }
        public void DeleteOwner(Owner owner)
        {
            DeleteOwner(owner);
        }
        private void SearchByName(ref IQueryable<Owner> owners, string ownerName)
        {
            if (!owners.Any() || string.IsNullOrWhiteSpace(ownerName))
                return;
            owners = owners.Where(o => o.Name.ToLower().Contains(ownerName.Trim().ToLower()));
        }
    }
}
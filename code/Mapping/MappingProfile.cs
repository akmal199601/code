using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
namespace code.Mapping;
public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDto>();
        CreateMap<Account, AccountDto>();
        CreateMap<OwnerForUpdateDto, Owner>();
    }
}
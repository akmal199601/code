using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace code.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repWrapper;
    private IMapper _mapper;

    public OwnerController(ILoggerManager logger,IRepositoryWrapper repository,IMapper mapper)
    {
        _logger = logger;
        _repWrapper = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owners = _repWrapper.Owner.GetAllOwners();
            _logger.LOgInfo("Returned all owners from database");
            var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
            return Ok(ownersResult);
        }
        catch (Exception ex)
        {
          _logger.LOgError($"Something went wrong inside GetAllOwners action :{ex.Message}");
          return StatusCode(500, "INterner server error");
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetOwnerById(Guid id)
    {
        try
        {
            var owner = _repWrapper.Owner.GetOwnerById(id);
            if (owner is null)
            {
                _logger.LOgError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            else
            {
                _logger.LOgError($"Returned owner with id: {id}");
                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult); 
            }
        }
        catch (Exception ex)
        {
            _logger.LOgError($"Something went wrong inside GetOwnerById action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
    
}
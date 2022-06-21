using AutoMapper;
using Contracts;
using Entities.DataTransferObjects;
using Entities.Models;
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

    [HttpGet("{id}/account")]
    public IActionResult GetOwnerWithDetails(Guid id)
    {
        try
        {
            var owner = _repWrapper.Owner.GetOwnerWithDetails(id);
            if (owner == null)
            {
                _logger.LOgError($"Owner with id: {id}, hasn't been found in db.");
                return NotFound();
            }
            else
            {
                _logger.LOgInfo($"Returned owner with details for id {id}");
                var ownerResult = _mapper.Map<OwnerDto>(owner);
                return Ok(ownerResult);
            }
        }
        catch (Exception ex)
        {
         _logger.LOgError($"Something went wrong inside GetOwnerWithDetails action:{ex.Message} ");
         return StatusCode(500,"Internet server error!");
        }
    }
    [HttpPost]
    [HttpPost]
    public IActionResult CreateOwner([FromBody]OwnerForCreationDto owner)
    {
        try
        {
            if (owner is null)
            {
                _logger.LOgError("Owner object sent from client is null.");
                return BadRequest("Owner object is null");
            }

            if (!ModelState.IsValid)
            {
                _logger.LOgError("Invalid owner object sent from client.");
                return BadRequest("Invalid model object");
            }

            var ownerEntity = _mapper.Map<Owner>(owner);

            _repWrapper.Owner.CreateOwner(ownerEntity);
            _repWrapper.Save();

            var createdOwner = _mapper.Map<OwnerDto>(ownerEntity);

            return CreatedAtRoute("OwnerById", new { id = createdOwner.Id }, createdOwner);
        }
        catch (Exception ex)
        {
            _logger.LOgError($"Something went wrong inside CreateOwner action: {ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}
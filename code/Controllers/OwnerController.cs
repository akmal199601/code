using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace code.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OwnerController : ControllerBase
{
    private ILoggerManager _logger;
    private IRepositoryWrapper _repWrapper;

    public OwnerController(ILoggerManager logger,IRepositoryWrapper repository)
    {
        _logger = logger;
        _repWrapper = repository;
    }

    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var owners = _repWrapper.Owner.GetAllOwners();
            _logger.LOgInfo("Returned all owners from database");
            return Ok(owners);
        }
        catch (Exception ex)
        {
          _logger.LOgError($"Something went wrong inside GetAllOwners action :{ex.Message}");
          return StatusCode(500, "INterner server error");
        }
    }
}
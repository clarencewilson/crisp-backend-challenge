using CRISP.BackendChallenge.Context.Models;
using CRISP.BackendChallenge.Models;
using CRISP.BackendChallenge.Repository;
using CRISP.BackendChallenge.Service;
using Microsoft.AspNetCore.Mvc;

namespace CRISP.BackendChallenge.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly ILogger<EmployeeController> _logger;
    private IEmployeeService _employeeService;

    public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService employeeService)
    {
        _logger = logger;
        _employeeService = employeeService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        _logger.LogDebug(":: Performing {MethodName}", nameof(GetAll));

        var result = _employeeService.GetAll();
        if(result == null)
        {
            return NotFound();
        }
        
        return Ok(result);
    }

    // TODO: Implement Search By Id
    [HttpGet]
    [Route("{id}")]
    public IActionResult GetById(int id)
    {
        _logger.LogDebug(":: Performing {MethodName}", nameof(GetById));

        var result = _employeeService.GetById(id);
        if(result == null)
            return NotFound();
        
        return Ok(result);
    }

    // TODO: Implement Delete by Id
    [HttpDelete]
    public IActionResult Delete(int id)
    {
        _logger.LogDebug(":: Performing {MethodName}", nameof(Delete));

        var result = _employeeService.Delete(id);
        if(result == false)
            return BadRequest();
        
        return Ok();
    }

    // TODO: Implement Update by Id
    [HttpPut]
    public IActionResult Update(EmployeeResponse body)
    {
        _logger.LogDebug(":: Performing {MethodName}", nameof(Update));

        var result = _employeeService.Update(body);
        if (result == null)
            return BadRequest();

        return Ok();
    }

    [HttpPost]
    public IActionResult Add(EmployeeResponse body)
    {
        _logger.LogDebug(":: Performing {MethodName}", nameof(Update));

        var result = _employeeService.Add(body);
        if (result == false)
            return BadRequest();

        return Ok();
    }
}
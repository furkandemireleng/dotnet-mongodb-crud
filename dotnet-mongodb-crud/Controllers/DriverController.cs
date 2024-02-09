using dotnet_mongodb_crud.Model;
using dotnet_mongodb_crud.Service;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_mongodb_crud.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriverController : ControllerBase
{
    private readonly DriverService _driverService;

    public DriverController(DriverService driverService) => _driverService = driverService;

    [HttpGet("{id:length(24)}")]
    public async Task<IActionResult> GetDriver(string id)
    {
        var findedDriver = await _driverService.GetDriver(id);

        if (findedDriver is null)
        {
            return NotFound();
        }

        return Ok(findedDriver);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDrivers()
    {
        var allDrivers = await _driverService.GetDrivers();

        if (allDrivers.Any())
        {
            return Ok(allDrivers);
        }

        return NotFound();
    }


    [HttpPost]
    public async Task<IActionResult> Post(Driver driver)
    {
        await _driverService.Create(driver);

        return Ok();
    }
    
    
    [HttpPut]
    public async Task<IActionResult> Update(string id,Driver driver)
    {
        var findedDriver = await _driverService.GetDriver(id);

        if (findedDriver is null)
        {
            return NotFound();
        }

        await _driverService.Update(driver: driver);

        return Ok();
    }


    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var findedDriver = await _driverService.GetDriver(id);

        if (findedDriver is null)
        {
            return NotFound();
        }

        await _driverService.Remove(id);

        return NoContent();
    
        
    }

    
    
}
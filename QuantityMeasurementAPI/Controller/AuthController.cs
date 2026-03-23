using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppBusinessLayer.Services;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMeasurementService _measurementServices;
    public AuthController()
    {
        _measurementServices = new MeasurementService();
    }

    // [HttpPost("register")]
    // public IActionResult Register([FromQuery] string userName, [FromQuery] string password)
    // {
    //     var res = _measurementServices(userName, password);
    //     return Ok(res);
    // }
}
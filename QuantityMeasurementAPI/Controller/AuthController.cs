using Microsoft.AspNetCore.Mvc;
using QuantityMeasurementAppBusinessLayer.Interface;
using QuantityMeasurementAppBusinessLayer.Services;
using QuantityMeasurementAppModelLayer.DTO;

[Route("auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authServices;
    public AuthController(IAuthService authServices)
    {
        _authServices = authServices;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterDTO registerDTO)
    {

        var res = _authServices.Register(registerDTO);
        return Ok(res);

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDTO loginDTO)
    {

        var res = _authServices.Login(loginDTO);
        return Ok(res);
    }
}
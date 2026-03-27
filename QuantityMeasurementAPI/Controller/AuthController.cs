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
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {

        var res = await _authServices.Register(registerDTO);
        return Ok(res);

    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
    {

        var res = await _authServices.Login(loginDTO);
        if (res == null)
        {
            return Unauthorized(new { Message = "Invalid email or password." });
        }
        return Ok(res);
    }
}
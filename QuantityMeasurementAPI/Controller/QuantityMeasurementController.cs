using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.DTO;

using QuantityMeasurementAppBusinessLayer.Interface;
using Microsoft.AspNetCore.Authorization;
namespace QuantityMeasurementAPI.Controller;         

[Route("api/")]
[ApiController]
[Authorize]
public class QuantityMeasurementController : ControllerBase
{
    private readonly IMeasurementService _measurementService;
    
    public QuantityMeasurementController(IMeasurementService measurementService)
    {
        _measurementService = measurementService;
    }

    [HttpPost("conversion")]
    public async Task<IActionResult> QuantityMeasurementConversion([FromBody] QuantityDTO newEntity, [FromQuery] string toUnit)
    {
        // Must 'await' the async service call
        var res = await _measurementService.PerformConversion(newEntity, toUnit);
        
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }

    [HttpPost("addition")]
    public async Task<IActionResult> QuantityMeasurementAddition([FromBody] ArithmeticDTO newEntity, [FromQuery] string toUnit)
    {
        var res = await _measurementService.PerformAddition(newEntity.Quantity1, newEntity.Quantity2, toUnit);
        
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }

    [HttpPost("subtraction")]
    public async Task<IActionResult> QuantityMeasurementSubtraction([FromBody] ArithmeticDTO newEntity, [FromQuery] string toUnit)
    {
        var res = await _measurementService.PerformSubtraction(newEntity.Quantity1, newEntity.Quantity2, toUnit);
        
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }
}
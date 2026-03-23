using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuantityMeasurementAppModelLayer.Entity;
using QuantityMeasurementAppModelLayer.DTO;
using QuantityMeasurementAppBusinessLayer.Services;

namespace QuantityMeasurementAPI.Controller;

[Route("api/")]
[ApiController]
public class QuantityMeasurementController : ControllerBase
{
    private readonly IMeasurementService _measurementService;
    public QuantityMeasurementController()
    {
        _measurementService = new MeasurementService();
    }

    [HttpPost("conversion")]
    public IActionResult QuantityMeasurementConversion([FromBody] QuantityDTO newEntity, [FromQuery] string toUnit)
    {

        var res = _measurementService.PerformConversion(newEntity, toUnit.Trim().ToUpper());
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }
    [HttpPost("addition")]
    public IActionResult QuantityMeasurementAddition([FromBody] ArithmeticDTO newEntity, [FromQuery] string toUnit)
    {

        var res = _measurementService.PerformAddition(newEntity.Quantity1, newEntity.Quantity2, toUnit.Trim().ToUpper());
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }
    [HttpPost("subtraction")]
    public IActionResult QuantityMeasurementSubtraction([FromBody] ArithmeticDTO newEntity, [FromQuery] string toUnit)
    {

        var res = _measurementService.PerformSubtraction(newEntity.Quantity1, newEntity.Quantity2, toUnit.Trim().ToUpper());
        return Ok(new
        {
            Value = res.Value,
            Unit = res.Unit
        });
    }
}

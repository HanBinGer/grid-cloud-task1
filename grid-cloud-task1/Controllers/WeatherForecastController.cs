using grid_cloud_task1.Database;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace grid_cloud_task1.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(AppDbContext context, ILogger<WeatherForecastController> logger) : ControllerBase
{

    [HttpGet("")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        try
        {
            return context.forecasts.Select(forecast => forecast)
            .ToArray();
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(503);
        }
    }

    [HttpGet("{Id}")]
    public ActionResult<WeatherForecast> GetForecast(int Id)
    {
        try
        {
            var forecast = context.forecasts.FirstOrDefault(forecast => forecast.Id == Id);
            if (forecast == null)
            {
                return NotFound();
            }
            return Ok(forecast);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(503);
        }
    }

    [HttpPost]
    public IActionResult Post([FromBody] WeatherForecast forecast)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var tracking = context.forecasts.Add(forecast);
            context.SaveChanges();
            forecast.Id = tracking.Entity.Id;
            // Return a 201 Created response with the created resource
            return CreatedAtAction("GetForecast", new { Id = forecast.Id }, forecast);
        }
        catch (InvalidOperationException ex)
        {
            return StatusCode(503);
        }
    }
}

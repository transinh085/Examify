using Microsoft.AspNetCore.Mvc;
using Notification;

namespace Examify.Notification.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly Classroom.ClassroomClient _classroomClient;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        Classroom.ClassroomClient classroomClient)
    {
        _logger = logger;
        _classroomClient = classroomClient;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var classroom = _classroomClient.GetClassroom(new ClassroomRequest { Id = id });
        _logger.LogInformation("Classroom: {classroom}", classroom);
        return Ok(classroom);
    }
}
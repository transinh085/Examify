using Examify.Notification.Services;
using Microsoft.AspNetCore.Mvc;
using Notification;

namespace Examify.Notification.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly Classroom.ClassroomClient _classroomClient;
    private readonly EmailService _emailService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        Classroom.ClassroomClient classroomClient,
        EmailService emailService)
    {
        _logger = logger;
        _classroomClient = classroomClient;
        _emailService = emailService;
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
        var classroom = _classroomClient.GetClassroom(new ClassroomRequest { Id = id });
        _logger.LogInformation("Classroom: {classroom}", classroom);
        return Ok(classroom);
    }
    
    [HttpPost("send-email")]
    public async Task<IActionResult> SendEmail([FromBody] EmailRequest emailRequest)
    {
        await _emailService.SendEmailAsync(emailRequest.ToEmail, emailRequest.Subject, emailRequest.Message);
        return Ok("Email sent successfully");
    }
}

public class EmailRequest
{
    public string ToEmail { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}
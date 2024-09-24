using System.Net;

namespace Examify.Core.Exceptions;

public class BadRequestException : CustomException
{
    public BadRequestException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest) : base(message, statusCode)
    {
    }
}
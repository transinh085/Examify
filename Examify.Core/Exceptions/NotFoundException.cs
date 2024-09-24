using System.Net;

namespace Examify.Core.Exceptions;

public class NotFoundException : CustomException
{
    public NotFoundException(string message, HttpStatusCode statusCode = HttpStatusCode.NotFound) : base(message, statusCode)
    {
    }
}
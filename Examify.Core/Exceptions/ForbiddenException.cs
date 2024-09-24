using System.Net;

namespace Examify.Core.Exceptions;

public class ForbiddenException : CustomException
{
    public ForbiddenException(string message, HttpStatusCode statusCode = HttpStatusCode.Forbidden) : base(message, statusCode)
    {
    }
}
using Microsoft.AspNetCore.Http.HttpResults;

namespace Examify.Core.Reponse;

public class BaseResponse
{
    public bool Success { get; set; }
    
    public string Message { get; set; }
    public object Data { get; set; }
    
    public DateTime Time { get; set; }

    public static IResult SendSuccess(object data, string message = "Operation successful")
    {
        return Results.Ok(new BaseResponse
        {
            Success = true,
            Message = message,
            Data = data,
            Time = DateTime.Now
        });
    }
    
    public static IResult SendFail(object data, string message = "Operation failed")
    {
        return Results.Conflict(new BaseResponse
        {
            Success = false,
            Message = message,
            Data = data,
            Time = DateTime.Now
        });
    }
}

public class BaseResponse<T> : BaseResponse
{
    public new T Data
    {
        get { return (T)base.Data; }
        set { base.Data = value; }
    }
}
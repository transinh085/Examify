using Examify.Result.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace Examify.Result.Hubs;

public class ResultHub : Hub<IResultHub>
{
    
}
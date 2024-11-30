using Examify.Notification.Dtos;

namespace Examify.Notification.Grpc.Clients;

public interface INotificationMetaService
{
    Task<IdentityDto> GetIdentityAsync(Guid? Id);
}
using Examify.Notification.Dtos;
using Notification;

namespace Examify.Notification.Grpc.Clients;

public class NotificationMetaService(Identity.IdentityClient identityClient) : INotificationMetaService
{
    public Task<IdentityDto> GetIdentityAsync(Guid? Id)
    {
        if (Id == Guid.Empty) return null;
        var owner = identityClient.GetIdentity(new IdentityRequest { Id = Id.ToString() });
        return Task.FromResult(new IdentityDto
        {
            Id = owner.Id,
            FullName = owner.Name,
            Image = owner.Image
        });
    }
}
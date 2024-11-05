using AutoMapper;
using Examify.Identity.Dtos;
using Examify.Identity.Interfaces;
using MediatR;

namespace Examify.Identity.Features.GetSelf;

public class GetSelfHandler(IUserRepository userRepository, IMapper mapper)
    : IRequestHandler<GetSelfQuery, IResult>
{
    public async Task<IResult> Handle(GetSelfQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.username);
        return TypedResults.Ok(mapper.Map<AppUserDto>(user));
    }
}
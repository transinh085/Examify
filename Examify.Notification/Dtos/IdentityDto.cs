using AutoMapper;

namespace Examify.Notification.Dtos;

public class IdentityDto
{
    public string? Id { get; set; }
    public string FullName { get; set; }
    public string Image { get; set; }
}

public class UserDto
{
	public string Id { get; set; }
	public string Name { get; set; }
	public string Avatar { get; set; }
}

public class MappingProfile : Profile
{
	public MappingProfile()
	{
		CreateMap<IdentityDto, UserDto>()
			.ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
			.ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Image));
	}
}
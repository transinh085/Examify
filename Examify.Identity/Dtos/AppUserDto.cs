using AutoMapper;
using Examify.Identity.Entities;

namespace Examify.Identity.Dtos;

public class AppUserDto
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Image { get; set; }  
    private class AppUserDtoProfile : Profile
    {
        public AppUserDtoProfile()
        {
            CreateMap<AppUser, AppUserDto>();
        }
    }
}
namespace Examify.Identity.Features.Query.GetUsers;

public class GetSelfResponse
{
    public string Email { get; set; }
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName { get; set; }
    public string Image  { get; set; }
}
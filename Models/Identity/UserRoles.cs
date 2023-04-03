using Microsoft.AspNetCore.Identity;

namespace Models.Identity;

public class UserRoles : IdentityRole
{
    public const string Admin = "Admin";
    public const string User = "User";
}

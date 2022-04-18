using Microsoft.AspNetCore.Identity;

namespace Portfolio.DataAccess;

public class User: IdentityUser
{
    public int Year { get; set; }
}
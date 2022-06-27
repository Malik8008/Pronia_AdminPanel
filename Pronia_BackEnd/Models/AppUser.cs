using Microsoft.AspNetCore.Identity;

namespace Pronia_BackEnd.Models
{
    public class AppUser:IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

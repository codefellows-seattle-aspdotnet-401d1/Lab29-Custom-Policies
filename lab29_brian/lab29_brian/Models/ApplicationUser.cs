using Microsoft.AspNetCore.Identity;

namespace lab29_brian.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

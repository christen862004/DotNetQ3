using Microsoft.AspNetCore.Identity;

namespace DotNetQ3.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}

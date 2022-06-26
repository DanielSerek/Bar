using Microsoft.AspNetCore.Identity;

namespace Bar.Models
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }
    }
}

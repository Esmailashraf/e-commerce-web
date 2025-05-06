using Microsoft.AspNetCore.Identity;

namespace e_commerce_web.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string  Address{ get; set; }
    }
}

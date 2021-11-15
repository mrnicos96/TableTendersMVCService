using Microsoft.AspNetCore.Identity;

namespace TableTendersMVCService.Models
{
    public class User : IdentityUser
    {
        public int Year { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace HRVacancies.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public ApplicationUser User { get; set; }

        public AppRole Role { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;

namespace HRVacancies.Models
{
    public class AppRole : IdentityRole<int>
    {
        public ICollection<UserRole> UserRoles { get; set; }
    }
}

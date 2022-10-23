using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace HRVacancies.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
        
        [NotMapped]
        public string Fullname => $"{Firstname} {Lastname}";

        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}

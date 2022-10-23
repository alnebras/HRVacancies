using HRVacancies.Models;
using Microsoft.AspNetCore.Identity;

namespace HRVacancies.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RoleManager<AppRole> roleManager;
        //private readonly IMapper mapper;

        public RoleRepository(RoleManager<AppRole> roleManager)
        {
            this.roleManager = roleManager;
            //this.mapper = mapper;
        }

        public async Task CreateRole()
        {
            var roles = new List<AppRole>
            {
                new AppRole {Name = "Admin"},
                new AppRole {Name = "NormalUser"}
            };
            
            foreach (var role in roles)
            {
                var savedRole = await roleManager.FindByNameAsync(role.Name);
                if (savedRole == null)
                {
                    var roleToSave = role;

                    await roleManager.CreateAsync(roleToSave);
                }
            }
        }
    }
}

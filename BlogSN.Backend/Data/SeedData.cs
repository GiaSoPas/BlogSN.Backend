using Microsoft.AspNetCore.Identity;
using Models.ModelsIdentity;
using Models.ModelsIdentity.IdentityAuth;

namespace BlogSN.Backend.Data;

public static class SeedData
{
    public static void SeedAdmin(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        if (userManager.FindByEmailAsync("admin@mail.ru").Result==null)
        {
            ApplicationUser user = new()
            {
                Email = "admin@mail.ru",
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = "Admin",
                Role = UserRole.Admin
            };
            
            var result = userManager.CreateAsync(user, "Admin123").Result;
            
            if (!roleManager.RoleExistsAsync(UserRole.Admin).Result)
                _ = roleManager.CreateAsync(new IdentityRole(UserRole.Admin)).Result;

            if (!roleManager.RoleExistsAsync(UserRole.User).Result)
                _ = roleManager.CreateAsync(new IdentityRole(UserRole.User)).Result;

            
            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, UserRole.Admin).Wait();
            }
        }       
    }   
}
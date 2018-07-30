using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ControlOfColumns.WEB.Models
{
    public class AppDbInitializer:DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            var adminRole = new IdentityRole("admin");
            var userRole = new IdentityRole("user");

            roleManager.Create(adminRole);
            roleManager.Create(userRole);

            var admin = new ApplicationUser() {UserName = "admin@admin.ru", Email = "admin@admin.ru"};
            var result = userManager.Create(admin,"Novo_1234");
            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, adminRole.Name);
                userManager.AddToRole(admin.Id, userRole.Name);
            }
            base.Seed(context);
        }
    }
}
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PetesPettingZoo.Models;

[assembly: OwinStartupAttribute(typeof(PetesPettingZoo.Startup))]
namespace PetesPettingZoo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRoleandUsers();
        }
        // In this method we will create a default user roles and admin user for login
        private void createRoleandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // in starup iam creating first admin role and creating a default admin user 
            if (!roleManager.RoleExists("Admin"))
            {
                //first we create Admin rool
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //here we create a admin super user who will maintain the website
                var user = new ApplicationUser();
                user.UserName = "carlos";
                user.Email = "vasquezcarlos1996@gmail.com";
                string userPWD = "carlos123";

                var chkUser = UserManager.Create(user, userPWD);

                //add default User to role admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
            
            // creating employee role
            if (!roleManager.RoleExists("Employee"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);

            }
        }
    }
}
using Abp.Authorization;
using JobPortal.Authorization.Roles;
using JobPortal.Authorization.Users;

namespace JobPortal.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

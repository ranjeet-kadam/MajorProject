using System.ComponentModel.DataAnnotations;

namespace EChallan.Web.Models
{
    public enum MyIdentityRoleNames
    {
        [Display(Name = "Admin Role")]
        AppAdmin,

        [Display(Name = "User Role")]
        AppUser
    }
}

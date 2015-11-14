using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using TestTypes;

namespace MVC.Extensions
{
    public static class IdentityExtensions
    {
        public static async Task<BearerTokenModel> GetAPIToken_Async(this System.Security.Principal.IIdentity User)
        {
            var UserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await UserManager.FindByIdAsync(User.GetUserId());
            return user.Token;
        } // end get api token

        public static BearerTokenModel GetAPIToken(this System.Security.Principal.IIdentity User)
        {
            var UserManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = UserManager.FindById(User.GetUserId());
            return user.Token;
        } // end get api token
    } // end class Identity Extensions
} // end namespace
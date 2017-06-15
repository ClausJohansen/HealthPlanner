using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace HealthPlanner.Web.Utility
{
    public static class AccountManager
    {
        public static string CurrentUserId
        {
            get
            {
                IAuthenticationManager authManager = HttpContext.Current.GetOwinContext().Authentication;
                Claim id = authManager.User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First();
                return id.Value;
            }
        }
    }
}
using System;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;

namespace AISLTP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters( GlobalFilters.Filters );
            RouteConfig.RegisterRoutes( RouteTable.Routes );
            BundleConfig.RegisterBundles( BundleTable.Bundles );
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpApplication appl = (HttpApplication)sender;
            if (appl.Request.IsAuthenticated && appl.User.Identity is FormsIdentity)
            {
                HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie != null)
                {
                    FormsIdentity identity = (FormsIdentity)appl.User.Identity;
                    FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                    string roles = authTicket.UserData;
                    appl.Context.User = new GenericPrincipal(identity, new string[] { roles });
                }
            }
        }
    }
}

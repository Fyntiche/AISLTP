using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AISLTP.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Account
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost, ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Auth auth)
        {
            User user = db.Users.FirstOrDefault(p => p.Login == auth.Login && p.Password == auth.Password);
            if (user == null)
            {
                ModelState.AddModelError("", "Авторизация неудачна! Проверьте логин и пароль...");
            }
            else
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user.ID.ToString(), DateTime.Now, DateTime.Now.AddDays(7), true, user.Role.Code);
                string strEncrypted = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie("__AUTH", strEncrypted));
                return RedirectToAction("Index", "Home");
            }
            return View(auth);
        }
        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
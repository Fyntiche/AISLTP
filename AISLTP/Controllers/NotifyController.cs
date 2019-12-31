using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Controllers
{
    public class NotifyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Notify
        [Authorize]
        public ActionResult Index()
        {
            User user = StaticFunctions.GetUser(User.Identity.Name);
            List<Notify> items = new List<Notify>();
            DateTime at = DateTime.Today;
            DateTime to = at.AddDays(30);
            foreach(Lico lico in db.Licos)
            {
                if (lico.Napravs.Where(p => p.DataOsv >= at && p.DataOsv <= to).Count() > 0)
                {
                    Naprav naprav = lico.Napravs.Where(p => p.DataOsv >= at && p.DataOsv <= to).OrderByDescending(p => p.DataOsv).FirstOrDefault();
                    if (naprav != null)
                    {
                        if (user.RoleID == 1 || naprav.LTP.ID == user.LTP.ID)
                        {
                            items.Add(new Notify()
                            {
                                Lico = lico,
                                Date = naprav.DataOsv,
                                Content = "Предполагаемая дата выхода"
                            });
                        }
                    }
                }
            }
            return View(items);
        }
    }
}
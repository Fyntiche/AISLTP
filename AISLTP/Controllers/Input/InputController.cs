using AISLTP.Context;
using AISLTP.Entities;
using System.Web.Mvc;

namespace AISLTP.Controllers.Input
{
    public class InputController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Input
        [Authorize]
        public ActionResult Index(int? Id)
        {
            if (Id != null)
            {
                Lico lico = db.Licos.Find(Id);
                if (lico != null)
                {
                    ViewBag.FIO = lico.Fam + " " + " " + lico.Ima + " " + lico.Otc;
                    ViewBag.ID = lico.ID;
                }
            }
            return View();
        }
    }
}
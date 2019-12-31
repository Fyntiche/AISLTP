using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class PriventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Privents
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn);
            return View(await licos.ToListAsync());
        }

        [Authorize]
        public async Task<ActionResult> Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licos.FindAsync(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fam = lico.Fam;
            ViewBag.Ima = lico.Ima;
            ViewBag.Otc = lico.Otc;
            Session["IDLico"] = lico.ID;
            return View(lico);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Show([Bind(Include = "ID,Data,Srok,Inspec,Fam,Ima,Otc,Tel")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lico);
        }

        [Authorize]
        public ActionResult CreatePrivent()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreatePrivent([Bind(Include = "ID,Data,Srok,Inspec,Fam,Ima,Otc,Tel")] Privent CreatePrivent)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Privents.Add(CreatePrivent);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(CreatePrivent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
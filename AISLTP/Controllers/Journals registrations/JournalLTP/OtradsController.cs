using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations.JournalLTP
{
    public class OtradsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Otrads
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
        public async Task<ActionResult> Show([Bind(Include = "ID,LTPID,Date,NomOtr,Prim,Dol,Zv,Fam,Ima,Otch,Tel")] Lico lico)
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
        public ActionResult CreateOtrad()
        {
            ViewBag.LTPID = new SelectList(db.LTPs, "ID", "Nom");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOtrad([Bind(Include = "ID,LTPID,Date,NomOtr,Prim,Dol,Zv,Fam,Ima,Otch,Tel")] Otrad CreateOtrad)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Otrads.Add(CreateOtrad);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LTPID = new SelectList(db.LTPs, "ID", "Nom", CreateOtrad.LTPID);
            return View(CreateOtrad);
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
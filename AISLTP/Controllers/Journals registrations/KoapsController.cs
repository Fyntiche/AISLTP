using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class KoapsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Koaps
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
        public async Task<ActionResult> Show([Bind(Include = "ID,Point,Part,Article,Name,Fabula,Prim,CourtID,Fam,Ima,Otch,DateRe,Vidvz")] Lico lico)
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
        public ActionResult CreateKoap()
        {
            ViewBag.CourtID = new SelectList(db.Courts, "ID", "Name");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateKoap([Bind(Include = "ID,Point,Part,Article,Name,Fabula,Prim,CourtID,Fam,Ima,Otch,DateRe,Vidvz")] Koap CreateKoap)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Koaps.Add(CreateKoap);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CourtID = new SelectList(db.Courts, "ID", "Name", CreateKoap.CourtID);
            return View(CreateKoap);
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
using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class AddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Address
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn);
            return View(await licos.ToListAsync());
        }

        // GET: Address/Show/5
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

        // POST: Address/Show/5

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Show([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,NacID,OblID,RnID,NpID,Vneshnost,Prim")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NacID = new SelectList(db.Nacs, "ID", "Txt", lico.NacID);
            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt", lico.NpID);
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt", lico.OblID);
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt", lico.PolID);
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt", lico.RnID);

            return View(lico);
        }

        [Authorize]
        public ActionResult CreateAddress()
        {
            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt");
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt");
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt");
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAddress([Bind(Include = "ID,OblID,RnID,NpID,Ul,Dom,Korpus,Kvartira,Prim")] Address CreateAddress)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Addresses.Add(CreateAddress);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt", CreateAddress.NpID);
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt", CreateAddress.OblID);
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt", CreateAddress.RnID);
            return View(CreateAddress);
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
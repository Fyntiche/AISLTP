using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations.JournalLTP
{
    public class OsvsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Osvs
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
        public async Task<ActionResult> Show([Bind(Include = "ID,DateOsv,DatePrib,Control,Locat,Dost,Trud,Posic,Bron")] Lico lico)
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
        public ActionResult CreateOsv()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateOsv([Bind(Include = "ID,DateOsv,DatePrib,Control,Locat,Dost,Trud,Posic,Bron")] Osv CreateOsv)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Osvs.Add(CreateOsv);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(CreateOsv);
        }

        // GET: Osvs/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osv osv = await db.Osvs.FindAsync(id);
            if (osv == null)
            {
                return HttpNotFound();
            }
            return View(osv);
        }

        // GET: Osvs/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osvs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,DateOsv,DatePrib,Control,Locat,Dost,Trud,Posic,Bron")] Osv osv)
        {
            if (ModelState.IsValid)
            {
                db.Osvs.Add(osv);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(osv);
        }

        // GET: Osvs/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osv osv = await db.Osvs.FindAsync(id);
            if (osv == null)
            {
                return HttpNotFound();
            }
            return View(osv);
        }

        // POST: Osvs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,DateOsv,DatePrib,Control,Locat,Dost,Trud,Posic,Bron")] Osv osv)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osv).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(osv);
        }

        // GET: Osvs/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osv osv = await db.Osvs.FindAsync(id);
            if (osv == null)
            {
                return HttpNotFound();
            }
            return View(osv);
        }

        // POST: Osvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Osv osv = await db.Osvs.FindAsync(id);
            db.Osvs.Remove(osv);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
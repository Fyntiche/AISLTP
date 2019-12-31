using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations.JournalLTP
{
    public class ObjalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Objals
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
        public async Task<ActionResult> Show([Bind(Include = "ID,Fam,Ima,Otch,Tel,Date,Result,Locat")] Lico lico)
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
        public ActionResult CreateObjal()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateObjal([Bind(Include = "ID,Fam,Ima,Otch,Tel,Date,Result,Locat")] Objal CreateObjal)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Objals.Add(CreateObjal);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(CreateObjal);
        }

        // GET: Objals/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objal objal = await db.Objals.FindAsync(id);
            if (objal == null)
            {
                return HttpNotFound();
            }
            return View(objal);
        }

        // GET: Objals/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objals/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Fam,Ima,Otch,Tel,Date,Result,Locat")] Objal objal)
        {
            if (ModelState.IsValid)
            {
                db.Objals.Add(objal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(objal);
        }

        // GET: Objals/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objal objal = await db.Objals.FindAsync(id);
            if (objal == null)
            {
                return HttpNotFound();
            }
            return View(objal);
        }

        // POST: Objals/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Fam,Ima,Otch,Tel,Date,Result,Locat")] Objal objal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(objal);
        }

        // GET: Objals/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objal objal = await db.Objals.FindAsync(id);
            if (objal == null)
            {
                return HttpNotFound();
            }
            return View(objal);
        }

        // POST: Objals/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Objal objal = await db.Objals.FindAsync(id);
            db.Objals.Remove(objal);
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
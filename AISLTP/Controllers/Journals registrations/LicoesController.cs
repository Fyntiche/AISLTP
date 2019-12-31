using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class LicoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Licoes
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).
                Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn).Include(l => l.Addresses);
            //var addresses = db.Addresses.Include( a => a.Np ).Include( a => a.Obl ).Include( a => a.Rn );
            return View(await licos.ToListAsync());
        }

        // GET: Licoes/Details/5
        [Authorize]
        public async Task<ActionResult> Details(int? id)
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
            return View(lico);
        }

        // GET: Licoes/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.NacID = new SelectList(db.Nacs, "ID", "Txt");
            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt");
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt");
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt");
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt");
            return View();
        }

        // POST: Licoes/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,NacID,OblID,RnID,NpID,Vneshnost")] Lico lico, HttpPostedFileBase uploadFoto)
        {
            if (ModelState.IsValid)
            {
                if (uploadFoto != null)
                {
                    byte[] fotoData = null;
                    using (var binaryReader = new BinaryReader(uploadFoto.InputStream))
                    {
                        fotoData = binaryReader.ReadBytes(uploadFoto.ContentLength);
                    }
                    lico.Foto = fotoData;
                }
                db.Licos.Add(lico);
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

        // GET: Licoes/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
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
            ViewBag.NacID = new SelectList(db.Nacs, "ID", "Txt", lico.NacID);
            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt", lico.NpID);
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt", lico.OblID);
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt", lico.PolID);
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt", lico.RnID);
            ViewBag.Address = db.Addresses.ToList();
            return View(lico);
        }

        // POST: Licoes/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,NacID,OblID,RnID,NpID,Vneshnost,Foto")] Lico lico, HttpPostedFileBase uploadFoto)
        {
            if (ModelState.IsValid)
            {
                if (uploadFoto != null)
                {
                    byte[] fotoData = null;
                    using (var binaryReader = new BinaryReader(uploadFoto.InputStream))
                    {
                        fotoData = binaryReader.ReadBytes(uploadFoto.ContentLength);
                    }
                    lico.Foto = fotoData;
                }
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

        // GET: Licoes/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
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
            return View(lico);
        }

        // POST: Licoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lico lico = await db.Licos.FindAsync(id);
            db.Licos.Remove(lico);
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
using AISLTP.Context;
using AISLTP.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations.JournalLTP
{
    public class DocsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Docs
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).
                Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn).Include(l => l.Addresses);
            //var addresses = db.Addresses.Include( a => a.Np ).Include( a => a.Obl ).Include( a => a.Rn );
            return View(await licos.ToListAsync());
        }

        [Authorize]
        public ActionResult Details(int id = 0)
        {
            Lico lico = db.Licos.Find(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            return View(lico);
        }

        [Authorize]
        public ActionResult Edit(int id = 0)
        {
            Lico lico = db.Licos.Find(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Docs = db.Docs.ToList();
            return View(lico);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Lico lico, int[] selectedDocs)
        {
            Lico newLico = db.Licos.Find(lico.ID);
            newLico.Fam = lico.Fam;
            newLico.Ima = lico.Ima;
            newLico.Otc = lico.Otc;

            newLico.Docs.Clear();
            if (selectedDocs != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Docs.Where(co => selectedDocs.Contains(co.ID)))
                {
                    newLico.Docs.Add(c);
                }
            }

            db.Entry(newLico).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { Id = newLico.ID });
        }
    }
}
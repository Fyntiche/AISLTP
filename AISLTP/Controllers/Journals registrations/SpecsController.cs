using AISLTP.Context;
using AISLTP.Entities;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class SpecsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Spec
        [Authorize]
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).
                Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn).Include(l => l.Addresses);
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
            ViewBag.Specs = db.Specs.ToList();
            return View(lico);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Lico lico, int[] selectedSpecs)
        {
            Lico newLico = db.Licos.Find(lico.ID);
            newLico.Fam = lico.Fam;
            newLico.Ima = lico.Ima;
            newLico.Otc = lico.Otc;

            newLico.Specs.Clear();
            if (selectedSpecs != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Specs.Where(co => selectedSpecs.Contains(co.ID)))
                {
                    newLico.Specs.Add(c);
                }
            }

            db.Entry(newLico).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { Id = newLico.ID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
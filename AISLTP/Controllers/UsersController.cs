using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using AISLTP.Context;
using AISLTP.Entities;

namespace AISLTP.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Users
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            var users = db.Users.Include(u => u.LTP).Include(u => u.Role).Include(u => u.Sotr);
            return View(await users.ToListAsync());
        }

        // GET: Users/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.LtpID = new SelectList(db.LTPs, "ID", "Nom");
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name");
            ViewBag.SotrID = new SelectList(db.Sotrs, "ID", "Cod_sotr");
            return View();
        }

        // POST: Users/Create
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Login,Password,SotrID,LtpID,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LtpID = new SelectList(db.LTPs, "ID", "Nom", user.LtpID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            ViewBag.SotrID = new SelectList(db.Sotrs, "ID", "Cod_sotr", user.SotrID);
            return View(user);
        }

        // GET: Users/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.LtpID = new SelectList(db.LTPs, "ID", "Nom", user.LtpID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            ViewBag.SotrID = new SelectList(db.Sotrs, "ID", "Fio", user.SotrID);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Login,Password,SotrID,LtpID,RoleID")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LtpID = new SelectList(db.LTPs, "ID", "Nom", user.LtpID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", user.RoleID);
            ViewBag.SotrID = new SelectList(db.Sotrs, "ID", "Cod_sotr", user.SotrID);
            return View(user);
        }

        // GET: Users/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = await db.Users.FindAsync(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            User user = await db.Users.FindAsync(id);
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]
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

using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers
{
    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Messages
        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Index()
        {
            var items = db.Messages.Include(i => i.User).Include(i => i.User.Sotr);
            return View(await items.ToListAsync());
        }

        [Authorize(Roles = "admin")]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message item = await db.Messages.FindAsync(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            if (!item.IsRead)
            {
                item.IsRead = true;
                db.Entry(item).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
            return View(item);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "ID,Date,Content,UserID,IsRead")] Message message)
        {
            if (ModelState.IsValid)
            {
                User user = StaticFunctions.GetUser(User.Identity.Name);
                if (user != null)
                {
                    message.Date = DateTime.Now;
                    message.UserID = user.ID;
                    message.IsRead = false;
                    db.Messages.Add(message);
                    await db.SaveChangesAsync();
                }
            }
            return View();
        }

    }
}
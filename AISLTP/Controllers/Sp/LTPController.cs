using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class LTPController : Controller
    {
        // GET: LTP
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetLTP(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var LTPList = db.LTPs.Select(
                    t => new
                    {
                        t.ID,
                        t.Nom,
                        t.Np,
                        t.Ul,
                        t.Dom,
                        t.Pindex,
                        t.Teldej,
                        t.Email
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Nom":
                        LTPList = LTPList.Where(t => t.Nom.Contains(searchString));
                        break;
                }
            }
            int totalRecords = LTPList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                LTPList = LTPList.OrderByDescending(t => t.Nom);
                LTPList = LTPList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                LTPList = LTPList.OrderBy(t => t.Nom);
                LTPList = LTPList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = LTPList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] LTP Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.LTPs.Add(Model);

                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        public string Edit(LTP Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        public string Delete(int Id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            LTP lTPs = db.LTPs.Find(Id);
            db.LTPs.Remove(lTPs);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
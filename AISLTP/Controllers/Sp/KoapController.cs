using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class KoapController : Controller
    {
        // GET: Koap
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetKoap(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var KoapList = db.Koaps.Select(
                    t => new
                    {
                        t.ID,
                        t.Point,
                        t.Part,
                        t.Article,
                        t.Name,
                        t.Prim,
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Nom":
                        KoapList = KoapList.Where(t => t.Name.Contains(searchString));
                        break;
                }
            }
            int totalRecords = KoapList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                KoapList = KoapList.OrderByDescending(t => t.Name);
                KoapList = KoapList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                KoapList = KoapList.OrderBy(t => t.Name);
                KoapList = KoapList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = KoapList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Koap Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Koaps.Add(Model);

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

        public string Edit(Koap Model)
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
            Koap Koaps = db.Koaps.Find(Id);
            db.Koaps.Remove(Koaps);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
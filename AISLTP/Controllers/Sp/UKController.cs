using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class UKController : Controller
    {
        // GET: UK
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetUK(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var UKList = db.UKs.Select(
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
                        UKList = UKList.Where(t => t.Name.Contains(searchString));
                        break;
                }
            }
            int totalRecords = UKList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                UKList = UKList.OrderByDescending(t => t.Name);
                UKList = UKList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                UKList = UKList.OrderBy(t => t.Name);
                UKList = UKList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = UKList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] UK Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.UKs.Add(Model);

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

        public string Edit(UK Model)
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
            UK UKs = db.UKs.Find(Id);
            db.UKs.Remove(UKs);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
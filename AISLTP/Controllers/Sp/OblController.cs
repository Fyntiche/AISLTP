using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class OblController : Controller
    {
        // GET: Obl
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetObl(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var OblList = db.Obls.Select(
                    t => new
                    {
                        t.ID,
                        t.Txt,
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Txt":
                        OblList = OblList.Where(t => t.Txt.Contains(searchString));
                        break;
                }
            }
            int totalRecords = OblList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                OblList = OblList.OrderByDescending(t => t.Txt);
                OblList = OblList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                OblList = OblList.OrderBy(t => t.Txt);
                OblList = OblList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = OblList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Obl Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Obls.Add(Model);

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

        public string Edit(Obl Model)
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
            Obl obls = db.Obls.Find(Id);
            db.Obls.Remove(obls);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
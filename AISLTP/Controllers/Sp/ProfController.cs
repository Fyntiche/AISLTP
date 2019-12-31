using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class ProfController : Controller
    {
        // GET: Prof
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProf(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var ProfList = db.Profs.Select(
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
                        ProfList = ProfList.Where(t => t.Txt.Contains(searchString));
                        break;
                }
            }
            int totalRecords = ProfList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                ProfList = ProfList.OrderByDescending(t => t.Txt);
                ProfList = ProfList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                ProfList = ProfList.OrderBy(t => t.Txt);
                ProfList = ProfList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = ProfList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Prof Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Profs.Add(Model);

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

        public string Edit(Prof Model)
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
            Prof Profs = db.Profs.Find(Id);
            db.Profs.Remove(Profs);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
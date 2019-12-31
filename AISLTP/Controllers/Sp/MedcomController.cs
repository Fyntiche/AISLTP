using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class MedcomController : Controller
    {
        // GET: Med
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetMedcom(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var MedcomList = db.Medcoms.Select(
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
                        MedcomList = MedcomList.Where(t => t.Txt.Contains(searchString));
                        break;
                }
            }
            int totalRecords = MedcomList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                MedcomList = MedcomList.OrderByDescending(t => t.Txt);
                MedcomList = MedcomList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                MedcomList = MedcomList.OrderBy(t => t.Txt);
                MedcomList = MedcomList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = MedcomList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Medcom Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Medcoms.Add(Model);

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

        public string Edit(Medcom Model)
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
            Medcom Medcoms = db.Medcoms.Find(Id);
            db.Medcoms.Remove(Medcoms);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
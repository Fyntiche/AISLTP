using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class OtnoshController : Controller
    {
        // GET: Otnosh
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetOtnosh(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var OtnoshList = db.Otnoshs.Select(
                    t => new
                    {
                        t.ID,
                        t.Txt,
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Nom":
                        OtnoshList = OtnoshList.Where(t => t.Txt.Contains(searchString));
                        break;
                }
            }
            int totalRecords = OtnoshList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                OtnoshList = OtnoshList.OrderByDescending(t => t.Txt);
                OtnoshList = OtnoshList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                OtnoshList = OtnoshList.OrderBy(t => t.Txt);
                OtnoshList = OtnoshList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = OtnoshList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Otnosh Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Otnoshs.Add(Model);

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

        public string Edit(Otnosh Model)
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
            Otnosh Otnoshs = db.Otnoshs.Find(Id);
            db.Otnoshs.Remove(Otnoshs);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
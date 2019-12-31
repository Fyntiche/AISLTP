using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class SotrController : Controller
    {
        //
        // GET: /Sotr/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetSotr(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var SotrList = db.Sotrs.Select(
                    t => new
                    {
                        t.ID,
                        t.Cod_sotr,
                        t.Ima,
                        t.Fio,
                        t.Otc,
                        t.Dr,
                        t.Sex,
                        t.Dvi
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Cod_sotr":
                        SotrList = SotrList.Where(t => t.Cod_sotr.Contains(searchString));
                        break;

                    case "Ima":
                        SotrList = SotrList.Where(t => t.Ima.Contains(searchString));
                        break;

                    case "Fio":
                        SotrList = SotrList.Where(t => t.Fio.Contains(searchString));
                        break;

                    case "Otc":
                        SotrList = SotrList.Where(t => t.Otc.Contains(searchString));
                        break;
                }
            }
            int totalRecords = SotrList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                SotrList = SotrList.OrderByDescending(t => t.Ima);
                SotrList = SotrList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                SotrList = SotrList.OrderBy(t => t.Fio);
                SotrList = SotrList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = SotrList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Sotr Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Sotrs.Add(Model);

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

        public string Edit(Sotr Model)
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
            Sotr Sotr = db.Sotrs.Find(Id);
            db.Sotrs.Remove(Sotr);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}
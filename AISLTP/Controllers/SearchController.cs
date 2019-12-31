using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers
{
    public class SearchController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private List<Lico> GetList(Search search)
        {
            List<Lico> items = db.Licos.ToList();
            if (search.UseDr)
            {
                if (search.DrTo < search.DrAt)
                {
                    search.DrTo = search.DrAt;
                }
                items = items.Where(p => p.Dr >= search.DrAt && p.Dr <= search.DrTo).ToList();
            }
            if (search.UseDosujd)
            {
                List<Lico> buffer = new List<Lico>();
                if (search.DosujdTo < search.DosujdAt)
                {
                    search.DosujdTo = search.DosujdAt;
                }
                foreach(Lico lico in items)
                {
                    if (lico.UKs.Where(p => p.DatePrig >= search.DosujdAt && p.DatePrig <= search.DosujdTo).Count() > 0)
                    {
                        buffer.Add(lico);
                    }
                }
                items = buffer;
            }
            if (search.UseDosv)
            {
                List<Lico> buffer = new List<Lico>();
                if (search.DosujdTo < search.DosujdAt)
                {
                    search.DosujdTo = search.DosujdAt;
                }
                foreach (Lico lico in items)
                {
                    if (lico.Osvs.Where(p => p.DateOsv >= search.DosvAt && p.DateOsv <= search.DosvTo).Count() > 0)
                    {
                        buffer.Add(lico);
                    }
                }
                items = buffer;
            }
            if (search.UseFIO && search.FIO != null)
            {
                List<Lico> buffer = new List<Lico>();
                foreach (Lico lico in items)
                {
                    string fio = (lico.Fam.Trim() + " " + lico.Ima.Trim() + " " + lico.Otc.Trim()).ToLower();
                    if (fio.Contains(search.FIO.ToLower()))
                    {
                        buffer.Add(lico);
                    }
                }
                items = buffer;
            }
            return items;
        }
        // GET: Search
        [Authorize]
        public ActionResult Index()
        {
            Search search = new Search()
            {
                UseFIO = false,
                FIO = "",
                UseDr = false,
                DrAt = DateTime.Now,
                DrTo = DateTime.Now,
                UseDosujd = false,
                DosujdAt = DateTime.Now,
                DosujdTo = DateTime.Now,
                UseDosv = false,
                DosvAt = DateTime.Now,
                DosvTo = DateTime.Now
            };
            ViewBag.Items = new List<Lico>();
            return View(search);
        }
        [HttpPost]
        [Authorize]
        public ActionResult Index(Search search)
        {
            ViewBag.Items = GetList(search);
            return View(search);
        }
    }
}
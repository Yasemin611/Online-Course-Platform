using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EgitmenController : Controller
    {
        // GET: Egitmen
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Egitmen> liste3 = n.Egitmen.ToList();  // select * from Urunler
            return View(liste3);
        }
        [HttpGet]

        public ActionResult egitmenSil(int id)
        {
            Egitmen e = n.Egitmen.FirstOrDefault(x => x.egitmenID == id);
            return View(e);
        }

        [HttpPost]
        public ActionResult egitmenSil(Egitmen e)
        {
            Egitmen egitmen = n.Egitmen.FirstOrDefault(x => x.egitmenID == e.egitmenID);

            n.Egitmen.Remove(egitmen);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult egitmenEkle()
        {
            ViewBag.kurs = n.Kurs.ToList();
            ViewBag.kursiyer = n.Kursiyer.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult egitmenEkle(Egitmen e)
        {
            n.Egitmen.Add(e);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

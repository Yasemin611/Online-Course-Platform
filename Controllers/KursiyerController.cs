using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class KursiyerController : Controller
    {
        // GET: Kursiyer
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]

        [AllowAnonymous]
        public ActionResult Index()
        {
            List<Kursiyer> liste4 = n.Kursiyer.ToList();  // select * from Urunler
            return View(liste4);
        }
        [HttpGet]

        public ActionResult kursiyerSil(int id)
        {
            Kursiyer k = n.Kursiyer.FirstOrDefault(x => x.kursiyerID == id);
            return View(k);
        }

        [HttpPost]
        public ActionResult kursiyerSil(Kursiyer k)
        {
            Kursiyer kursiyer = n.Kursiyer.FirstOrDefault(x => x.kursiyerID == k.kursiyerID);

            n.Kursiyer.Remove(kursiyer);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult kursiyerEkle()
        {
            ViewBag.kurs = n.Kurs.ToList();
            ViewBag.egitmen = n.Egitmen.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult kursiyerEkle(Kursiyer k)
        {
            n.Kursiyer.Add(k);
            n.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult kursiyerGuncelle(int id)
        {
            Kursiyer kursiyer = n.Kursiyer.FirstOrDefault(x => x.kursiyerID == id);

            return View("kursiyerEkle", kursiyer);
        }
    }
}

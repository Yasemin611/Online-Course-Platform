using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class YoneticiController : Controller
    {
        // GET: Yonetici
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]
        public ActionResult Index()
        {
            List<Kurs_Programi_Yoneticisi> liste10 = n.Kurs_Programi_Yoneticisi.ToList();  // select * from Urunler
            return View(liste10);
        }
        [HttpGet]

        public ActionResult yoneticiSil(int id)
        {
            Kurs_Programi_Yoneticisi y = n.Kurs_Programi_Yoneticisi.FirstOrDefault(x => x.yoneticiID == id);
            return View(y);
        }

        [HttpPost]
        public ActionResult yoneticiSil(Kurs_Programi_Yoneticisi y)
        {
            Kurs_Programi_Yoneticisi yonetici = n.Kurs_Programi_Yoneticisi.FirstOrDefault(x => x.yoneticiID == y.yoneticiID);

            n.Kurs_Programi_Yoneticisi.Remove(yonetici);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult yoneticiEkle()
        {
            ViewBag.yetki = n.Yetki.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult yoneticiEkle(Kurs_Programi_Yoneticisi y)
        {
            n.Kurs_Programi_Yoneticisi.Add(y);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
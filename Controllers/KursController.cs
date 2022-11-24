using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;

namespace WebApplication2.Controllers
{
    [MyAuthorization(Roles = "Admin")]
    public class KursController : Controller
    {
        // GET: Kurs
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]
        public ActionResult Index()
        {
            List<Kurs> liste = n.Kurs.ToList();
            List<Konu> liste2 = n.Konu.ToList();// select * from Urunler
            List<Video> videos = n.Video.ToList();
            ViewBag.video = videos;
            ViewBag.konu = liste2;
            return View(liste);
        }
        [HttpGet]

        [MyAuthorization(Roles = "Admin")]
        public ActionResult kursSil(int id)
        {
            Kurs k = n.Kurs.FirstOrDefault(x => x.kursID == id);
            return View(k);
        }

        [HttpPost]
        [Authorize(Roles = "Admin, Instructor")]
        public ActionResult kursSil(Kurs k)
        {
            Kurs kurs = n.Kurs.FirstOrDefault(x => x.kursID == k.kursID);
            
            n.Kurs.Remove(kurs);
            n.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult kursEkle()
        {
            ViewBag.egitmen = n.Egitmen.ToList();
            ViewBag.program = n.Kurs_Programi.ToList();
            ViewBag.video = n.Video.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult kursEkle(Kurs k)
        {
            n.Kurs.Add(k);
            n.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
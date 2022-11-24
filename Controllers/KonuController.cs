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

    public class KonuController : Controller
    {
        // GET: Konu
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]
        public ActionResult Index()
        {
            List<Konu> liste2 = n.Konu.ToList();  // select * from Urunler
            return View(liste2);
           
        }
        [HttpGet]
        
        public ActionResult konuSil(int id)
        {
            Konu k = n.Konu.FirstOrDefault(x => x.konuID == id);
            return View(k);
        }

        [HttpPost]
        public ActionResult konuSil(Konu k)
        {
            Konu konu = n.Konu.FirstOrDefault(x => x.konuID == k.konuID);

            n.Konu.Remove(konu);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult konuEkle()
        {
            ViewBag.kurs = n.Kurs.ToList();
            ViewBag.kursiyer = n.Kursiyer.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult konuEkle(Konu k)
        {
            Konu konu = n.Konu.FirstOrDefault(x => x.konuID == k.konuID);

            if (konu == null)
            {
                n.Konu.Add(k);
            }
            else //update
            {
                konu.konuAdi = k.konuAdi;
            }
            n.Konu.Add(k);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

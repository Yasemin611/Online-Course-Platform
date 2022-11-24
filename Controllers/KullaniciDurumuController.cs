using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class KullaniciDurumuController : Controller
    {
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        // GET: KullaniciDurumu
        [HttpGet]
        public ActionResult Index()
        {
            List<Kullanici_Durumu> liste8 = n.Kullanici_Durumu.ToList();  // select * from Urunler
            return View(liste8);
        }
    }
}
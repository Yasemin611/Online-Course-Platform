using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Sertifika_HakkiController : Controller
    {
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        // GET: Sertifika_Hakki
        [HttpGet]
        public ActionResult Index()
        {
            List<Sertifika_Hakki> liste12 = n.Sertifika_Hakki.ToList();  // select * from Urunler
            return View(liste12);
        }
     
    }
}
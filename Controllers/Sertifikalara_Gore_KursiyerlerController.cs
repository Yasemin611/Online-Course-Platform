using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Sertifikalara_Gore_KursiyerlerController : Controller
    {
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        // GET: Sertifikalara_Gore_Kursiyerler
        [HttpGet]
        public ActionResult Index()
        {
            List<Sertifikalara_Gore_Kursiyerler> liste11 = n.Sertifikalara_Gore_Kursiyerler.ToList();  // select * from Urunler
            return View(liste11);
        }
    }
}
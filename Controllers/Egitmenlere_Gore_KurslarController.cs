using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Egitmenlere_Gore_KurslarController : Controller
    {            
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        // GET: Egitmenlere_Gore_Kurslar
        [HttpGet]
        public ActionResult Index()
        {        
            List<Egitmenlere_Gore_Kurslar> liste7 = n.Egitmenlere_Gore_Kurslar.ToList(); // select * from Urunler
            return View(liste7);
        }
    }
}
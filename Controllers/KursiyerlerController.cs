using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class KursiyerlerController : Controller
    {
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        // GET: Kursiyerler
        public ActionResult Index()
        {
            List<Kursiyerler> liste6 = n.Kursiyerler.ToList();  // select * from Urunler
            return View(liste6);
        }
    }
}
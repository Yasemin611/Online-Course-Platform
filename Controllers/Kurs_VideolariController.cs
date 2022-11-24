using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class Kurs_VideolariController : Controller
    {
        // GET: Kurs_Videolari
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();

        [HttpGet]
        public ActionResult Index()
        {
            List<Kurs_Videolari> liste13 = n.Kurs_Videolari.ToList();  // select * from Urunler
            return View(liste13);
        }
        public ActionResult kursVideo(Video v)
        {
            //ViewBag.video = n.Video.ToList();
            Video video = n.Video.FirstOrDefault(x => x.videoID == v.videoID);
            return View(video);
        }
    }
}
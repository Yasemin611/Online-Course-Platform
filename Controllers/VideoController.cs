using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();

        [HttpGet]
        public ActionResult Index(Video v)
        {
            ViewBag.liste9 = n.Video.ToList();  // select * from Urunler
            return View();
        }
        [HttpGet]

        public ActionResult videoSil(int id)
        {
            Video v = n.Video.FirstOrDefault(x => x.videoID == id);
            return View(v);
        }

        [HttpPost]
        public ActionResult videoSil(Video v)
        {
            Video video = n.Video.FirstOrDefault(x => x.videoID == v.videoID);

            n.Video.Remove(video);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult videoEkle()
        {
            ViewBag.kurs = n.Kurs.ToList();
            ViewBag.konu = n.Konu.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult videoEkle(Video v)
        {
            n.Video.Add(v);
            n.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
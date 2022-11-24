using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Web.Security;
using ServiceStack;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
        [HttpGet]
        public ActionResult Index(User_ u)
        {
            ViewBag.u = u.userAdi + " " + u.userSoyadi;
            User_ user = n.User_.FirstOrDefault(x => x.userID == u.userID);
            return View(u);

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(User_ u)
        {
            KURS_PROGRAMIEntities8 n = new KURS_PROGRAMIEntities8();
            //string a = u.uEmail;
            //string b = u.uPassword;
            //// List<User_> l = n.User_.ToList();
            //u.uEmail = "abc";
            //u.uPassword = "123";
            //     User_ user = n.User_.FirstOrDefault(x => x.uEmail == u.uEmail && x.uPassword == u.uPassword);
            //var query = from item in n.User_
            //            where item.uEmail == u.uEmail && item.uPassword == u.uPassword
            //            select new
            //            {
            //                ID = item.userID,
            //                Firstname = item.userAdi,
            //                Lastname = item.userSoyadi
            //            };
            var user = n.User_
                    .SqlQuery("select * from User_ where uEmail = @uEmail and uPassword=@uPassword", new SqlParameter("@uEmail", u.uEmail), new SqlParameter("@uPassword", u.uPassword))
                    .FirstOrDefault();


            if (user != null)
            {
                ViewBag.user = user.userAdi + " " + user.userSoyadi;
                FormsAuthentication.SetAuthCookie(user.uEmail, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.mesaj = "User Name or Password is Wrong!";
                return View();
            }

        }
        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.yetki = n.Yetki.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Register(User_ u)
        {
            n.User_.Add(u);
            n.SaveChanges();
            return RedirectToAction("Index");
        }
        //if (ModelState.IsValid)
        //{
        //    //using (var databaseContext = new KURS_PROGRAMIEntities8())
        //    //{
        //    //    User_ reglog = new User_();

        //    //    reglog.userAdi = u.userAdi;
        //    //    reglog.userSoyadi = u.userSoyadi;
        //    //    reglog.uEmail = u.uEmail;
        //    //    reglog.uPassword = u.uPassword;


        //    //    //Calling the SaveDetails method which saves the details.
        //    //    databaseContext.User_.Add(reglog);
        //    //    databaseContext.SaveChanges();


        //    }

        //ViewBag.Message = "User Details Saved";
        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        //If the validation fails, we are returning the model object with errors to the view, which will display the error messages.
        //        return View();
        //    }
        //}

        public ActionResult LogOut()
        {
            string name = FormsAuthentication.FormsCookieName;
            HttpCookie authcookie = HttpContext.Request.Cookies[name];
            FormsAuthenticationTicket t = FormsAuthentication.Decrypt(authcookie.Value);
            string tname = t.Name;

            FormsAuthentication.SignOut();
            return RedirectToAction("Login");

        }
        [HttpGet]
        public ActionResult Page404()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Page500()
        {
            return View();
        }


        public ActionResult Hata()
        {
            return View("Hata");
        }

    }
}

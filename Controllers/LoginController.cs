using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using VareeWeb.Models;

namespace VareeWeb.Controllers
{
    public class LoginController : Controller
    {
        VareeStroreEntities1 db = new VareeStroreEntities1();

        // GET: Login
        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(User u, string ReturnUrl)
        {
            if (IsValid(u))
            {
                FormsAuthentication.SetAuthCookie(u.UserName, false);
                Session["userName"] = u.UserName;

                var TempUrl = Session["ReturnURl"] as string;
                if (!string.IsNullOrEmpty(TempUrl))
                {
                    ReturnUrl = TempUrl;
                }

                if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Msg = "Login Failed";
                return View();
            }
        }



        public bool IsValid(User u)
        {
            var data = db.Users.Where(m => m.UserName == u.UserName &&  m.Password == u.Password).FirstOrDefault();
           

           if(data == null)
            { return false; }
           else
            {
                return true; }
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(User u)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(u);
                int ch = db.SaveChanges();
                if(ch > 0)
                {
                    TempData["AccCreation"] = "Signed up Successfully, Now Login";
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.errorMsg = "Sign Up Failed";
                    return View();
                }
            }
            else
            {

                ViewBag.errorMsg = "Sign Up Failed";
                return View();
            }
            
        }
    }
}
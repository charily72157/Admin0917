using Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Admin.Controllers
{
    public class chenController : Controller
    {
        // GET: chen
        public ActionResult Index()
        {
            //如等於空，就view
            if (Session["aaa"]==null) 
            {
                return View();
            }
            else
            {
                if (Session["aaa"].ToString() == "aaa")
                {
                    //有SECSSION且值相等
                    return Redirect("~/Home");
                }
                else
                {
                    return View();
                }
            }
        }
       
        public ActionResult login(string username, string password)
        {
            userModel login = new userModel();
            if (login.loginCheck(username, password))
            {
                Session["aaa"] = "aaa";
                //return Redirect("~/Home");
                return Content(("<script>alert('登入成功!');window.parent.location.href='sss';</script>"));
            }
            else
            {
                //return Content(("<script>alert('登入失敗..');window.location.href='https://www.google.com.tw/';</script>"));
                return Content(("<script>alert('登入失敗..');window.parent.location.href='Index';</script>"));
            }
        }
        public ActionResult sss()
        {
            return Redirect("~/Home");
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            //return RedirectToAction("Index", "Home");
            return Redirect("~/Home");

        }
    }
}
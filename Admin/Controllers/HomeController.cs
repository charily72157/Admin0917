using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["aaa"] == null)
            {
                return Redirect("~/chen");
            }
            else
            {
                if (Session["aaa"].ToString() == "aaa")
                {
                    return View();
                }
                else
                {
                    return Redirect("~/chen");
                }
            }
        }
        public ActionResult Index2()
        {
            if (Session["aaa"] == null)
            {
                return Redirect("~/chen");
            }
            else
            {
                if (Session["aaa"].ToString() == "aaa")
                {
                    return View();
                }
                else
                {
                    return Redirect("~/chen");
                }
            }
        }

    }
}
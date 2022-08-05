using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using vidu2._1.Models;

namespace vidu2._1.Controllers
{
    public class CaculateController : Controller
    {
        // GET: Caculate
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XyLy(Caculate c)
        {
            ViewBag.num1 = c.num1;
            ViewBag.num2 = c.num2;
            ViewBag.type = c.type;
            if(c.type == "cong")
            {
                ViewBag.result = c.num1 + c.num2;
            } else if(c.type == "tru")
            {
                ViewBag.result = c.num1 - c.num2;
            } else if(c.type == "nhan")
            {
                ViewBag.result = c.num1 * c.num2;
            } else if(c.type == "chia")
            {
                ViewBag.result = c.num1 / c.num2;
            }
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace vidu2._1.Controllers
{
    public class NhapDiemController : Controller
    {
        // GET: NhapDiem
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult XyLy()
        {
            string Ma = Request["Id"];
            string Ten = Request["Name"];
            double Diem = Double.Parse(Request["Marks"]);

            ViewBag.ma = Ma;
            ViewBag.ten = Ten;
            ViewBag.diem = Diem;
            return View();
        }

        public ActionResult XyLyByFormCollection(FormCollection data)
        {
            string ma = data["Id"];
            string ten = data["Name"];
            double diem = Double.Parse(data["Marks"]);

            ViewBag.ma = ma;
            ViewBag.ten = ten;
            ViewBag.diem = diem;
            return View();
        }

        public ActionResult XyLyByArguments(string Id = "", string Name = "", double Marks = 0)
        {
            ViewBag.ma = Id;
            ViewBag.ten = Name;
            ViewBag.diem = Marks;
            return View();
        }
    }
}
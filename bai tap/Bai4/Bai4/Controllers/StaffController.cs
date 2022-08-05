using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Bai4.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost] 
        public ActionResult Save(FormatException f)
        {
            // lay thong tin tu input type=file
            var fHinh = Request.Files["image"];
            // lay ten file duoc chon
            string _FileName = Path.GetFileName(fHinh.FileName);
            // save hinh ve thu muc Images tren Server
            var pathHinh = Server.MapPath("~/Images/" + _FileName);
            fHinh.SaveAs(pathHinh);

            // lay duong dan toi file StaffInfo.txt
            string path = Server.MapPath("~/StaffInfo.txt");
            string[] lines = { f["id"], f["name"], f["bod"], };
            return View();
        }
    }
}
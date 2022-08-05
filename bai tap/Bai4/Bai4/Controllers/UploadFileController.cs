using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace Bai4.Controllers
{
    public class UploadFileController : Controller
    {
        // GET: UploadFile
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    // lay ten file dc chon
                    string _FileName = Path.GetFileName(file.FileName);
                    // chuoi duong dan toi thu muc luu file: UploadedFiles
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);
                    // luu file chon vao thuc muc UploadedFiles
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File uploaded successfully!";
                return View();
            }
            catch (Exception)
            {

                ViewBag.Message = "File uploaded failed!";
                return View();
            }
        }
    }
}
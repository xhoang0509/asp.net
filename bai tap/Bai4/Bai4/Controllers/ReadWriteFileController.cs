using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai4.Models;

namespace Bai4.Controllers
{
    public class ReadWriteFileController : Controller
    {
        // GET: ReadWriteFile
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Save(Student s)
        {
            string path = Server.MapPath("~/StudentInfo.txt");
            string[] lines = { s.id, s.name, s.marks.ToString() };
            System.IO.File.WriteAllLines(path, lines);
            ViewBag.HanhDong = "Đã ghi từ file!";
            return View("Index");
        }
        public ActionResult Open(Student s)
        {
            string path = Server.MapPath("~/StudentInfo.txt");
            string[] lines = System.IO.File.ReadAllLines(path);
            s.id = lines[0];
            s.name = lines[1];
            s.marks = Double.Parse(lines[2]);

            ViewBag.ThongTin = "Mã sinh viên: " + s.id + " Tên sinh viên: " + s.name + " Điểm: " + s.marks;
            ViewBag.HanhDong = "Đã đọc từ file !";

            return View("Index");
        }
    }
}
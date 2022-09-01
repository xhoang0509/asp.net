using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De1.Models;

namespace De1.Controllers
{
    public class Cau5Controller : Controller
    {
        private NguyenXuanHoang db = new NguyenXuanHoang();
        // GET: Cau5
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Manv,Hoten,Phong,Luong")] NhanVien nhanVien)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.NhanViens.Add(nhanVien);
                    db.SaveChanges();
                }
                return RedirectToAction("../NhanViens/Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu ! | " + ex.Message;
                return View("Index", nhanVien);
            }
        }
    }
}
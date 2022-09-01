using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai12_v2.Models;

namespace bai12_v2.Controllers
{
    public class NhanVienController : Controller
    {
        QLLuongDB db = new QLLuongDB();

        [HttpGet]
        public ActionResult Index()
        {
            var query = db.NhanViens.Select(nv => nv);
            return View(query);
        }

        [HttpGet]
        public ActionResult ChiTiet(string id)
        {
            var query = db.NhanViens.Where(nv => nv.Manv == id).First();
            return View(query);
        }

        [HttpGet]
        public ActionResult Them()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Them(FormCollection data, NhanVien nv)
        {
            var Manv = data["Manv"];
            var Hoten = data["Hoten"];
            var Phong = data["Phong"];
            var Luong = data["Luong"];

            if (String.IsNullOrEmpty(Manv))
            {
                ViewData["Loi1"] = "Mã nhân viên không được để trống !";
            }
            else if (String.IsNullOrEmpty(Hoten))
            {
                ViewData["Loi2"] = "Họ tên nhân viên không được để trống!";
            }
            else if (String.IsNullOrEmpty(Phong))
            {
                ViewData["Loi3"] = "Phòng không được để trống!";
            }
            else if (String.IsNullOrEmpty(Luong))
            {
                ViewData["Loi4"] = "Lương không được để trống!";
            }
            else
            {
                nv.Manv = Manv;
                nv.Hoten = Hoten;
                nv.Phong = Phong;
                nv.Luong = Double.Parse(Luong);
                db.NhanViens.Add(nv);
                db.SaveChanges();

                return RedirectToAction("Index", "NhanVien");
            }
            return this.Them();
        }

        [HttpGet]
        public ActionResult Sua(string id)
        {
            var query = db.NhanViens.Where(nv => nv.Manv == id).First();
            return View(query);
        }

        [HttpPost]
        public ActionResult Sua(string id, FormCollection data)
        {
            var nv = db.NhanViens.Where(n => n.Manv == id).First();
            var Manv = data["Manv"];
            var Hoten = data["Hoten"];
            var Phong = data["Phong"];
            var Luong = data["Luong"];

            if (String.IsNullOrEmpty(Hoten))
            {
                ViewData["Loi2"] = "Họ tên nhân viên không được để trống!";
            }
            else if (String.IsNullOrEmpty(Phong))
            {
                ViewData["Loi3"] = "Phòng không được để trống!";
            }
            else if (String.IsNullOrEmpty(Luong))
            {
                ViewData["Loi4"] = "Lương không được để trống!";
            }
            else
            {
                nv.Hoten = Hoten;
                nv.Phong = Phong;
                nv.Luong = Double.Parse(Luong);
                UpdateModel(nv);
                db.SaveChanges();

                return RedirectToAction("Index", "NhanVien");
            }
            return this.Sua(id);
        }

        [HttpGet]
        public ActionResult Xoa(string id)
        {
            var query = db.NhanViens.First(m => m.Manv == id);
            return View(query);
        }
        
        [HttpPost]
        public ActionResult Xoa(string id, FormCollection data)
        {
            var query = db.NhanViens.Where(nv => nv.Manv == id).First();
            db.NhanViens.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "NhanVien");
        }
    }
}
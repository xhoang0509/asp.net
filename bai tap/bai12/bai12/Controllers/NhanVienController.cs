using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai12.Models;

namespace bai12.Controllers
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
            var query = db.NhanViens.Where(m => m.Manv == id).First();
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
            // gán giá trị người dung nhập cho các biến
            var ma = data["Manv"];
            var ten = data["Hoten"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            if (String.IsNullOrEmpty(ma))
            {
                ViewData["Loi1"] = "Mã nhân viên không được để trống!";
            }
            else if (String.IsNullOrEmpty(ten))
            {
                ViewData["Loi2"] = "Tên nhân viên không được để trống";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewData["Loi3"] = "Phòng không được để trống!";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewData["Loi4"] = "Lương không dược để trống!";
            }
            else
            {
                nv.Manv = ma;
                nv.Hoten = ten;
                nv.Phong = phong;
                nv.Luong = Convert.ToDouble(luong);
                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Them();
        }

        [HttpGet]
        public ActionResult Xoa(string id)
        {
            var query = db.NhanViens.First(nv => nv.Manv == id);
            return View(query);
        }

        [HttpPost]
        public ActionResult Xoa(string id, FormCollection data)
        {
            var query = db.NhanViens.First(nv => nv.Manv == id);
            db.NhanViens.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            var nv = db.NhanViens.First(n => n.Manv == id);
            var ten = data["Hoten"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            if(String.IsNullOrEmpty(ten))
            {
                ViewData["Loi1"] = "Tên không được để trống !";
            } else if(String.IsNullOrEmpty(phong))
            {
                ViewData["Loi2"] = "Phòng không được để trống!";
            } else if(String.IsNullOrEmpty(luong))
            {
                ViewData["Loi3"] = "Lương không được để trống!";
            } else
            {
                // gan gia tri cho doi tuong tạo moi (nv)
                nv.Hoten = ten;
                nv.Phong = phong;
                nv.Luong = Double.Parse(luong);
                UpdateModel(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
        }
    }
}
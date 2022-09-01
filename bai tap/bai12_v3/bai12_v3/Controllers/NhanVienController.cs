using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using bai12_v3.Models;

namespace bai12_v3.Controllers
{
    public class NhanVienController : Controller
    {
        private QLLuongDB db = new QLLuongDB();

        public ActionResult Index(string sapTheoLuong, string from, string to, string ten)
        {
            ViewBag.SapTheoLuong = sapTheoLuong == "luong_tang" ? "luong_giam" : "luong_tang";
            var query = db.NhanViens.Select(p => p);
            if (!String.IsNullOrEmpty(from) && !String.IsNullOrEmpty(to))
            {
                int iForm = Convert.ToInt32(from);
                int iTo = Convert.ToInt32(to);
                query = query.Where(nv => nv.Luong >= iForm && nv.Luong <= iTo);
            }

            if(!String.IsNullOrEmpty(ten))
            {
                query = query.Where(p => p.Hoten.Contains(ten));
            }

            switch (sapTheoLuong)
            {
                case "luong":
                    query = query.OrderBy(nv => nv.Luong);
                    break;
                case "luong_giam":
                    query = query.OrderByDescending(nv => nv.Luong);
                    break;
                default:
                    break;
            }

            return View(query.ToList());
        }

        [HttpGet]
        public ActionResult ChiTiet(string id)
        {
            var query = db.NhanViens.First(nv => nv.Manv == id);
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
            var manv = data["Manv"];
            var hoten = data["Hoten"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            if (String.IsNullOrEmpty(manv))
            {
                ViewData["Loi1"] = "Mã nhân viên không được để trống!";
            }
            else if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi2"] = "Họ tên không được để trống!";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewData["Loi3"] = "Phòng không được để trống!";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewData["Loi4"] = "Lương không được để trống!";
            }
            else
            {
                nv.Manv = manv;
                nv.Hoten = hoten;
                nv.Phong = phong;
                nv.Luong = Double.Parse(luong);

                db.NhanViens.Add(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Them();
        }

        [HttpGet]
        public ActionResult Sua(string id)
        {
            var query = db.NhanViens.First(nv => nv.Manv == id);
            return View(query);
        }

        [HttpPost]
        public ActionResult Sua(string id, FormCollection data)
        {
            var nv = db.NhanViens.First(n => n.Manv == id);

            var hoten = data["Hoten"];
            var phong = data["Phong"];
            var luong = data["Luong"];

            if (String.IsNullOrEmpty(hoten))
            {
                ViewData["Loi2"] = "Họ tên không được để trống!";
            }
            else if (String.IsNullOrEmpty(phong))
            {
                ViewData["Loi3"] = "Phòng không được để trống!";
            }
            else if (String.IsNullOrEmpty(luong))
            {
                ViewData["Loi4"] = "Lương không được để trống!";
            }
            else
            {
                nv.Hoten = hoten;
                nv.Phong = phong;
                nv.Luong = Double.Parse(luong);

                UpdateModel(nv);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return this.Sua(id);
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
            var query = db.NhanViens.Where(nv => nv.Manv == id).First();
            db.NhanViens.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De8.Models;

namespace De8.Controllers
{
    public class Cau5Controller : Controller
    {
        private De8DB db = new De8DB();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection data, BenhNhan bn)
        {
            try
            {
                var Manv = data["Mabn"];
                var Hoten = data["Hoten"];
                var Khoakham = data["Khoakham"];
                var Tuoi = data["Tuoi"];

                if (String.IsNullOrEmpty(Manv))
                {
                    ViewData["Loi1"] = "Mã không được để trống";
                }
                else if (String.IsNullOrEmpty(Hoten))
                {
                    ViewData["Loi2"] = "Họ tên không được để trống";
                }
                else if (String.IsNullOrEmpty(Khoakham))
                {
                    ViewData["Loi3"] = "Họ tên không được để trống";
                }
                else
                {
                    var benhNhanExist = db.BenhNhans.Where(p => p.Mabn == Manv).First();

                    if(benhNhanExist != null)
                    {
                        ViewBag.Error = "Mã bệnh nhân đã tồn tại, hãy thử lại";
                        return this.Index();
                    }

                    bn.Mabn = Manv;
                    bn.Hoten = Hoten;
                    bn.Khoakham = Khoakham;
                    bn.Tuoi = Convert.ToInt32(Tuoi);
                    db.BenhNhans.Add(bn);
                    db.SaveChanges();
                    return RedirectToAction("Index", "BenhNhans");
                }
                return this.Index();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập ! - " + ex.Message;
                return this.Index();
            }
        }
    }
}
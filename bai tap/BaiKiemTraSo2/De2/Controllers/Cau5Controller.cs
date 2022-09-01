using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De2.Models;

namespace De2.Controllers
{
    public class Cau5Controller : Controller
    {
        private NguyenXuanHoang db = new NguyenXuanHoang();
        // GET: Cau5
        public ActionResult Index()
        {
            return View();
        }

        // POST: HoSoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahs,Hoten,Donvi,Bacluong")] HoSo hoSo)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var hoSoExist = db.HoSoes.SingleOrDefault(hs => hs.Mahs == hoSo.Mahs);
                    if (hoSoExist != null)
                    {
                        ViewBag.Error = "Mã hồ sơ đã tồn tại, hãy thử lại";
                        return View("Index", hoSo);
                    }

                    db.HoSoes.Add(hoSo);
                    db.SaveChanges();
                }
                ViewBag.Success = "Tạo hồ sơ thành công!";
                return RedirectToAction("../HoSoes/Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi tạo hồ sơ ! - " + ex.Message;
                return View("Index", hoSo);
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De3.Models;

namespace De3.Controllers
{
    public class Cau5Controller : Controller
    {
        private NguyenXuanHoang db = new NguyenXuanHoang();
        // GET: Cau5
        public ActionResult Index()
        {
            return View();
        }

        // POST: Hangs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahang,Tenhang,Loai,Gia")] Hang hang)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var hExist = db.Hangs.SingleOrDefault(h => h.Mahang == hang.Mahang);
                    if (hExist != null)
                    {
                        ViewBag.Error = "Mã hàng đã tồn tại, hãy thử lại!";
                        return View("Index", hang);
                    }

                    db.Hangs.Add(hang);
                    db.SaveChanges();
                }

                return RedirectToAction("../Hangs/Index");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "Có lỗi khi nhập dữ liệu ! - " + ex.Message;
                return View("Index", hang);
            }
        }
    }
}
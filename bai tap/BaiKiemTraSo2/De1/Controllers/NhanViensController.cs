using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De1.Models;

namespace De1.Controllers
{
    public class NhanViensController : Controller
    {
        private NguyenXuanHoang db = new NguyenXuanHoang();

        // GET: NhanViens
        public ActionResult Index(string toLuong, string fromLuong)
        {
            int sum = 0;
            if (!string.IsNullOrEmpty(toLuong) && !string.IsNullOrEmpty(fromLuong))
            {
                ViewBag.toLuong = toLuong;
                ViewBag.fromLuong = fromLuong;
                int iToLuong = int.Parse(toLuong.Trim());
                int iFromLuong = int.Parse(fromLuong.Trim());
                var nhanVienFilter = db.NhanViens.Where(nv => nv.Luong >= iToLuong && nv.Luong <= iFromLuong).ToList();
                foreach (NhanVien nv in nhanVienFilter)
                {
                    sum += (int)nv.Luong;
                }
                ViewBag.Tong = sum;
                return View(nhanVienFilter);
            }
            ViewBag.Tong = sum;
            return View(db.NhanViens.ToList());
        }

        // GET: NhanViens/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NhanViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
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
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                return View(nhanVien);
            }

        }

        // GET: NhanViens/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Manv,Hoten,Phong,Luong")] NhanVien nhanVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhanVien);
        }

        // GET: NhanViens/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return HttpNotFound();
            }
            return View(nhanVien);
        }

        // POST: NhanViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

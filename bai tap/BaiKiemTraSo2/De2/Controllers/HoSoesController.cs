using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De2.Models;

namespace De2.Controllers
{
    public class HoSoesController : Controller
    {
        private NguyenXuanHoang db = new NguyenXuanHoang();

        // GET: HoSoes
        public ActionResult Index(string toBacLuong, string fromBacLuong)
        {
            int sum = 0;
            ViewBag.Sum = sum;
            if (!string.IsNullOrEmpty( toBacLuong) && !string.IsNullOrEmpty( fromBacLuong))
            {
                ViewBag.toBacLuong = toBacLuong;
                ViewBag.fromBacLuong = fromBacLuong;
                int iToBacLuong = int.Parse(toBacLuong);
                int iFromBacLuong = int.Parse(fromBacLuong);

                var hoSosFilter = db.HoSoes.Where(hs => hs.Bacluong >= iToBacLuong && hs.Bacluong <= iFromBacLuong).ToList();
                foreach (var hs in hoSosFilter)
                {
                    sum += (int)hs.Bacluong * 1300000;
                }
                ViewBag.Sum = sum;
                return View(hoSosFilter);
            }
            return View(db.HoSoes.ToList());
        }

        // GET: HoSoes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // GET: HoSoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HoSoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mahs,Hoten,Donvi,Bacluong")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.HoSoes.Add(hoSo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoSo);
        }

        // GET: HoSoes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // POST: HoSoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mahs,Hoten,Donvi,Bacluong")] HoSo hoSo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoSo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoSo);
        }

        // GET: HoSoes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HoSo hoSo = db.HoSoes.Find(id);
            if (hoSo == null)
            {
                return HttpNotFound();
            }
            return View(hoSo);
        }

        // POST: HoSoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HoSo hoSo = db.HoSoes.Find(id);
            db.HoSoes.Remove(hoSo);
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

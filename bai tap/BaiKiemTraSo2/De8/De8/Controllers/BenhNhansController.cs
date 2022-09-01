using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using De8.Models;

namespace De8.Controllers
{
    public class BenhNhansController : Controller
    {
        private De8DB db = new De8DB();

        // GET: BenhNhans
        public ActionResult Index(string start, string end, string tuoi)
        {
            ViewBag.Tuoi = tuoi == "tuoi_tang" ? "tuoi_giam" : "tuoi_tang";

            var benhNhans = db.BenhNhans.Select(bn => bn);

            switch (tuoi)
            {
                case "tuoi_tang":
                    benhNhans = benhNhans.OrderBy(bn => bn.Tuoi);
                    break;
                case "tuoi_giam":
                    benhNhans = benhNhans.OrderByDescending(bn => bn.Tuoi);
                    break;
                default:
                    break;
            }

            if (!String.IsNullOrEmpty(start) && !String.IsNullOrEmpty(end))
            {
                ViewBag.Start = start;
                ViewBag.End = end;

                int iStart = Convert.ToInt32(start);
                int iEnd = Convert.ToInt32(end);

                benhNhans = benhNhans.Where(bn => bn.Tuoi >= iStart && bn.Tuoi <= iEnd);
            }
            return View(benhNhans.ToList());
        }

        // GET: BenhNhans/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // GET: BenhNhans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BenhNhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Mabn,Hoten,Khoakham,Tuoi")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                db.BenhNhans.Add(benhNhan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(benhNhan);
        }

        // GET: BenhNhans/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // POST: BenhNhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Mabn,Hoten,Khoakham,Tuoi")] BenhNhan benhNhan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(benhNhan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(benhNhan);
        }

        // GET: BenhNhans/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            if (benhNhan == null)
            {
                return HttpNotFound();
            }
            return View(benhNhan);
        }

        // POST: BenhNhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            BenhNhan benhNhan = db.BenhNhans.Find(id);
            db.BenhNhans.Remove(benhNhan);
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

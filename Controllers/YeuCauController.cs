using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NhaKhoaMVC5.DAL;
using NhaKhoaMVC5.Models;

namespace NhaKhoaMVC5.Controllers
{
    public class YeuCauController : Controller
    {
        private NhaKhoaContext db = new NhaKhoaContext();

        // GET: YeuCau
        public ActionResult Index()
        {
            var yeuCauTB = db.YeuCauTB.Include(y => y.KhachHang).Include(y => y.NhaSi);
            return View(yeuCauTB.ToList());
        }

        // GET: YeuCau/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCau yeuCau = db.YeuCauTB.Find(id);
            if (yeuCau == null)
            {
                return HttpNotFound();
            }
            return View(yeuCau);
        }

        // GET: YeuCau/Create
        public ActionResult Create()
        {
            ViewBag.MaKH = new SelectList(db.KhachHangTB, "MaKH_ID", "MaKH_ID");
            ViewBag.MaNhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID");
            return View();
        }

        // POST: YeuCau/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaYC_ID,MaNhaSi,MaKH,NgayYC,TongTien")] YeuCau yeuCau)
        {
            yeuCau.MaYC_ID = "yc" + db.YeuCauTB.Count()+1;
            yeuCau.NgayYC = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.YeuCauTB.Add(yeuCau);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaKH = new SelectList(db.KhachHangTB, "MaKH_ID", "MaKH_ID", yeuCau.MaKH);
            ViewBag.MaNhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID", yeuCau.MaNhaSi);
            return View(yeuCau);
        }

        // GET: YeuCau/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCau yeuCau = db.YeuCauTB.Find(id);
            if (yeuCau == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaKH = new SelectList(db.KhachHangTB, "MaKH_ID", "MaKH_ID", yeuCau.MaKH);
            ViewBag.MaNhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID", yeuCau.MaNhaSi);
            return View(yeuCau);
        }

        // POST: YeuCau/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaYC_ID,MaNhaSi,MaKH,NgayYC,TongTien")] YeuCau yeuCau)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yeuCau).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaKH = new SelectList(db.KhachHangTB, "MaKH_ID", "MaKH_ID", yeuCau.MaKH);
            ViewBag.MaNhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID", yeuCau.MaNhaSi);
            return View(yeuCau);
        }

        // GET: YeuCau/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YeuCau yeuCau = db.YeuCauTB.Find(id);
            if (yeuCau == null)
            {
                return HttpNotFound();
            }
            return View(yeuCau);
        }

        // POST: YeuCau/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            YeuCau yeuCau = db.YeuCauTB.Find(id);
            db.YeuCauTB.Remove(yeuCau);
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

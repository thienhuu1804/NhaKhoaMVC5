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
    public class ChiTietYeuCau_ThuocController : Controller
    {
        private NhaKhoaContext db = new NhaKhoaContext();

        // GET: ChiTietYeuCau_Thuoc
        public ActionResult Index()
        {
            var chiTietYeuCauThuoc = db.ChiTietYeuCauThuoc.Include(c => c.Thuoc).Include(c => c.YeuCau);
            return View(chiTietYeuCauThuoc.ToList());
        }

        // GET: ChiTietYeuCau_Thuoc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc = db.ChiTietYeuCauThuoc.Find(id);
            if (chiTietYeuCau_Thuoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietYeuCau_Thuoc);
        }

        // GET: ChiTietYeuCau_Thuoc/Create
        public ActionResult Create()
        {
            ViewBag.MaThuoc_ID = new SelectList(db.ThuocTB, "MaThuoc_ID", "TenThuoc");
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaNhaSi");
            return View();
        }

        // POST: ChiTietYeuCau_Thuoc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stt,MaYC_ID,MaThuoc_ID,SoLuong")] ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietYeuCauThuoc.Add(chiTietYeuCau_Thuoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaThuoc_ID = new SelectList(db.ThuocTB, "MaThuoc_ID", "TenThuoc", chiTietYeuCau_Thuoc.MaThuoc_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaNhaSi", chiTietYeuCau_Thuoc.MaYC_ID);
            return View(chiTietYeuCau_Thuoc);
        }

        // GET: ChiTietYeuCau_Thuoc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc = db.ChiTietYeuCauThuoc.Find(id);
            if (chiTietYeuCau_Thuoc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaThuoc_ID = new SelectList(db.ThuocTB, "MaThuoc_ID", "TenThuoc", chiTietYeuCau_Thuoc.MaThuoc_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaNhaSi", chiTietYeuCau_Thuoc.MaYC_ID);
            return View(chiTietYeuCau_Thuoc);
        }

        // POST: ChiTietYeuCau_Thuoc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stt,MaYC_ID,MaThuoc_ID,SoLuong")] ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietYeuCau_Thuoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaThuoc_ID = new SelectList(db.ThuocTB, "MaThuoc_ID", "TenThuoc", chiTietYeuCau_Thuoc.MaThuoc_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaNhaSi", chiTietYeuCau_Thuoc.MaYC_ID);
            return View(chiTietYeuCau_Thuoc);
        }

        // GET: ChiTietYeuCau_Thuoc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc = db.ChiTietYeuCauThuoc.Find(id);
            if (chiTietYeuCau_Thuoc == null)
            {
                return HttpNotFound();
            }
            return View(chiTietYeuCau_Thuoc);
        }

        // POST: ChiTietYeuCau_Thuoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietYeuCau_Thuoc chiTietYeuCau_Thuoc = db.ChiTietYeuCauThuoc.Find(id);
            db.ChiTietYeuCauThuoc.Remove(chiTietYeuCau_Thuoc);
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

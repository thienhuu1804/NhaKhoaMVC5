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
    public class ChiTietYeuCau_DichVuController : Controller
    {
        private NhaKhoaContext db = new NhaKhoaContext();

        // GET: ChiTietYeuCau_DichVu
        public ActionResult Index()
        {
            var chiTietYeuCauDichVu = db.ChiTietYeuCauDichVu.Include(c => c.DichVu).Include(c => c.YeuCau);
            return View(chiTietYeuCauDichVu.ToList());
        }

        // GET: ChiTietYeuCau_DichVu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_DichVu chiTietYeuCau_DichVu = db.ChiTietYeuCauDichVu.Find(id);
            if (chiTietYeuCau_DichVu == null)
            {
                return HttpNotFound();
            }
            return View(chiTietYeuCau_DichVu);
        }
        //Get List Chitiet by MaDV
        public ActionResult Details(string madv)
        {
            if (madv == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IEnumerable<ChiTietYeuCau_DichVu> chiTietYeuCau_DichVu = db.ChiTietYeuCauDichVu.Where(i => i.MaYC_ID == madv);
            if (chiTietYeuCau_DichVu == null)
            {
                return HttpNotFound();
            }
            return View(chiTietYeuCau_DichVu);
        }

        // GET: ChiTietYeuCau_DichVu/Create

        public ActionResult Create()
        {

            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB.ToList(), "MaYC_ID", "MaYC_ID");
            ViewBag.MaDV_ID = new SelectList(db.DichVuTB.ToList(), "MaDV_ID", "MaDV_ID");
            //ViewBag.NhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID");
            return View();
        }


        // POST: ChiTietYeuCau_DichVu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Stt_ID,MaYC_ID,MaDV_ID")] ChiTietYeuCau_DichVu chiTietYeuCau_DichVu)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietYeuCauDichVu.Add(chiTietYeuCau_DichVu);
                db.SaveChanges();
                return Redirect("../ChiTietYeuCau_Thuoc/create");
            }

            ViewBag.MaDV_ID = new SelectList(db.DichVuTB, "MaDV_ID", "MaDV_ID", chiTietYeuCau_DichVu.MaDV_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaYC_ID", chiTietYeuCau_DichVu.MaYC_ID);
            //ViewBag.NhaSi = new SelectList(db.NhanVienTB, "MaNV_ID", "MaNV_ID", chiTietYeuCau_DichVu.MaDV_ID);
            return View(chiTietYeuCau_DichVu);
        }

        // GET: ChiTietYeuCau_DichVu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_DichVu chiTietYeuCau_DichVu = db.ChiTietYeuCauDichVu.Find(id);
            if (chiTietYeuCau_DichVu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDV_ID = new SelectList(db.DichVuTB, "MaDV_ID", "MaDV_ID", chiTietYeuCau_DichVu.MaDV_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaYC_ID", chiTietYeuCau_DichVu.MaYC_ID);
            return View(chiTietYeuCau_DichVu);
        }

        // POST: ChiTietYeuCau_DichVu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Stt_ID,MaDV_ID,MaYC_ID")] ChiTietYeuCau_DichVu chiTietYeuCau_DichVu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietYeuCau_DichVu).State = EntityState.Modified;
                db.SaveChanges();
                return Redirect("../ChiTietYeuCau_Thuoc/edit");
            }
            ViewBag.MaDV_ID = new SelectList(db.DichVuTB, "MaDV_ID", "MaDV_ID", chiTietYeuCau_DichVu.MaDV_ID);
            ViewBag.MaYC_ID = new SelectList(db.YeuCauTB, "MaYC_ID", "MaYC_ID", chiTietYeuCau_DichVu.MaYC_ID);
            return View(chiTietYeuCau_DichVu);
        }

        // GET: ChiTietYeuCau_DichVu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietYeuCau_DichVu chiTietYeuCau_DichVu = db.ChiTietYeuCauDichVu.Find(id);
            if (chiTietYeuCau_DichVu == null)
            {
                return HttpNotFound();
            }
            return View(chiTietYeuCau_DichVu);
        }

        // POST: ChiTietYeuCau_DichVu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietYeuCau_DichVu chiTietYeuCau_DichVu = db.ChiTietYeuCauDichVu.Find(id);
            db.ChiTietYeuCauDichVu.Remove(chiTietYeuCau_DichVu);
            db.SaveChanges();
            return Redirect("../ChiTietYeuCau_Thuoc/delete");
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

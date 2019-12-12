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
    public class TaiKhoanController : Controller
    {
        private NhaKhoaContext db = new NhaKhoaContext();

        // GET: TaiKhoan
        public ActionResult Index()
        {
            var taiKhoanTB = db.TaiKhoanTB.Include(t => t.NhanVien);
            return View(taiKhoanTB.ToList());
        }

        // GET: TaiKhoan/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoanTB.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // GET: TaiKhoan/Create
        public ActionResult Create()
        {
            ViewBag.MaNV_ID = new SelectList(db.NhanVienTB, "MaNV_ID", "MaCV");
            return View();
        }

        // POST: TaiKhoan/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TenTaiKhoan_ID,MatKhau,MaNV_ID")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.TaiKhoanTB.Add(taiKhoan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaNV_ID = new SelectList(db.NhanVienTB, "MaNV_ID", "MaCV", taiKhoan.MaNV_ID);
            return View(taiKhoan);
        }

        // GET: TaiKhoan/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoanTB.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaNV_ID = new SelectList(db.NhanVienTB, "MaNV_ID", "MaCV", taiKhoan.MaNV_ID);
            return View(taiKhoan);
        }

        // POST: TaiKhoan/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TenTaiKhoan_ID,MatKhau,MaNV_ID")] TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taiKhoan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaNV_ID = new SelectList(db.NhanVienTB, "MaNV_ID", "MaCV", taiKhoan.MaNV_ID);
            return View(taiKhoan);
        }

        // GET: TaiKhoan/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaiKhoan taiKhoan = db.TaiKhoanTB.Find(id);
            if (taiKhoan == null)
            {
                return HttpNotFound();
            }
            return View(taiKhoan);
        }

        // POST: TaiKhoan/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TaiKhoan taiKhoan = db.TaiKhoanTB.Find(id);
            db.TaiKhoanTB.Remove(taiKhoan);
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

        //Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "TenTaiKhoan_ID,MatKhau")] TaiKhoan taiKhoan)
        {
            var check = db.TaiKhoanTB.SingleOrDefault(u => u.TenTaiKhoan_ID == taiKhoan.TenTaiKhoan_ID && u.MatKhau == taiKhoan.MatKhau);
            if(check != null)
            {
                Session["username"] = check.TenTaiKhoan_ID.ToString();
                Session["pass"] = check.MatKhau.ToString();
                return Redirect("~/Home");
            }
            else
            {
                ModelState.AddModelError("","Tài khoản hoặc mật khẩu sai!");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if(Session["username"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}

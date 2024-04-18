using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication4;

namespace WebApplication4.Models
{
    public class CarOptionsController : Controller
    {
        private CasestudyEntities db = new CasestudyEntities();

        // GET: CarOptions
        public ActionResult Index()
        {
            var carOptions = db.CarOptions.Include(c => c.BranchDetail);
            return View(carOptions.ToList());
        }

        // GET: CarOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOption carOption = db.CarOptions.Find(id);
            if (carOption == null)
            {
                return HttpNotFound();
            }
            return View(carOption);
        }

        // GET: CarOptions/Create
        public ActionResult Create()
        {
            ViewBag.ShowroomID = new SelectList(db.BranchDetails, "BranchID", "BranchName");
            return View();
        }

        // POST: CarOptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CarID,CarName,CarModel,CarPrice,ShowroomID")] CarOption carOption)
        {
            if (ModelState.IsValid)
            {
                db.CarOptions.Add(carOption);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShowroomID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carOption.ShowroomID);
            return View(carOption);
        }

        // GET: CarOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOption carOption = db.CarOptions.Find(id);
            if (carOption == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShowroomID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carOption.ShowroomID);
            return View(carOption);
        }

        // POST: CarOptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CarID,CarName,CarModel,CarPrice,ShowroomID")] CarOption carOption)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carOption).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShowroomID = new SelectList(db.BranchDetails, "BranchID", "BranchName", carOption.ShowroomID);
            return View(carOption);
        }

        // GET: CarOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarOption carOption = db.CarOptions.Find(id);
            if (carOption == null)
            {
                return HttpNotFound();
            }
            return View(carOption);
        }

        // POST: CarOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarOption carOption = db.CarOptions.Find(id);
            db.CarOptions.Remove(carOption);
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

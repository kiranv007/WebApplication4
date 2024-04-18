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
    public class BookingRequestsController : Controller
    {
        private CasestudyEntities db = new CasestudyEntities();

        // GET: BookingRequests
        public ActionResult Index()
        {
            var bookingRequests = db.BookingRequests.Include(b => b.CarDetail).Include(b => b.CustomerDetail);
            return View(bookingRequests.ToList());
        }

        // GET: BookingRequests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            if (bookingRequest == null)
            {
                return HttpNotFound();
            }
            return View(bookingRequest);
        }

        // GET: BookingRequests/Create
        public ActionResult Create()
        {
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName");
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName");
            return View();
        }

        // POST: BookingRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RequestID,CarID,CustomerID,RequestDate,Status")] BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                db.BookingRequests.Add(bookingRequest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName", bookingRequest.CarID);
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName", bookingRequest.CustomerID);
            return View(bookingRequest);
        }

        // GET: BookingRequests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            if (bookingRequest == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName", bookingRequest.CarID);
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName", bookingRequest.CustomerID);
            return View(bookingRequest);
        }

        // POST: BookingRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RequestID,CarID,CustomerID,RequestDate,Status")] BookingRequest bookingRequest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingRequest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarID = new SelectList(db.CarDetails, "CarID", "CarName", bookingRequest.CarID);
            ViewBag.CustomerID = new SelectList(db.CustomerDetails, "CustomerID", "FirstName", bookingRequest.CustomerID);
            return View(bookingRequest);
        }

        // GET: BookingRequests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            if (bookingRequest == null)
            {
                return HttpNotFound();
            }
            return View(bookingRequest);
        }

        // POST: BookingRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingRequest bookingRequest = db.BookingRequests.Find(id);
            db.BookingRequests.Remove(bookingRequest);
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

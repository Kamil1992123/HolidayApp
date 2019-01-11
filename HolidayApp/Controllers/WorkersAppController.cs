using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HolidayApp.Models;

namespace HolidayApp.Controllers
{
    public class WorkersAppController : Controller
    {
        private HolidayEntities1 db = new HolidayEntities1();

        // GET: WorkersApp
        public ActionResult Index()
        {
            var workers = db.Workers.Include(w => w.WorkerHolidayLeft);
            return View(workers.ToList());
        }


        public ActionResult Worker()
        {
            
            return View();
        }





        // GET: WorkersApp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // GET: WorkersApp/Create
        public ActionResult Create()
        {
            ViewBag.HolidayID = new SelectList(db.WorkerHolidayLeft, "HolidayID", "HolidayID");
            return View();
        }

        // POST: WorkersApp/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkerID,Name,Surname,Email,Password,DepartmentID,HolidayID")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Workers.Add(workers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HolidayID = new SelectList(db.WorkerHolidayLeft, "HolidayID", "HolidayID", workers.HolidayID);
            return View(workers);
        }

        // GET: WorkersApp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            ViewBag.HolidayID = new SelectList(db.WorkerHolidayLeft, "HolidayID", "HolidayID", workers.HolidayID);
            return View(workers);
        }

        // POST: WorkersApp/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkerID,Name,Surname,Email,Password,DepartmentID,HolidayID")] Workers workers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HolidayID = new SelectList(db.WorkerHolidayLeft, "HolidayID", "HolidayID", workers.HolidayID);
            return View(workers);
        }

        // GET: WorkersApp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Workers workers = db.Workers.Find(id);
            if (workers == null)
            {
                return HttpNotFound();
            }
            return View(workers);
        }

        // POST: WorkersApp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Workers workers = db.Workers.Find(id);
            db.Workers.Remove(workers);
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

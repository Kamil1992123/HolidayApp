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
    public class WorkerAppController : Controller
    {
        private HolidayEntities1 db = new HolidayEntities1();

        // GET: WorkerApp
        public ActionResult Index()
        {
            var aplications = db.Aplications.Include(a => a.Workers).Include(a => a.Departments).Include(a => a.Status);
            return View(aplications.ToList());
        }

        // GET: WorkerApp/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplications aplications = db.Aplications.Find(id);
            if (aplications == null)
            {
                return HttpNotFound();
            }
            return View(aplications);
        }

        // GET: WorkerApp/Create
        public ActionResult Create()
        {
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name");
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName");
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Status1");
            return View();
        }

        // POST: WorkerApp/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AplicationID,WorkerID,HolidayStart,HolidayStop,DayOffSum,DepartmentID,HolidayType,StatusID")] Aplications aplications)
        {
            if (ModelState.IsValid)
            {
                db.Aplications.Add(aplications);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", aplications.WorkerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", aplications.DepartmentID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Status1", aplications.StatusID);
            return View(aplications);
        }




        public JsonResult getApp(string id)
        {
            List<Aplications> app = new List<Aplications>();
            app = db.Aplications.ToList();
            return Json(app, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult AddApp(Aplications app)
        {


            //var app = new Aplications();

            //if (ModelState.IsValid)
            //{

                db.Aplications.Add(app);
                db.SaveChanges();
                string message = "SUCCESS";
                return Json(new { Message = message, JsonRequestBehavior.AllowGet });
            //}




           

            //app.WorkerID = WorkerID;
            //app.DepartmentID = Department;
            //app.HolidayStart = HolidayStart;
            //app.HolidayStop = HolidayStop;
            //app.HolidayType = HolidayType;
            //app.DayOffSum = DayOffSum;
            //app.StatusID = Status;



            //ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", aplications.WorkerID);
            //ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", aplications.DepartmentID);
            //ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Status1", aplications.StatusID);
            //return Json(app, JsonRequestBehavior.AllowGet);


        }





        // GET: WorkerApp/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplications aplications = db.Aplications.Find(id);
            if (aplications == null)
            {
                return HttpNotFound();
            }
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", aplications.WorkerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", aplications.DepartmentID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Status1", aplications.StatusID);
            return View(aplications);
        }

        // POST: WorkerApp/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AplicationID,WorkerID,HolidayStart,HolidayStop,DayOffSum,DepartmentID,HolidayType,StatusID")] Aplications aplications)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplications).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.WorkerID = new SelectList(db.Workers, "WorkerID", "Name", aplications.WorkerID);
            ViewBag.DepartmentID = new SelectList(db.Departments, "DepartmentID", "DepartmentName", aplications.DepartmentID);
            ViewBag.StatusID = new SelectList(db.Status, "StatusID", "Status1", aplications.StatusID);
            return View(aplications);
        }

        // GET: WorkerApp/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplications aplications = db.Aplications.Find(id);
            if (aplications == null)
            {
                return HttpNotFound();
            }
            return View(aplications);
        }

        // POST: WorkerApp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplications aplications = db.Aplications.Find(id);
            db.Aplications.Remove(aplications);
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

using HolidayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult AddWorker(string Name, string Surname, string Department, int HolidaysLeft)
        {
            var worker = new WorkerModel();

            worker.Name = Name;
            worker.Surname = Surname;
            worker.Department = Department;
            worker.HolidaysLeft = HolidaysLeft;

            return Json(worker, JsonRequestBehavior.AllowGet);


        }

    }
}
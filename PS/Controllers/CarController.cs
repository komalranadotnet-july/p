using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PS.Models;
using PS.Models.ViewModels;

namespace PS.Controllers
{
    public class CarController : Controller
    {
        private ApplicationDbContext dbObj = new ApplicationDbContext();
        // GET: Car
        public ActionResult Index()
        {
            return View(dbObj.cars.ToList());
        }
        //public ActionResult Details1()
        //{
        //    var find = new ViewCustCar
        //    {
        //        IEcar = dbObj.cars.Where(q => q.customer.Id == 99).ToList(),
        //        IEcust = dbObj.customers.FirstOrDefault(c => c.Id == 99)
        //    };
        //    return View("details");
        //}
        public ActionResult Addnew()
        {
            return View();
        }
        public ActionResult Details(int id)
        {
            var find = dbObj.cars.Where(q => q.Uid == id).ToList();
            //var find = dbObj.cars.SingleOrDefault(q => q.Uid== id);
            if (find==null)
            {
                return RedirectToAction("Addnew");
            }
            return View(find);
        }
        public ActionResult Delete(int id)
        {
            //new Car().CarsId = id;
            var del = dbObj.cars.Find(id);//new Car().CarsId=id);
            dbObj.cars.Remove(del);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(ViewCar cars)
        {
            dbObj.cars.Add(cars.IEcarsView);
            dbObj.SaveChanges();
            return RedirectToAction("Index", "car");
            //[HttpPost]
            //public Action New()
            //{
            //    var cars = dbObj.cars.ToList();
            //    var viewModel = new ViewCustCar
            //    {
            //        IEcust = new Customer(),
            //        IEcar = cars
            //    };
            //    return View("New", viewModel);
            //}
            //[HttpPost]
            //public ActionResult Save(Car car)
            //{
            //    if (!ModelState.IsValid)
            //    {
            //        var viewModel = new ViewCustCar
            //        {
            //           IEcar=car,
            //            IEcust=dbObj.customers.ToList()
            //        };
            //        return View("New", viewModel);
            //    }
            //}

        }
    }
}

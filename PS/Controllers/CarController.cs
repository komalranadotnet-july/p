using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
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
            //dynamic fetchid = id;
            //dynamic check = dbObj.cars.Any(q=>q.Uid==id);
            //if (fetchid != check)
            //{
            //    return Content("No car with this id");
            //    //("no car fond with this id");
            //}
            var find = dbObj.cars.Where(q => q.Uid == id).ToList();
            //var find = dbObj.cars.SingleOrDefault(q => q.Uid== id);
            if (find==null)
            {
                return View("Addnew");
            }
           
            return View(find);
        }
        public ActionResult Delete(int id)
        {
            var obj = dbObj.cars.Find(id);
            dbObj.cars.Remove(obj);
            dbObj.SaveChanges();
            return RedirectToAction("Index" ,"Customer");
        }





        public ActionResult Edit(int id)
        {

            var updateCars = dbObj.cars.Find(id);
            if (updateCars == null)
            {
                return HttpNotFound();
            }

            var m = updateCars;

            dbObj.SaveChanges();

            return View("New", m);
        }








        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Create(ViewCar cars)
        //{
        //    dbObj.cars.Add(cars.IEcarsView);
        //    dbObj.SaveChanges();
        //    return RedirectToAction("Index","Customer");
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

        // }



        public ActionResult Save(Car cars)
        {

            if (cars.CarsId == 0)
                dbObj.cars.Add(cars);

            else
            {
                var customerInDb = dbObj.cars.Single(c => c.CarsId == cars.CarsId);
                customerInDb.Color= cars.Color;
                customerInDb.Make = cars.Make;
                customerInDb.MYear = cars.MYear;
                customerInDb.Model = cars.Model;
                customerInDb.Vin = cars.Vin;
                customerInDb.Style= cars.Style;
                customerInDb.Uid = cars.Uid;



            }
            dbObj.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }


    }
}

using PS.Models;
using PS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace PS.Controllers
{
    public class ServiceHistoryController : Controller
    {
        private ApplicationDbContext dbObj = new ApplicationDbContext();

        // GET: ServiceHistory
        public ActionResult Index()
        {
        var serviceHistory = dbObj.services.Include(s => s.ServiceTypes).ToList();

            return View(serviceHistory);
        }


        //public ActionResult Details(int id)
        //{
        //    var find = dbObj.services.Where(c => c.CarsId== id).ToList();


        //    if (find == null)
        //    {
        //        return View("New","NewService");
        //    }

        //    return View(find);
        //}


        //public ActionResult Details(int id,Services sevices)
        //{
        //    var det = dbObj.services.SingleOrDefault(p => p.CarsId == id);
        //    return View(det);
        //}



        public ActionResult Details(int id)
        {
          
            var find = dbObj.services.Where(q => q.CarsId == id).ToList();
            //var find = dbObj.cars.SingleOrDefault(q => q.Uid== id);
            if (find == null)
            {
                return View("Addnew");
            }

            return View(find);
        }




    }
}

    

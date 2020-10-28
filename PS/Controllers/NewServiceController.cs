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
    public class NewServiceController : Controller
    {
        private ApplicationDbContext dbObj = new ApplicationDbContext();
        // GET: NewService
        //       public ActionResult Index()
        //       {
        //           var newService = dbObj.services.Include(s => s.ServiceTypes).ToList();
        //           return View(newService);
        ////return View(dbObj.services.ToList());
        //       }


       public ActionResult New()
        {
            var serviceType = dbObj.ServiceTypes.ToList();

            var viewModel = new AddServiceViewModel
            {
                Services = new Services(),
                ServiceTypes = serviceType
            };
            return View("New", viewModel);


        }
        [HttpPost]
        public ActionResult Save(Services services)
        {

            if (services.Id== 0)
                dbObj.services.Add(services);

            else
            {
                var newService = dbObj.services.Single(c => c.Id == services.Id);
                       newService.Miles = newService.Miles;
                       newService.TotPrice = newService.TotPrice;
                        newService.Details = newService.Details;
                        newService.DateAdded = newService.DateAdded;
                        newService.CarsId = newService.CarsId;
               

            }
            dbObj.SaveChanges();
            return RedirectToAction("Index", "ServiceHistory");
        }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PS.Models;

namespace PS.Controllers
{
    public class CustomerController : Controller
    {
       private ApplicationDbContext dbObj = new ApplicationDbContext();
        // GET: Customer
        public ActionResult Index()
        {
            var alldata = dbObj.customers.ToList();
            return View(alldata);
        }
        public ActionResult Details(int id)
        {
            var det = dbObj.customers.SingleOrDefault(p => p.Id == id);
            return View(det);
        }
        //public ActionResult Edit(int id)
        //{
        //    var e = dbObj.customers.SingleOrDefault(Q => Q.Id == id);
        //    var uname = e.Name;
        //    var uphn = e.PhoneNo;
        //    var uemail = e.Email;
        //    dbObj.SaveChanges();
        //    return View("Edit");

        //}









        public ActionResult Edit(int id)
        {

            var updateCustomer = dbObj.customers.Find(id);
            if (updateCustomer == null)
            {
                return HttpNotFound();
            }

            var m = updateCustomer;

           dbObj.SaveChanges();

            return View("New", m);
        }




        public ActionResult New()
        {
            return View();
        }
        [HttpPost]
        //public ActionResult Save(Customer c)
        //{

        //    dbObj.customers.Add(c);
        //    dbObj.SaveChanges();
        //    return RedirectToAction("Index", "Customer");

        //}
        public ActionResult Save(Customer customer)
        {

            if (customer.Id == 0)
                dbObj.customers.Add(customer);

            else
            {
                var customerInDb = dbObj.customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.PhoneNo = customer.PhoneNo;
                customerInDb.Email = customer.Email;


            }
            dbObj.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }











        public ActionResult Delete(int id)
        {
            var obj = dbObj.customers.Find(id);
            dbObj.customers.Remove(obj);
            dbObj.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult New(Customer customer)
        {
            var all = dbObj.customers.ToList();
            return View("New");
        }
    }

}
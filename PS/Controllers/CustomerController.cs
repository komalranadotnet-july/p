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
        public ActionResult Edit(int id)
        {
            var e = dbObj.customers.SingleOrDefault(Q => Q.Id == id);
            var uname = e.Name;
            var uphn = e.PhoneNo;
            var uemail = e.Email;
            dbObj.SaveChanges();
            return RedirectToAction("Index", "Customer");

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Customer c)
        {
            
            dbObj.customers.Add(c);
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
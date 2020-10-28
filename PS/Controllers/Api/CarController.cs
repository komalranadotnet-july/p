using PS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PS.Controllers.Api
{
    public class CarController : ApiController
    {

        private ApplicationDbContext _context;
        private Car carInDb;

        public CarController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<Car> GetCar()
        {
            return _context.cars.ToList();
        }
        public Car GetCar(int id)
        {
            var car = _context.cars.SingleOrDefault(c => c.CarsId == id);
            if (car == null)
                throw new HttpRequestException();
            return car;
        }
        [HttpPost]
        public Car CreateCar(Car car)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException();
            _context.cars.Add(car);
            _context.SaveChanges();
            return car;
        }
        [HttpPut]
        public void UpdateCar(int id, Car car)
        {
            if (!ModelState.IsValid)
                throw new HttpRequestException();
            var carInDb = _context.cars.SingleOrDefault(c => c.CarsId == id);
            if (carInDb == null)
                throw new HttpRequestException();
            carInDb.Vin = car.Vin;
            carInDb.Make = car.Make;
            carInDb.Model = car.Model;
            carInDb.Style = car.Style;
            carInDb.MYear = car.MYear;
            carInDb.Color = car.Color;
            carInDb.Uid = car.Uid;
            carInDb.customer = car.customer;
            carInDb.CId = car.CId;
            _context.SaveChanges();
        }
        public void DeleteCar(int id)
        {
            var carInDb = _context.cars.SingleOrDefault(c => c.CarsId == id);
            if (carInDb == null)
            {
                throw new HttpRequestException();
            }

            _context.cars.Remove(carInDb);
            _context.SaveChanges();


        }
    }
}

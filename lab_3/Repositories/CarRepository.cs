﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_3.Models;
using Microsoft.EntityFrameworkCore;

namespace lab_3.Repositories
{

    public class CarRepository
    {
        private CarServiceKpzContext _context;

        public CarRepository(CarServiceKpzContext context)
        {
            _context = context;
        }

        public List<Car> GetAll()
        {
            //return _context.Cars.ToList();
            return _context.Cars
            .Include(car => car.CarModel)  // Include CarModel
            .Include(car => car.Color)      // Include Color
            .Include(car => car.Customer)   // Include Customer
            .ToList();
        }

        public void Add(Car car)
        {
            _context.Cars.Add(car);
            _context.SaveChanges();
        }

        public void Update(Car car)
        {
            _context.Cars.Update(car);
            _context.SaveChanges();
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }
    }
}

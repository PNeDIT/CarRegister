namespace CarRegister.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using CarRegister.Data;
    using CarRegister.Data.Models;
    using CarRegister.Services.Interfaces;

    public class CarService : ICarService
    {
        private ApplicationDbContext db;

        public CarService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Add(Car car)
        {
            db.Cars.Add(car);
            db.SaveChanges();
        }

        public void Delete(int carId)
        {
            var car = db.Cars.FirstOrDefault(x => x.Id == carId);
            if(car == null) return;
            car.IsDeleted = true;
            db.SaveChanges();
        }

        public void EditCar(Car newCar)
        {
            var carToEdit = this.GetById(newCar.Id);

            carToEdit.Brand = newCar.Brand;
            carToEdit.Model = newCar.Model;
            carToEdit.Seats = newCar.Seats;
            carToEdit.ReleaseDate = newCar.ReleaseDate;

            db.SaveChanges();
        }

        public List<Car> GetAll()
        {
            return db.Cars.Where(x => !x.IsDeleted).ToList();
        }

        public Car GetById(int id)
        {
            return db.Cars.FirstOrDefault(x => x.Id == id);
        }
    }
}

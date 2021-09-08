namespace CarRegister.Services.Interfaces
{
    using System.Collections.Generic;
    using CarRegister.Data.Models;

    public interface ICarService
    {
        void Add(Car car);

        List<Car> GetAll();

        Car GetById(int id);

        void EditCar(Car newCar);

        void Delete(int carId);
    }
}

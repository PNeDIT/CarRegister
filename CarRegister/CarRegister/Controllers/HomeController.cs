namespace CarRegister.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using CarRegister.Models;
    using CarRegister.Data.Models;
    using CarRegister.Services.Interfaces;

    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public IActionResult CarRegister()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Index()
        {
            var cars = this.carService.GetAll();

            return View(cars);
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Save(Car car)
        {
            this.carService.Add(car);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult GetCar(int carId)
        {
            var car = this.carService.GetById(carId);

            return View(car);
        }

        [HttpPost]
        public IActionResult Edit(Car car)
        {
            this.carService.EditCar(car);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int carId)
        {
            this.carService.Delete(carId);

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

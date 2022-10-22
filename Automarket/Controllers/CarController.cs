using Automarket.Domain.ViewModels.Car;
using Automarket.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Automarket.Controllers;

public class CarController : Controller
{
    private readonly ICarService _carService;

    public CarController(ICarService carService)
    {
        _carService = carService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCars()
    {
        var responce = await _carService.GetCars();
        if (responce.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(responce.Data.ToList());
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    public async Task<IActionResult> GetCar(int id)
    {
        var response = await _carService.GetCar(id);
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(response.Data);
        }

        return RedirectToAction("Error");
    }

    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(int id)
    {
        var response = await _carService.DeleteCar(id); 
        if (response.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return RedirectToAction("GetCars");
        }

        return RedirectToAction("Error");
    }

    [HttpGet]
    public async Task<IActionResult> Save(int id)
    {
        if (id == 0)
        {
            return View();
        }

        var responce = await _carService.GetCar(id);
        if (responce.StatusCode == Domain.Enum.StatusCode.OK)
        {
            return View(responce.Data);
        }

        return RedirectToAction("Error");
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Save(CarViewModel model)
    {
        if (ModelState.IsValid)
        {
            if (model.Id == 0)
            {
                await _carService.CreateCar(model);
            }
            else
            {
                await _carService.Edit(model.Id, model);
            }
        }

        return RedirectToAction("GetCars");
    }
}
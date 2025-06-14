using Microsoft.AspNetCore.Mvc;
using Kolokwium.Services.Interfaces;
using Kolokwium.ViewModel.VM;

namespace Kolokwium.Web.Controllers;

public class AddKsiazkaController : Controller
{
    private readonly IKsiazkaService _ksiazkaService;

    public AddKsiazkaController(IKsiazkaService ksiazkaService)
    {
        _ksiazkaService = ksiazkaService;
    }


    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(AddKsiazkaVm addKsiazkaVm)
    {
        if (ModelState.IsValid)
        {
            var result = _ksiazkaService.AddKsiazka(addKsiazkaVm);
            return RedirectToAction("Index", "Ksiazka");
        }
        return View(addKsiazkaVm);
    }
}
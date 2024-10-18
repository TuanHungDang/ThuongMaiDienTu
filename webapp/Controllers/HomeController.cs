using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using webapp.Models;

namespace webapp.Controllers;

public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;

    public IActionResult Index()
    {
        ViewBag.Categories = Provider.Category.GetCategories();
        return View(Provider.Product.GetProducts());
    }

}

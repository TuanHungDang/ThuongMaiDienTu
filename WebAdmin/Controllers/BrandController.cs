using Microsoft.AspNetCore.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers;

public class BrandController : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Brand.GetBrands());
    }

     public IActionResult Delete(byte id)
    {
        int ret = Provider.Brand.Delete(id);
        if (ret > 0)
        {
            return Redirect("/brand");
        }
        return Redirect("/brand/error");
    }


    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Brand obj)
    {
        Provider.Brand.Add(obj);
        return Redirect("/brand");
    }

    public IActionResult Edit(byte id)
    {
        return View(Provider.Brand.GetBrand(id));
    }
    [HttpPost]
    public IActionResult Edit(byte id, Brand obj)
    {
        obj.BrandId = id;
        int ret = Provider.Brand.Edit(obj);
        if (ret > 0)
        {
            return Redirect("/Brand");
        }
        ModelState.AddModelError("Error", "Update failed");
        return View(obj);
    }
}
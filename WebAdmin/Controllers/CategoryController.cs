using Microsoft.AspNetCore.Mvc;
using WebAdmin.Models;
namespace WebAdmin.Controllers;

public class CategoryController : BaseController
{
    public IActionResult Index()
    {
        return View(Provider.Category.GetCategories());
    }

    public IActionResult Delete(byte id)
    {
        int ret = Provider.Category.Delete(id);
        if (ret > 0)
        {
            return Redirect("/category");
        }
        return Redirect("/category/error");
    }


    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Add(Category obj)
    {
        Provider.Category.Add(obj);
        return Redirect("/Category");
    }

    public IActionResult Edit(byte id)
    {
        return View(Provider.Category.GetCategory(id));
    }
    [HttpPost]
    public IActionResult Edit(byte id, Category obj)
    {
        obj.CategoryId = id;
        int ret = Provider.Category.Edit(obj);
        if (ret > 0)
        {
            return Redirect("/Category");
        }
        ModelState.AddModelError("Error", "Update failed");
        return View(obj);
    }
}
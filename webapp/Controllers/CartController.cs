using Microsoft.AspNetCore.Mvc;
using webapp.Models;

namespace webapp.Controllers;

public class CartController : BaseController
{
    const string cart = "cart";
    public IActionResult CheckOut()
    {  
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }
        return View(Provider.Cart.GetCarts(code));
    }
    public IActionResult Index()
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }

        return View(Provider.Cart.GetCarts(code));
    }

    [HttpPost]

    public IActionResult Edit(Cart obj)
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            return Redirect("/");
        }
        obj.CartCode = code;
        return Json(Provider.Cart.Edit(obj));
    }

    [HttpPost]
    public IActionResult Add(Cart obj)
    {
        //Cookies
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            code = Guid.NewGuid().ToString().Replace("-", "");
            Response.Cookies.Append(cart, code);
        }
        obj.CartCode = code;
        int ret = Provider.Cart.Add(obj);
        if (ret > 0)
        {
            return Redirect("/cart");
        }

        return Redirect("/cart/error");
    }

    public IActionResult Delete(int id)
    {
        string? code = Request.Cookies[cart];
        if (string.IsNullOrEmpty(code))
        {
            code = Guid.NewGuid().ToString().Replace("-", "");
            Response.Cookies.Append(cart, code);
        }
        int ret = Provider.Cart.Delete(code, id);
        if (ret > 0)
        {
            return Redirect("/cart");
        }

        return Redirect("/cart/error");
    }
}
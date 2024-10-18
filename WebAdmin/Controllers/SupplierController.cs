using Microsoft.AspNetCore.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers;

public class SupplierController:BaseController
{
        public IActionResult Index()
        {
            return View(Provider.Supplier.GetSuppliers());
        }

        public IActionResult Delete(string id)
        {
            int ret = Provider.Supplier.Delete(id);
            if(ret > 0)
            {
                return Redirect("/supplier");
            }
            return Redirect("/supplier/error");
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Supplier obj)
        {
            Provider.Supplier.Add(obj);
            return Redirect("/Supplier");
        }

        public IActionResult Edit(string id){
            return View(Provider.Supplier.GetSupplier(id));
        }
        [HttpPost]
        public IActionResult Edit(string id, Supplier obj)
        {
            obj.SupplierId = id;
            int ret = Provider.Supplier.Edit(obj);
            if(ret > 0)
            {
                return Redirect("/supplier");
            }
            ModelState.AddModelError("Error", "Update failed");
            return View(obj);
        }
}
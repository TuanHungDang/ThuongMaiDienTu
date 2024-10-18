using Microsoft.AspNetCore.Mvc;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.Categories = Provider.Category.GetCategories();
            return View(Provider.Product.GetProducts());
        }

        public IActionResult Delete(byte id)
        {
            int ret = Provider.Product.Delete(id);
            if (ret > 0)
            {
                return Redirect("/product");
            }
            return Redirect("/product/error");
        }

        public IActionResult Add()
        {
            ViewBag.Brands = Provider.Brand.GetBrands(); // Get list of brands for selection
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product obj, IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
        {
            var filePath = Path.Combine("wwwroot/image/products", imageFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            obj.Image = imageFile.FileName; // Lưu đường dẫn ảnh vào obj
        }

            // Pass both the product object and the selected brand name to the Add method
            Provider.Product.Add(obj);
            return Redirect("/product");
        }

        public IActionResult Edit(byte id)
        {
            ViewBag.Brands = Provider.Brand.GetBrands(); // For editing the brand
            return View(Provider.Product.GetProduct(id));
        }

        [HttpPost]
        public IActionResult Edit(byte id, Product obj,IFormFile imageFile)
        {
            if (imageFile != null && imageFile.Length > 0)
        {
            var filePath = Path.Combine("wwwroot/image/products", imageFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }
            obj.Image =  imageFile.FileName; // Cập nhật đường dẫn ảnh
        }
        else
        {
            // Nếu không có ảnh mới thì giữ nguyên ảnh cũ
            var existingProduct = Provider.Product.GetProduct(id);
            obj.Image = existingProduct.Image;
        }
            obj.ProductId = id;
            int ret = Provider.Product.Edit(obj);
            if (ret > 0)
            {
                return Redirect("/product");
            }
            ModelState.AddModelError("Error", "Update failed");
            return View(obj);
        }
    }
}

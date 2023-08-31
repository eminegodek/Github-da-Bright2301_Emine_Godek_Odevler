using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Entity.Concrete;
using EducationApp.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EducationApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productManager;

        public HomeController(ICategoryService categoryManager, IProductService productManager)
        {
            _productManager = productManager;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productList = await _productManager.GetProductsWithFullDataAsync(true, true);
            List<ProductViewModel> productViewModelList = productList.Select(p => new ProductViewModel
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                Url = p.Url,
                ImageUrl = p.ImageUrl,
                InstructorName = p.Instructor.FirstName + " " + p.Instructor.LastName,
                InstructorUrl = p.Instructor.Url,
            }).ToList();
            return View(productViewModelList);
        }
    }
}
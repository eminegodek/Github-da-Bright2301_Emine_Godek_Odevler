using AspNetCoreHero.ToastNotification.Abstractions;
using EducationApp.Business.Abstract;
using EducationApp.Core;
using EducationApp.Entity.Concrete;
using EducationApp.MVC.Areas.Admin.Models;
using Iyzipay.Model.V2.Subscription;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using Product = EducationApp.Entity.Concrete.Product;

namespace EducationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productManager;
        private readonly IInstructorService _instructorManager;
        private readonly ICategoryService _categoryManager;
        private readonly INotyfService _notyf;

        public ProductController(IProductService productManager, IInstructorService instructorManager, ICategoryService categoryManager, INotyfService notyf)
        {
			_productManager = productManager;
			_instructorManager = instructorManager;
            _categoryManager = categoryManager;
            _notyf = notyf;
        }

        #region Listeleme
        public async Task<IActionResult> Index()
        {
            List<Product> products = await _productManager.GetAllProductsWithInstructor(false);
            List<ProductViewModel> productViewModelList = products
                .Select(b => new ProductViewModel
				{
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    InstructorName = b.Instructor.FirstName + " " + b.Instructor.LastName,
                }).ToList();
            ProductListViewModel model = new ProductListViewModel
            {
                ProductViewModelList = productViewModelList,
                SourceAction = "Index"
            };
            return View(model);
        }
        #endregion
        #region Yardımcı Metotlar(Action Olmayanlar)
        [NonAction]
        private async Task<List<SelectListItem>> GetInstructorSelectList()
        {
            List<Instructor> instructorList = await _instructorManager.GetAllInstructorsAsync(false, true);
            List<SelectListItem> instructorViewModelList = instructorList.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.FirstName + " " + a.LastName
            }).ToList();
            return instructorViewModelList;
        }

        [NonAction]
        private async Task<List<CategoryViewModel>> GetCategoryList()
        {
            List<Category> categoryList = await _categoryManager.GetAllCategoriesAsync(false, true);
            List<CategoryViewModel> categoryViewModelList = categoryList.Select(c => new CategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return categoryViewModelList;
        }

        [NonAction]
        private List<SelectListItem> GetYearList(int startYear, int endYear)
        {
            List<int> years = Jobs.GetYears(startYear, endYear);
            List<SelectListItem> yearList = years.Select(y => new SelectListItem
            {
                Value = y.ToString(),
                Text = y.ToString()
            }).ToList();
            return yearList;
        }
        #endregion
        #region Yeni Eğitim
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var instructorViewModelList = await GetInstructorSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            ProductAddViewModel productAddViewModel = new ProductAddViewModel
            {
                InstructorList = instructorViewModelList,
                CategoryList = categoryViewModelList,
                YearList = yearList
            };
            return View(productAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductAddViewModel productAddViewModel)
        {
            if (ModelState.IsValid && productAddViewModel.SelectedCategoryIds.Count > 0)
            {
                var url = Jobs.GetUrl(productAddViewModel.Name);
                Product product = new Product
                {
                    Name = productAddViewModel.Name,
                    Description = productAddViewModel.Description,
                    IsActive = productAddViewModel.IsActive,
                    IsHome = productAddViewModel.IsHome,
                    ModifiedDate = DateTime.Now,
                    InstructorId = productAddViewModel.InstructorId,
                    Price = productAddViewModel.Price,
                    Url = url,
                    ImageUrl = Jobs.UploadImage(productAddViewModel.ImageFile, url, "products")
                };
                await _productManager.CreateProductAsync(product, productAddViewModel.SelectedCategoryIds);
                _notyf.Success("Kayıt işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            if (productAddViewModel.SelectedCategoryIds.Count == 0)
            {
                ViewBag.CategoryErrorMessage = "En az bir kategori seçilmelidir.";
            }
            var instructorViewModelList = await GetInstructorSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
            productAddViewModel.InstructorList = instructorViewModelList;
            productAddViewModel.CategoryList = categoryViewModelList;
            productAddViewModel.YearList = yearList;
            return View(productAddViewModel);
        }

        #endregion
        #region Eğitim Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product product = await _productManager.GetProductByIdAsync(id);
            if (product==null)
            {
                _notyf.Warning("Sadece aktif ve silinmemiş kitaplar düzenlenebilir.");
                return RedirectToAction("Index");
            }
            ProductEditViewModel productEditViewModel = new ProductEditViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
				InstructorId = product.InstructorId,
                ImageUrl = product.ImageUrl,
                IsActive = product.IsActive,
                IsDeleted = product.IsDeleted,
                IsHome = product.IsHome,
                Price = product.Price,
                SelectedCategoryIds = product.ProductCategories.Select(bc => bc.CategoryId).ToList(),
                InstructorList = await GetInstructorSelectList(),
                CategoryList = await GetCategoryList(),
                YearList = GetYearList(1900, DateTime.Now.Year)
            };
            return View(productEditViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ProductEditViewModel productEditViewModel)
        {
            if (ModelState.IsValid && productEditViewModel.SelectedCategoryIds.Count()>0)
            {
                Product product = new Product();
                var url = Jobs.GetUrl(productEditViewModel.Name);
                product.Id= productEditViewModel.Id;
				product.Name= productEditViewModel.Name;
				product.Description= productEditViewModel.Description;
				product.Price = productEditViewModel.Price;
				product.IsActive = productEditViewModel.IsActive;
				product.IsHome = productEditViewModel.IsHome;
				product.IsDeleted = productEditViewModel.IsDeleted;
				//product.InstructorId = productEditViewModel.InstructorId;
				product.Url = url;
                
                product.ProductCategories = productEditViewModel.SelectedCategoryIds.Select(sc => new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = sc
                }).ToList();
                product.ImageUrl = productEditViewModel.ImageFile == null ? productEditViewModel.ImageUrl : Jobs.UploadImage(productEditViewModel.ImageFile, url, "products");
                _productManager.UpdateProduct(product);
                _notyf.Success("Güncelleme işlemi başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            var instructorViewModelList = await GetInstructorSelectList();
            var categoryViewModelList = await GetCategoryList();
            var yearList = GetYearList(1900, DateTime.Now.Year);
			productEditViewModel.InstructorList = instructorViewModelList;
			productEditViewModel.CategoryList = categoryViewModelList;
			productEditViewModel.YearList = yearList;
            return View(productEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Product product = await _productManager.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
			product.IsActive = !product.IsActive;
			product.ModifiedDate = DateTime.Now;
			_productManager.Update(product);
            string isActive = product.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Kitap başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Eğitim Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _productManager.GetProductByIdAsync(id);
            if (product == null) return NotFound();
            ProductDeleteViewModel productDeleteViewModel = new ProductDeleteViewModel
            {
                Id = product.Id,
                Name = product.Name,
                InstructorName = product.Instructor.FirstName + " " + product.Instructor.LastName,
                Price = product.Price,
                IsActive = product.IsActive,
                IsHome = product.IsHome
            };
            return View(productDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
			Product product = await _productManager.GetByIdAsync(id);
            if (product == null) return NotFound();
            _productManager.Delete(product);
            return RedirectToAction("Index");
        }
        #endregion"
        #region Eğitim Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Product product = await _productManager.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            product.IsDeleted = !product.IsDeleted;
			product.ModifiedDate = DateTime.Now;
            _productManager.Update(product);
            string message = product.IsDeleted ? "Kayıt silinmiştir. Geri almak için ilgili bölüme geçiniz." : "Kayıt geri alınmıştır.";
            _notyf.Success(message);
            return product.IsDeleted ? RedirectToAction("Index") : RedirectToAction("DeletedIndex");
        }
        #endregion
        #region Silinmiş Eğitim Listeleme
        public async Task<IActionResult> DeletedIndex()
        {
            List<Product> products = await _productManager.GetAllProductsWithInstructor(true);
            List<ProductViewModel> productViewModelList = products
                .Select(b => new ProductViewModel
				{
                    Id = b.Id,
                    Name = b.Name,
                    Price = b.Price,
                    ImageUrl = b.ImageUrl,
                    IsActive = b.IsActive,
                    InstructorName = b.Instructor.FirstName + " " + b.Instructor.LastName,
                }).ToList();
            ProductListViewModel model = new ProductListViewModel
			{
				ProductViewModelList = productViewModelList,
                SourceAction = "DeletedIndex"
            };
            return View("Index", model);
        }

        #endregion

    }
}

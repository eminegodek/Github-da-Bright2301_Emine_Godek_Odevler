using AspNetCoreHero.ToastNotification.Abstractions;
using EducationApp.Business.Abstract;
using EducationApp.Business.Concrete;
using EducationApp.Core;
using EducationApp.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using EducationApp.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationApp.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class InstructorController : Controller
    {
        private readonly IInstructorService _instructorManager;
        private readonly IProductService _productManager;
        private readonly INotyfService _notyf;

		public InstructorController(IInstructorService instructorManager, INotyfService notyf, IProductService productManager)
		{
			_instructorManager = instructorManager;
			_notyf = notyf;
			_productManager = productManager;
		}

		#region Listeleme
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			List<Instructor> instructorList = await _instructorManager.GetAllInstructorsAsync(false);
			List<InstructorViewModel> instructorViewModelList = instructorList
				.Select(i => new InstructorViewModel
				{
					Id = i.Id,
					Name = i.FirstName + " " + i.LastName,
					CreatedDate = i.CreatedDate,
					ModifiedDate = i.ModifiedDate,
					About = i.About,
					IsActive = i.IsActive,
					Url = i.Url,
					PhotoUrl = i.PhotoUrl,
					BirthOfYear = i.BirthOfYear
				}).ToList();
			InstructorListViewModel model = new InstructorListViewModel
			{
				InstructorViewModelList = instructorViewModelList,
				SourceAction = "Index"
			};
			return View(model);
		}
		#endregion
		#region Yeni Eğitmen
		[HttpGet]
        public IActionResult Create()
        {
            List<int> years = Jobs.GetYears(0, 2005);
            InstructorAddViewModel instructorAddViewModel = new InstructorAddViewModel
            {
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString()
                }).ToList()
            };
            return View(instructorAddViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InstructorAddViewModel instructorAddViewModel)
        {
            if (ModelState.IsValid)
            {
                string name = instructorAddViewModel.FirstName + " " + instructorAddViewModel.LastName;
                Instructor instructor = new Instructor
                {
                    FirstName = instructorAddViewModel.FirstName,
                    LastName = instructorAddViewModel.LastName,
                    About = instructorAddViewModel.About,
                    IsActive = instructorAddViewModel.IsActive,
                    BirthOfYear = instructorAddViewModel.BirthOfYear,
                    Url = Jobs.GetUrl(name),
                    PhotoUrl = "default-profile.jpg"

                };
                await _instructorManager.CreateWithUrl(instructor);
                _notyf.Success("Yazar kaydı başarıyla tamamlanmıştır.");
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0, 2005);
            instructorAddViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString()
            }).ToList();
            return View(instructorAddViewModel);
        }

        #endregion
        #region Eğitmen Güncelleme
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Instructor instructor = await _instructorManager.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            var years = Jobs.GetYears(0, 2005);
            InstructorEditViewModel instructorEditViewModel = new InstructorEditViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                About = instructor.About,
                BirthOfYear = instructor.BirthOfYear,
                IsActive = instructor.IsActive,
                IsDeleted = instructor.IsDeleted,
                Url = instructor.Url,
                Years = years.Select(y => new SelectListItem
                {
                    Text = y.ToString(),
                    Value = y.ToString(),
                    Selected = instructor.BirthOfYear == y ? true : false
                }).ToList()
            };

            return View(instructorEditViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InstructorEditViewModel instructorEditViewModel)
        {
            if (ModelState.IsValid)
            {
                Instructor instructor = await _instructorManager.GetByIdAsync(instructorEditViewModel.Id);
                if (instructor == null) { return NotFound(); }
                instructor.FirstName = instructorEditViewModel.FirstName;
                instructor.LastName = instructorEditViewModel.LastName;
                instructor.About = instructorEditViewModel.About;
                instructor.BirthOfYear = instructorEditViewModel.BirthOfYear;
                instructor.IsActive = instructorEditViewModel.IsActive;
                instructor.IsDeleted = instructorEditViewModel.IsDeleted;
                instructorEditViewModel.Url = Jobs.GetUrl(instructorEditViewModel.FirstName + "-" + instructorEditViewModel.LastName);
                instructor.Url = instructorEditViewModel.Url;
                instructor.ModifiedDate = DateTime.Now;
                _instructorManager.Update(instructor);
                _notyf.Success("Yazar bilgisi başarıyla güncellenmiştir.", 2);
                return RedirectToAction("Index");
            }
            List<int> years = Jobs.GetYears(0, 2005);
            instructorEditViewModel.Years = years.Select(y => new SelectListItem
            {
                Text = y.ToString(),
                Value = y.ToString(),
                Selected = instructorEditViewModel.BirthOfYear == y ? true : false
            }).ToList();
            return View(instructorEditViewModel);
        }
        public async Task<IActionResult> UpdateIsActive(int id)
        {
            Instructor instructor = await _instructorManager.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            instructor.IsActive = !instructor.IsActive;
            instructor.ModifiedDate = DateTime.Now;
            _instructorManager.Update(instructor);
            string isActive = instructor.IsActive ? "Aktif" : "Pasif";
            _notyf.Success($"Yazar başarıyla {isActive} duruma getirilmiştir.");
            return RedirectToAction("Index");
        }
        #endregion
        #region Eğitmen Kalıcı Silme
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Instructor instructor = await _instructorManager.GetByIdAsync(id);
            if (instructor == null) return NotFound();
            InstructorDeleteViewModel instructorDeleteViewModel = new InstructorDeleteViewModel
            {
                Id = instructor.Id,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                About = instructor.About,
                Url = instructor.Url,
                IsActive = instructor.IsActive,
                IsDeleted = instructor.IsDeleted,
                CreatedDate = instructor.CreatedDate,
                ModifiedDate = instructor.ModifiedDate
            };
            return View(instructorDeleteViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> HardDelete(int id)
        {
            Instructor instructor = await _instructorManager.GetByIdAsync(id);
            if (instructor == null) return NotFound();
            _instructorManager.Delete(instructor);
            return RedirectToAction("Index");
        }
        #endregion
        #region Eğitmen Soft Silme
        public async Task<IActionResult> SoftDelete(int id)
        {
            Instructor instructor = await _instructorManager.GetByIdAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }
            instructor.IsDeleted = true;
            instructor.ModifiedDate = DateTime.Now;
            _instructorManager.Update(instructor);
            return RedirectToAction("Index");
        }
		#endregion
		#region Silinmiş Eğitmenleri Listeleme
		[HttpGet]
		public async Task<IActionResult> DeletedIndex()
		{
			List<Instructor> instructorList = await _instructorManager.GetAllInstructorsAsync(true);
			List<InstructorViewModel> instructorViewModelList = instructorList
				.Select(a => new InstructorViewModel
				{
					Id = a.Id,
					Name = a.FirstName + " " + a.LastName,
					CreatedDate = a.CreatedDate,
					ModifiedDate = a.ModifiedDate,
					About = a.About,
					IsActive = a.IsActive,
					Url = a.Url,
					PhotoUrl = a.PhotoUrl,
					BirthOfYear = a.BirthOfYear
				}).ToList();
			InstructorListViewModel model = new InstructorListViewModel
			{
				InstructorViewModelList = instructorViewModelList,
				SourceAction = "DeletedIndex"
			};
			return View("Index", model);
		}
		#endregion

	}
}

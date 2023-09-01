using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using EducationApp.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EducationApp.MVC.Areas.Admin.Models
{
    public class InstructorAddViewModel
    {
        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(2, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string FirstName { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(4, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(50, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string LastName { get; set; }

        [DisplayName("Doğum Yılı")]
        public int BirthOfYear { get; set; } = 1900;

        [DisplayName("Hakkında")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamalıdır.")]
        [MinLength(5, ErrorMessage = "{0} alanı en az {1} karakter uzunluğunda olmalıdır.")]
        [MaxLength(1000, ErrorMessage = "{0} alanı en fazla {1} karakter uzunluğunda olmalıdır.")]
        public string About { get; set; }

        public bool IsActive { get; set; }
        public string ImageUrl { get; set; } = "1.png";

        public List<SelectListItem> Years { get; set; }
    }
}

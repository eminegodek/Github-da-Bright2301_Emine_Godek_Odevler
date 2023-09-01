using EducationApp.Data.Concrete.EfCore;
using System.ComponentModel.DataAnnotations;

namespace EducationApp.MVC.Models
{
    public class CartViewModel
    {
        public int CartId { get; set; }
        public List<CartItemViewModel> CartItems { get; set; }
        public decimal? TotalPrice()
        {
            return CartItems.Sum(ci=>ci.Price * ci.Quantity);
        }
    }
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductUrl { get; set; }
        public string ProductImageUrl { get; set; }
        public decimal? Price { get; set; }
        [Required(ErrorMessage ="Boş bırakılmalalıdır.")]
        public int Quantity { get; set; }
    }
}

using EducationApp.Business.Abstract;
using EducationApp.Data.Abstract;
using EducationApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Business.Concrete
{
    public class CartManager : ICartService
    {
        private ICartRepository _cartRepository;

        public CartManager(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task AddToCart(string userId, int productId, int quantity)
        {
            await _cartRepository.AddToCartAsync(userId, productId, quantity);
        }

        public Task<Cart> GetByIdAsync(int id)
        {
			return _cartRepository.GetByIdAsync(id);
		}

        public async Task<Cart> GetCartByUserId(string id)
        {
            return await _cartRepository.GetCartByUserId(id);
        }

        public async Task InitializeCart(string userId)
        {
            await _cartRepository.CreateAsync(new Cart { UserId = userId });
        }
    }
}

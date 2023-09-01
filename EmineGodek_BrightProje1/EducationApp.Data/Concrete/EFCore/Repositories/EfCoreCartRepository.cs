using EducationApp.Data.Abstract;
using EducationApp.Data.Concrete.EFCore.Contexts;
using EducationApp.Data.Concrete.EFCore.Repositories;
using EducationApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationApp.Data.Concrete.EfCore.Repositories
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart>, ICartRepository
    {
        public EfCoreCartRepository(EducationAppContext _appContext) : base(_appContext)
        {

        }
		EducationAppContext AppContext
        {
            get { return _dbContext as EducationAppContext; }
        }

        public async Task AddToCartAsync(string userId, int productId, int quantity)
        {
            var cart = await GetCartByUserId(userId);
            if (cart != null)
            {
                var index = cart.CartItems.FindIndex(ci => ci.ProductId == productId);
                if (index < 0)
                {
                    cart.CartItems.Add(new CartItem
                    {
                        ProductId = productId,
                        CartId = cart.Id,
                        Quantity = quantity
                    });
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }

                AppContext.Carts.Update(cart);
                await AppContext.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartByUserId(string userId)
        {
            var result = await AppContext
                .Carts
                .Where(c => c.UserId == userId)
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync();
            return result;
        }
    }
}

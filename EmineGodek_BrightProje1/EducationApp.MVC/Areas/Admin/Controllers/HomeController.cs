using EducationApp.Business.Abstract;
using EducationApp.Entity.Concrete;
using EducationApp.Entity.Concrete.ComplexTypes;
using EducationApp.MVC.Areas.Admin.Models;
using EducationApp.MVC.Extensions;
using EducationApp.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationApp.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class HomeController : Controller
	{
		private readonly IOrderService _orderManager;

		public HomeController(IOrderService orderManager)
		{
			_orderManager = orderManager;
		}

		public async Task<IActionResult> Index()
		{
			var totalSalesAmount = await _orderManager.GetTotalAsync(0);
			var totalSalesCount = await _orderManager.GetTotalAsync(1);
			var totalBookSalesCount = await _orderManager.GetTotalAsync(2);
			AdminDashboardViewModel model = new AdminDashboardViewModel
			{
				TotalSalesAmount = totalSalesAmount == "" ? 0 : Convert.ToDecimal(totalSalesAmount),
				TotalSalesCount = totalSalesCount == "" ? 0 : Convert.ToInt32(totalSalesCount),
				TotalProductSalesCount = totalBookSalesCount == "" ? 0 : Convert.ToInt32(totalBookSalesCount)
			};
			List<Order> receivedOrderList = await _orderManager.GetAllOrdersAsync(null, true, OrderStatus.Received);
			List<OrderViewModel> receivedOrders = receivedOrderList.Select(o => new OrderViewModel
			{
				Id = o.Id,
				FirstName = o.FirstName,
				LastName = o.LastName,
				City = o.City,
				Address = o.Address,
				PhoneNumber = o.PhoneNumber,
				Email = o.Email,
				OrderDate = o.OrderDate,
				OrderItems = o.OrderItems,
				OrderStatus = o.OrderStatus.GetDisplayName()
			}).ToList();
			model.ReceivedOrders = receivedOrders;

			List<Order> preparingOrderList = await _orderManager.GetAllOrdersAsync(null, true, OrderStatus.Preparing);
			List<OrderViewModel> preparingOrders = preparingOrderList.Select(o => new OrderViewModel
			{
				Id = o.Id,
				FirstName = o.FirstName,
				LastName = o.LastName,
				City = o.City,
				Address = o.Address,
				PhoneNumber = o.PhoneNumber,
				Email = o.Email,
				OrderDate = o.OrderDate,
				OrderItems = o.OrderItems,
				OrderStatus = o.OrderStatus.GetDisplayName()
			}).ToList();
			model.PreparingOrders = preparingOrders;


			return View(model);
		}
	}
}

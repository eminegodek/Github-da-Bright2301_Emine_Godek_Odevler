using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EducationApp.MVC.Models;

namespace EducationApp.MVC.Areas.Admin.Models
{
    public class AdminDashboardViewModel
    {
        public decimal? TotalSalesAmount { get; set; }
        public int TotalSalesCount { get; set; }
        public int TotalProductSalesCount { get; set; }
        public List<OrderViewModel> ReceivedOrders { get; set; }
        public List<OrderViewModel> PreparingOrders { get; set; }
        public List<OrderViewModel> SentOrders { get; set; }
        public List<OrderViewModel> DeliveredOrders { get; set; }
    }
}
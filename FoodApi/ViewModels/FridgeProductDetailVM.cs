using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.ViewModels
{
    public class FridgeProductDetailVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal quantity { get; set; }
        public DateTime CreateDate { get; set; }
        public string NutritionDetails { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
}

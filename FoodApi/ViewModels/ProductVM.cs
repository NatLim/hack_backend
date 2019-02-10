using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.ViewModels
{
    public class ProductVM
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int ExpireDays { get; set; }
    }
}

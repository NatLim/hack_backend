using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodApi.dbhelper
{
    public class Seeder
    {
        private AppDB _context;
        public Seeder(AppDB context)
        {
            _context = context;
        }

        public void SeedData()
        {
            if(_context.Products.Count() != 0)
            {
                return;
            }

            Category categoryOne = new Category { Name = "Fruit" };
            _context.Categories.Add(categoryOne);
            Category categoryTwo = new Category { Name = "Protein" };
            _context.Categories.Add(categoryTwo);
            Category categoryThree = new Category { Name = "Vegetable" };
            _context.Categories.Add(categoryThree);
            _context.SaveChanges();

            Product productOne = new Product { CategoryId = 1, Name = "Banana", ExpireDays = 6 };
            _context.Products.Add(productOne);
            Product productTwo = new Product { CategoryId = 2, Name = "Beef", ExpireDays = 4 };
            _context.Products.Add(productTwo);
            Product productThree = new Product { CategoryId = 3, Name = "Potato", ExpireDays = 100 };
            _context.Products.Add(productThree);
            _context.SaveChanges();




        }

    }
}

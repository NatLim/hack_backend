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

            Product productOne = new Product { CategoryId = 1, Name = "Banana", ExpireDays = 6, NutritionDetails = "Great source of Potassium and Vitamin B6" };
            _context.Products.Add(productOne);
            Product productTwo = new Product { CategoryId = 1, Name = "Avocado", ExpireDays = 6, NutritionDetails = "Great source of Vitamin B5,B6 and K" };
            _context.Products.Add(productTwo);
            Product productThree = new Product { CategoryId = 1, Name = "Tomato", ExpireDays = 6, NutritionDetails = "Great source of Vitamin A and C" };
            _context.Products.Add(productThree);
            Product productFour = new Product { CategoryId = 1, Name = "Apple", ExpireDays = 49, NutritionDetails = "Good source of fibre and Vitamin C" };
            _context.Products.Add(productFour);
            Product productFive = new Product { CategoryId = 1, Name = "Grape", ExpireDays = 10, NutritionDetails = "Good source of Vitamin K" };
            _context.Products.Add(productFive);
            Product productSix = new Product { CategoryId = 1, Name = "Orange", ExpireDays = 25, NutritionDetails = "Get all your daily Vitamin C from just 1 serving!" };
            _context.Products.Add(productSix);
            Product productSeven = new Product { CategoryId = 1, Name = "Lemon", ExpireDays = 17, NutritionDetails = "Great source of Vitamin C" };
            _context.Products.Add(productSeven);
            Product productEight = new Product { CategoryId = 1, Name = "Lime", ExpireDays = 14, NutritionDetails = "Great source of Vitamin C" };
            _context.Products.Add(productEight);
            Product productNine = new Product { CategoryId = 1, Name = "Strawberry", ExpireDays = 5, NutritionDetails = "Great source of Vitamin C" };
            _context.Products.Add(productNine);
            Product productTen = new Product { CategoryId = 1, Name = "Melon", ExpireDays = 8, NutritionDetails = "Good source of Vitamin C" };
            _context.Products.Add(productTen);
            Product productEleven = new Product { CategoryId = 2, Name = "Beef", ExpireDays = 4, NutritionDetails = "28g of Protein, 160-220 Cal, good source of Potassium" };
            _context.Products.Add(productEleven);
            Product productTwelve = new Product { CategoryId = 2, Name = "Pork", ExpireDays = 4, NutritionDetails = "18-22g of Protein, ~200 Cal, good source of Iron " };
            _context.Products.Add(productTwelve);
            Product productThirteen = new Product { CategoryId = 2, Name = "Chicken", ExpireDays = 2, NutritionDetails = "20g of Protein, 120-180 Cal" };
            _context.Products.Add(productThirteen);
            Product productFourteen = new Product { CategoryId = 2, Name = "Salmon", ExpireDays = 2, NutritionDetails = "~16g of Protein, ~110 Cal, good source of Vitamin B6" };
            _context.Products.Add(productFourteen);
            Product productFifteen = new Product { CategoryId = 2, Name = "Tofu", ExpireDays = 4, NutritionDetails = "20g of Protein, good source of Iron" };
            _context.Products.Add(productFifteen);
            Product productSixteen = new Product { CategoryId = 3, Name = "Potato", ExpireDays = 100, NutritionDetails = "Good source of potassium, Vitamin C and B6" };
            _context.Products.Add(productSixteen);
            Product productSeventeen = new Product { CategoryId = 3, Name = "Spinach", ExpireDays = 5, NutritionDetails = "Great source of Vitamin A and Potassium" };
            _context.Products.Add(productSeventeen);
            Product productEightteen = new Product { CategoryId = 3, Name = "Lettuce", ExpireDays = 8, NutritionDetails = "Great source of Vitamin A and C" };
            _context.Products.Add(productEightteen);
            Product productNineteen = new Product { CategoryId = 3, Name = "Celery", ExpireDays = 14, NutritionDetails = "Great source of Vitamin K" };
            _context.Products.Add(productNineteen);
            Product productTwenty = new Product { CategoryId = 3, Name = "Bell Peppers", ExpireDays = 14, NutritionDetails = "Get all your daily Vitamin C from just 1 serving!" };
            _context.Products.Add(productTwenty);
            Product productTwentyOne = new Product { CategoryId = 3, Name = "Cauliflower", ExpireDays = 14, NutritionDetails = "Great source of Vitamin C" };
            _context.Products.Add(productTwentyOne);
            Product productTwentyTwo = new Product { CategoryId = 3, Name = "Broccoli", ExpireDays = 4, NutritionDetails = "Get all your daily Vitamin C from just 1 serving!" };
            _context.Products.Add(productTwentyTwo);
            Product productTwentyThree = new Product { CategoryId = 3, Name = "Ginger", ExpireDays = 28, NutritionDetails = "Good source of Potassium and Magnesium" };
            _context.Products.Add(productTwentyThree);
            Product productTwentyFour = new Product { CategoryId = 3, Name = "Onions", ExpireDays = 14, NutritionDetails = "Good source of Vitamin C" };
            _context.Products.Add(productTwentyFour);
            Product productTwentyFive = new Product { CategoryId = 3, Name = "Eggplants", ExpireDays = 18, NutritionDetails = "Good source of Fibre" };
            _context.Products.Add(productTwentyFive);
            Product productTwentySix = new Product { CategoryId = 3, Name = "Squash", ExpireDays = 18, NutritionDetails = "Good source of Vitamin C and B6" };
            _context.Products.Add(productTwentySix);
            Product productTwentySeven = new Product { CategoryId = 3, Name = "Garlic", ExpireDays = 18, NutritionDetails = "Good source of Magnesium, Vitamin C and B6" };
            _context.Products.Add(productTwentySeven);
            Product productTwentyEight = new Product { CategoryId = 3, Name = "Mushroom", ExpireDays = 18, NutritionDetails = "Good source of Manganese and Phosphorus" };
            _context.Products.Add(productTwentyEight);
            Product productTwentyNine = new Product { CategoryId = 3, Name = "Cabbage", ExpireDays = 18, NutritionDetails = "Good source of Vitamin C and Fibre" };
            _context.Products.Add(productTwentyNine);
            Product productThirty = new Product { CategoryId = 3, Name = "Peas", ExpireDays = 18, NutritionDetails = "Good source of Vitamin C and Fibre" };
            _context.Products.Add(productThirty);
            Product productThirtyOne = new Product { CategoryId = 3, Name = "Carrot", ExpireDays = 18, NutritionDetails = "Great source of Vitamin A" };
            _context.Products.Add(productThirtyOne);

            _context.SaveChanges();


            FridgeProduct fridgeProductOne = new FridgeProduct { ProductId = 1, quantity = 10, CreateDate = DateTime.Now.AddDays(-10) ,Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductOne);
            FridgeProduct fridgeProductTwo = new FridgeProduct { ProductId = 11, quantity = 5, CreateDate = DateTime.Now.AddDays(-10) , Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductTwo);
            FridgeProduct fridgeProductThree = new FridgeProduct { ProductId = 29, quantity = 20, CreateDate = DateTime.Now, Status = "Consumed" };
            _context.fridgeProducts.Add(fridgeProductThree);
            FridgeProduct fridgeProductFour = new FridgeProduct { ProductId = 13, quantity = 20, CreateDate = DateTime.Now.AddDays(-7) , Status = "Wasted" };
            _context.fridgeProducts.Add(fridgeProductFour);
            FridgeProduct fridgeProductFive = new FridgeProduct { ProductId = 5, quantity = 20, CreateDate = DateTime.Now, Status = "Consumed" };
            _context.fridgeProducts.Add(fridgeProductFive);
            FridgeProduct fridgeProductSix = new FridgeProduct { ProductId = 20, quantity = 20, CreateDate = DateTime.Now, Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductSix);
            FridgeProduct fridgeProductSeven = new FridgeProduct { ProductId = 21, quantity = 20, CreateDate = DateTime.Now, Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductSeven);
            FridgeProduct fridgeProductEight = new FridgeProduct { ProductId = 22, quantity = 20, CreateDate = DateTime.Now, Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductEight);
            FridgeProduct fridgeProductNine = new FridgeProduct { ProductId = 23, quantity = 20, CreateDate = DateTime.Now, Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductNine);
            FridgeProduct fridgeProductTen = new FridgeProduct { ProductId = 24, quantity = 20, CreateDate = DateTime.Now, Status = "InFridge" };
            _context.fridgeProducts.Add(fridgeProductTen);
            _context.SaveChanges();

        }

    }
}

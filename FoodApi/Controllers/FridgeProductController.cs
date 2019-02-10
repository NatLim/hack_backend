using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.dbhelper;
using FoodApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FoodApi.Controllers
{
    [Produces("application/json")]
    [Route("api/FridgeProduct")]
    public class FridgeProductController : Controller
    {

        private readonly AppDB _context;

        public FridgeProductController(AppDB context)
        {
            _context = context;
        }

        // GET: api/FridgeProduct
        //[HttpGet]
        //public IEnumerable<FPVM> Get()
        //{
        //    return _context.fridgeProducts.Where(fp=> fp.Status == "InFridge").Select(fp=> new FPVM {

        //        Id = fp.Id,
        //        ProductId = fp.ProductId,
        //        quantity = fp.quantity,
        //        CreateDate = fp.CreateDate,
        //        NutritionDetails = fp.Product.NutritionDetails



        //    }).ToList();
        //}

        // GET: api/FridgeProduct/5
        [HttpGet("{id}")]
        public FridgeProduct Get(int id)
        {
            return _context.fridgeProducts.Where(i => i.Id == id).FirstOrDefault();
        }

        [HttpGet("expired")]
        public IEnumerable<FridgeProduct> GetExpired()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays) < DateTime.Now && i.Status == "InFridge" && i.quantity > 0 );
        }

        [HttpGet("expiring")]
        public IEnumerable<FridgeProduct> GetExpiring()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays-2) < DateTime.Now && DateTime.Now < i.CreateDate.AddDays(i.Product.ExpireDays ) && i.Status == "InFridge" && i.quantity > 0);
        }

        [HttpGet("fresh")]
        public IEnumerable<FridgeProduct> GetFresh()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays-2) > DateTime.Now && i.Status == "InFridge" && i.quantity > 0 );
        }

        [HttpGet("category/{id}")]
        public IEnumerable<FridgeProduct> GetFridgeProductsByCategoryId(int id)
        {
            return _context.fridgeProducts.Where(fp => fp.Product.CategoryId == id && fp.Status == "InFridge" && fp.quantity > 0 ).ToList();
        }

        [HttpGet("wasted")]
        public IEnumerable<FridgeProductDetailVM> GetWasted()
        {
            return _context.fridgeProducts.Where(fp=> fp.Status == "Wasted" && fp.quantity > 0).Select(fp => new FridgeProductDetailVM{ 
                Id = fp.Id,
                ProductId = fp.ProductId,
                quantity = fp.quantity,
                CreateDate = fp.CreateDate,
                NutritionDetails = fp.Product.NutritionDetails,
                ProductName = fp.Product.Name,
                CategoryName = fp.Product.Category.Name

            }).ToList();
        }

        [HttpGet("consumed")]
        public IEnumerable<FridgeProductDetailVM> GetConsumed()
        {
            return _context.fridgeProducts.Where(fp => fp.Status == "Consumed" && fp.quantity > 0).Select(fp => new FridgeProductDetailVM
            {
                Id = fp.Id,
                ProductId = fp.ProductId,
                quantity = fp.quantity,
                CreateDate = fp.CreateDate,
                NutritionDetails = fp.Product.NutritionDetails,
                ProductName = fp.Product.Name,
                CategoryName = fp.Product.Category.Name

            }).ToList();
        }

        [HttpGet("infridge")]
        public IEnumerable<FridgeProductDetailVM> GetInfridge()
        {
            return _context.fridgeProducts.Where(fp => fp.Status == "InFridge" && fp.quantity > 0).Select(fp => new FridgeProductDetailVM
            {
                Id = fp.Id,
                ProductId = fp.ProductId,
                quantity = fp.quantity,
                CreateDate = fp.CreateDate,
                NutritionDetails = fp.Product.NutritionDetails,
                ProductName = fp.Product.Name,
                CategoryName = fp.Product.Category.Name

            }).ToList();
        }

        [HttpGet("getStats")]
        public List<StatVM> GetStats()
        {
            //StatVM statVM = new StatVM();
            decimal allQuan = _context.fridgeProducts.Sum(i => i.quantity);
            List<StatVM> statVMs = new List<StatVM>();
            statVMs.Add(new StatVM { type = "wasted", value = _context.fridgeProducts.Where(i => i.Status == "Wasted").Sum(i => i.quantity) * 100 / allQuan });
            statVMs.Add(new StatVM { type = "consumed", value = _context.fridgeProducts.Where(i => i.Status == "Consumed").Sum(i => i.quantity) * 100 / allQuan });

            //statVM.wasted = _context.fridgeProducts.Where(i => i.Status == "Wasted").Sum(i => i.quantity) / allQuan;
            //statVM.consumed = _context.fridgeProducts.Where(i => i.Status == "Consumed").Sum(i => i.quantity) / allQuan;
            //statVM.infridge = _context.fridgeProducts.Where(i => i.Status == "InFridge").Sum(i => i.quantity) / allQuan;

            return statVMs;

        }

        [HttpGet("getFridgeStats")]
        public List<StatVM> GetCat()
        {
            CatVM catVM = new CatVM();
            decimal allQuan = _context.fridgeProducts.Sum(i => i.quantity);
            catVM.Fruit = _context.fridgeProducts.Where(i => i.Product.CategoryId == 1).Sum(i => i.quantity) / allQuan;
            catVM.Protein = _context.fridgeProducts.Where(i => i.Product.CategoryId == 2).Sum(i => i.quantity) / allQuan;
            catVM.Vegetable = _context.fridgeProducts.Where(i => i.Product.CategoryId == 3).Sum(i => i.quantity) / allQuan;
            List<StatVM> statVMs = new List<StatVM>();
            statVMs.Add(new StatVM { type = "fruit", value = _context.fridgeProducts.Where(i => i.Product.CategoryId == 1).Sum(i => i.quantity) * 100 / allQuan });
            statVMs.Add(new StatVM { type = "protein", value = _context.fridgeProducts.Where(i => i.Product.CategoryId == 2).Sum(i => i.quantity) * 100 / allQuan });
            statVMs.Add(new StatVM { type = "vegetable", value = _context.fridgeProducts.Where(i => i.Product.CategoryId == 3).Sum(i => i.quantity) * 100 / allQuan });


            return statVMs;
        }



        // POST: api/FridgeProduct
        [HttpPost]
        public IActionResult Post([FromBody]FridgeProductVM FridgeProduct)
        {

            FridgeProduct fridgeProduct = new FridgeProduct
            {
                ProductId = FridgeProduct.ProductId,
                quantity = FridgeProduct.Quantity,
                CreateDate = DateTime.Now,
                Status = "InFridge"
            };

            _context.fridgeProducts.Add(fridgeProduct);
            _context.SaveChanges();
            return Ok(fridgeProduct);

        }
        
        // PUT: api/FridgeProduct/5
        [HttpPost("edit/{id}")]
        public IActionResult Put(int id, [FromBody]FPEditVM fridgeProductVM)
        {
            FridgeProduct fridgeProduct = _context.fridgeProducts.Where(fp => fp.Id == id).FirstOrDefault();

            if(fridgeProductVM.Action == "wasted")
            {
                fridgeProduct.Status = "Wasted";
            }
            if(fridgeProductVM.Action == "consumed")
            {
                fridgeProduct.Status = "Consumed";
            }
            if(fridgeProductVM.Action == "infridge")
            {
                
                FridgeProduct newFridgeProduct = new FridgeProduct
                {
                    ProductId = fridgeProduct.ProductId,
                    CreateDate = DateTime.Now,
                    quantity = fridgeProduct.quantity - fridgeProductVM.Quantity,
                    Status = "Consumed"

                };

                _context.fridgeProducts.Add(newFridgeProduct);
                fridgeProduct.quantity = fridgeProductVM.Quantity;
            }

            _context.SaveChanges();
            return Ok(fridgeProduct);

        }

        // DELETE: api/ApiWithActions/5
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            FridgeProduct fridgeProduct = _context.fridgeProducts.Where(fp => fp.Id == id).FirstOrDefault();
            _context.fridgeProducts.Remove(fridgeProduct);
            _context.SaveChanges();
            return StatusCode(200, Json("success"));
        }
    }
}

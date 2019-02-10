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
        [HttpGet]
        public IEnumerable<FridgeProduct> Get()
        {
            return _context.fridgeProducts.ToList();
        }

        // GET: api/FridgeProduct/5
        [HttpGet("{id}")]
        public FridgeProduct Get(int id)
        {
            return _context.fridgeProducts.Where(i => i.Id == id).FirstOrDefault();
        }

        [HttpGet("expired")]
        public IEnumerable<FridgeProduct> GetExpired()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays) < DateTime.Now);
        }

        [HttpGet("expiring")]
        public IEnumerable<FridgeProduct> GetExpiring()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays-2) < DateTime.Now && DateTime.Now < i.CreateDate.AddDays(i.Product.ExpireDays ));
        }

        [HttpGet("fresh")]
        public IEnumerable<FridgeProduct> GetFresh()
        {
            return _context.fridgeProducts.Where(i => i.CreateDate.AddDays(i.Product.ExpireDays-2) > DateTime.Now);
        }




        // POST: api/FridgeProduct
        [HttpPost]
        public IActionResult Post([FromBody]FridgeProductVM FridgeProduct)
        {

            FridgeProduct fridgeProduct = new FridgeProduct
            {
                ProductId = FridgeProduct.ProductId,
                quantity = FridgeProduct.Quantity,
                IsActive = true,
                CreateDate = DateTime.Now,
            };

            _context.fridgeProducts.Add(fridgeProduct);
            _context.SaveChanges();
            return Ok(fridgeProduct);

        }
        
        // PUT: api/FridgeProduct/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            FridgeProduct fridgeProduct = _context.fridgeProducts.Where(fp => fp.Id == id).FirstOrDefault();
            _context.fridgeProducts.Remove(fridgeProduct);
            _context.SaveChanges();
            return StatusCode(200, Json("success"));
        }
    }
}

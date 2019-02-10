using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodApi.dbhelper;
using FoodApi.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Product")]
    public class ProductController : Controller
    {

        private readonly AppDB _context;

        public ProductController(AppDB context)
        {
            _context = context;
        }

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _context.Products.Where(i=> i.Id == id).FirstOrDefault();
        }
        
        // POST: api/Product
        [HttpPost]
        public IActionResult Post([FromBody]ProductVM productVM)
        {
            Product product = new Product
            {
                CategoryId = productVM.CategoryId,
                Name = productVM.Name,
                ExpireDays = productVM.ExpireDays
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok(product);
        }
        
        // PUT: api/Product/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {

        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

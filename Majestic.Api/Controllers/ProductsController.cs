using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Majestic.Domain.Repositories.Interfaces;
using Majestic.Models.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Majestic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }



        [HttpGet]
        public List<Product> GetProduct()
        {
            return _productRepository.GetProducts();
        }

        //---------------------------------------------------------------
        //[HttpGet]
        //public async Task<IActionResult> GetProductList()
        //{
        //    var res = await _prod.GetProducts();
        //    if (res != null)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
        //-------------------------------------------------------------

        [HttpGet("{id}")]

        public Product GetProduct(int id)
        {
            var product = _productRepository.GetProduct(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        //    -------------------------------------------------------------
        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetProduct(int id) {
        //    var res = await _prod.GetProduct(id);
        //    if (res != null)
        //    {
        //        return Ok(res);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }

        //}
        //-------------------------------------------------------------

        //            -------------------------------------------------------------
        [HttpPost]
        public ActionResult AddProduct([FromBody]Product item)
        {


            var res = _productRepository.AddProduct(item);



            if (res != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //        -------------------------------------------------------------
        [HttpPut("{id}")]

        public ActionResult Update([FromRoute]int id, [FromBody] Product item)
        {
           

            _productRepository.UpdateProduct(item);

            return NoContent();
        }

        [HttpDelete("{id}")]

        public ActionResult Delete(int id)
        {
            var product = _productRepository.DeleteProduct(id);

            if (product)
            {
                return NoContent();
            }

            return NotFound();


        }
    }
}
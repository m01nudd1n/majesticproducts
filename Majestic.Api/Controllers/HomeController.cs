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
    public class HomeController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ICartRepository _cartRepository;
        public HomeController(IProductRepository productRepository, ICartRepository cartRepository)
        {
            _productRepository = productRepository;
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public List<Product> GetProduct()
        {
            return _productRepository.GetProducts();
        }

        [HttpPost]
        public ActionResult AddToCart([FromBody]Cart item)
        {


            var res = _cartRepository.AddProductToCart(item);



            if (res != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest(new { message = "Something went Wrong" });
            }
        }

    }
}
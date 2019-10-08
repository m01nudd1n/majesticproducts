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
    public class CartController : ControllerBase
    {
        
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpGet]
        public List<Cart> GetItems()
        {
            return _cartRepository.GetCartItems();
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

        [HttpDelete("{id}")]

        public ActionResult Delete( int id)
        {
            var cart = _cartRepository.DeleteProduct(id);

            if (cart)
            {
                return NoContent();
            }

            return NotFound();


        }
    }

}
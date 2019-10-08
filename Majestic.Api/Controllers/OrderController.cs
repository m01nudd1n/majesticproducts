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
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet("{id}")]
        public List<Order> GetOrders(string id) {
            var orders = _orderRepository.GetOrder(id);

            if (orders == null)
            {
                return null;
            }

            return orders;
        }

        [HttpPost]
        public ActionResult PlaceOrder([FromBody]Order order)
        {


            var res = _orderRepository.PlaceOrder(order);



            if (res != null)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

       



        }
    }
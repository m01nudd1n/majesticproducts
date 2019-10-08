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
    public class OrderDetailsController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderDetailsController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }


        //[HttpPost]
        //public ActionResult AddOrderDetails([FromBody]IList<OrderDetail> orderDetail)
        //{


        //    var res = _orderRepository.AddOrderDetails(orderDetail);



        //    if (res != null)
        //    {
        //        return Ok();
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
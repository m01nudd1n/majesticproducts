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

    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _addressRepository;

        public AddressController(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }


        [HttpGet("{id}")]
        public Address GetAddress(string id)
        {
            return _addressRepository.GetAddress(id);
        }

        [HttpPost]
        public ActionResult AddAddress([FromBody]Address address)
        {


            var res = _addressRepository.AddAddress(address);



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
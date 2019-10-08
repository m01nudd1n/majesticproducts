using Majestic.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.Repositories.Interfaces
{
   public interface IAddressRepository
    {
      Address GetAddress(string id);
        Address AddAddress(Address address);
    }
}

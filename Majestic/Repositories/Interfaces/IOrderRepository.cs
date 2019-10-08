using Majestic.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.Repositories.Interfaces
{
   public interface IOrderRepository
    {
        Order PlaceOrder(Order order);
        List<Order> GetOrder(string id);
     
      

        
    }
}

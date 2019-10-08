using Majestic.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.Repositories.Interfaces
{
   public interface IProductRepository
    {
        Product AddProduct(Product product);
        bool UpdateProduct(Product product);
        Product GetProduct(int id);
        List<Product> GetProducts();
        bool DeleteProduct(int id);
    }
}

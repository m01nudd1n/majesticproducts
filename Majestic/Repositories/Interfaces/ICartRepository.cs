using Majestic.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Majestic.Domain.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Cart AddProductToCart(Cart cart);

        List<Cart> GetCartItems();
         bool DeleteProduct(int id);
    }
}

using Majestic.Domain.MajesticContext;
using Majestic.Domain.Repositories.Interfaces;
using Majestic.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Majestic.Domain.Repositories
{
   public class CartRepository : ICartRepository
    {
        MajesticDbContext _db = new MajesticDbContext();
        public List<Cart> GetCartItems()
        {
            return _db.Carts.ToList();
        }
        public Cart AddProductToCart(Cart cart)
        {
            cart.DateofOrder = DateTime.Now;
            var isExists = IsProductExists(cart.ProductName);

            Details orderDetail = new Details();

            if (isExists)
            {
                Cart ct = new Cart();
               


                var prodId = _db.Carts.Where(cName => cName.ProductName == cart.ProductName).FirstOrDefault();

              



                var cartId = _db.Carts.Where(cName => cName.ProductName == cart.ProductName).Select(cName => cName.ProductId).Single();

                prodId.Quantity = prodId.Quantity + cart.Quantity;
                prodId.Price = cart.Price;


                var detailProdId = _db.Details.Where(cName => cName.ProductName == cart.ProductName).FirstOrDefault();

                detailProdId.Quantity = detailProdId.Quantity + cart.Quantity;

                detailProdId.Price = cart.Price;

                
                _db.SaveChanges();
                return ct;
            }

            else {

                //if (cart.Quantity == 0)
                //{
                //    cart.Quantity++;
                //}
                _db.Carts.Add(cart);
                _db.SaveChanges();

                orderDetail.Price = cart.Price;
                orderDetail.ProductId = cart.ProductId;
                orderDetail.ProductImage = cart.ProductImage;
                orderDetail.ProductName = cart.ProductName;
                orderDetail.Quantity = cart.Quantity;
                orderDetail.CustomerId = cart.CustomerId;
                orderDetail.DateofOrder = cart.DateofOrder;
                orderDetail.Amount = cart.Amount;

                _db.Details.Add(orderDetail);
                _db.SaveChanges();

                return cart;
            }
            
        }

        public bool DeleteProduct(int id)
        {
            var cart = _db.Carts.Find(id);
            var removeByID = _db.Details.Find(id);

            if (cart == null)
            {
                return false;
            }

            _db.Carts.Remove(cart);
            _db.SaveChanges();

            //_db.Details.Remove(removeByID);
            //_db.SaveChanges();


            return true;
        }

        public bool IsProductExists(string productName)
        {
            var isExists = _db.Carts.Where(cName => cName.ProductName == productName).FirstOrDefault();

            return isExists != null;


        }
    }
}

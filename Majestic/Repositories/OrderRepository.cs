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
    public class OrderRepository : IOrderRepository
    {
        MajesticDbContext _db = new MajesticDbContext();




        public List<Order> GetOrder(string id)
        {
            var orders = _db.Orders.Where(custId => custId.CustomerId == id).ToList();
            return orders;
        }
        public Order PlaceOrder(Order order)
        {
            var orderTable = new Order();
            

            if (order != null)
            {
                orderTable.OrderDate = DateTime.Now;
                orderTable.CustomerId = order.CustomerId;
                orderTable.AddressId = order.AddressId;
                orderTable.Amount = order.Amount;


                _db.Orders.Add(orderTable);
                _db.SaveChanges();



                if (order != null)
                {

                    var getOrderId = _db.Orders.Where(cId => cId.CustomerId == order.CustomerId).Select(oId => oId.Id).LastOrDefault();
                    var detailRow = _db.Details.Where(cId => cId.CustomerId == order.CustomerId).Select(oId => oId.OrderId).ToList();

                    using (MajesticDbContext db = new MajesticDbContext())
                    {
                        db.Details.Where(x => x.CustomerId == order.CustomerId).ToList().ForEach(x =>
                        {
                            x.OrderId = getOrderId;
                        });
                        db.SaveChanges();
                    }
                    if (order != null)
                    {
                        _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Carts]");
                        _db.SaveChanges();
                    }

                    //for (int i = 0; i < _db.Details.Count(); i++)
                    //{
                    //    detailRow.Add(getOrderId);

                    //}
                    //_db.SaveChanges();
                }



            }


            return orderTable;
        }

        public int GetOrderId(string cId) {

            var orderId = _db.Orders.Where(oId => oId.CustomerId == cId).Select(oId => oId.Id).SingleOrDefault();

      
            return orderId;
        }

        public Details UpdateDetails(Details details)
        {
            var updateDetails = new Details() { CustomerId = details.CustomerId, OrderId = this.GetOrderId(details.CustomerId) };
           
            {
                _db.Details.Attach(updateDetails);
                _db.Entry(updateDetails).Property(x => x.OrderId).IsModified = true;
                _db.SaveChanges();
            }

            return details;
        }

      

        //List<OrderDetail> AddOrderDetails(List<OrderDetail> orderDetail)
        //{

        //}

        //public IList<OrderDetail> AddOrderDetails(IList<OrderDetail> order)
        // {
        //     var orderDetails = new OrderDetail();
        //     var orderRep = new OrderRepository();



        //     if (order != null)
        //     {


        //         //orderDetails.CustomerId = orderDetail.CustomerId;

        //         //orderDetails.OrderDate = orderDetail.OrderDate;
        //         //orderDetails.Price = orderDetail.Price;
        //         //orderDetails.Quantity = orderDetail.Quantity;
        //         //orderDetails.ProductName = orderDetail.ProductName;
        //         //orderDetails.ProductId = orderDetail.ProductId;
        //         //var order = new OrderDetail {

        //         //}

        //         _db.OrderDetails.AddRange(order);
        //         _db.SaveChanges();

        //         if (order != null)
        //         {
        //             _db.Database.ExecuteSqlCommand("TRUNCATE TABLE [Carts]");
        //             _db.SaveChanges();
        //         }


        //     }



        //     return order;
        // }
    }
}

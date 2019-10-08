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
   public class ProductRepository : IProductRepository
    {
        MajesticDbContext _db = new MajesticDbContext();

        public List<Product> GetProducts()
        {
            return _db.Products.ToList();
        }

        public Product GetProduct(int id)
        {
            var findById = _db.Products.Find(id);
            if (findById == null)
            {
                return null;
            }
            return findById;
        }

        public Product AddProduct(Product item)
        {
            var category = new Category();

            var isExists = IsCategoryExists(item.CategoryName.ToUpper());

            var catName = item.CategoryName.ToUpper();
            if (isExists)
            {
                var catId = _db.Categories.Where(cName => cName.CategoryName == catName).Select(cName => cName.CategoryId).Single();

                item.CategoryId = catId;

                _db.Products.Add(item);
                _db.SaveChanges();
                return item;
            }

            else
            {


                category.CategoryName = item.CategoryName.ToUpper();


                _db.Categories.Add(category);
                _db.SaveChanges();

                var catId = _db.Categories.Where(cName => cName.CategoryName == catName).Select(cName => cName.CategoryId).Single();

                item.CategoryId = catId;
                _db.Products.Add(item);
                _db.SaveChanges();




                return item;


            }
        }

        public bool DeleteProduct(int id)
        {
            var product = _db.Products.Find(id);

            if (product == null)
            {
                return false;
            }

            _db.Products.Remove(product);
            _db.SaveChanges();

            return true;
        }

        public bool UpdateProduct(Product product)
        {

          
            _db.Entry(product).State = EntityState.Modified;
            _db.SaveChanges();
            return product != null ;
        }




        //public async Task<ICollection<Product>> GetProducts()
        //{
        //    try
        //    {
        //        return await _db.Products.ToListAsync();
        //    }
        //    catch 
        //    {
        //        return null;
        //    }
        //}

        //public async Task<Product> GetProduct(int id) {
        //    try
        //    {
        //        return await _db.Products.FindAsync(id);
        //    }
        //    catch 
        //    {

        //        return null;
        //    }
        //}

        //public Product AddProduct(Product item) {
        //    try
        //    {
        //        var category = new Category();

        //        var isExists = IsCategoryExists(item.CategoryName.ToLower());
        //        item.CategoryId = _db.Categories.Where(cName => cName.CategoryName == item.CategoryName).Select(cName => cName.CategoryId).FirstOrDefault();



        //        if (isExists)
        //        {
        //             _db.Products.Add(item);
        //             _db.SaveChanges();
        //            return item;
        //        }

        //        else {


        //            category.CategoryName = item.CategoryName.ToUpper();
        //            category.CategoryId = _db.Categories.Where(cName => cName.CategoryName == item.CategoryName).Select(cName => cName.CategoryId).FirstOrDefault();


        //            _db.Categories.Add(category);
        //            _db.SaveChanges();

        //       _db.Products.Add(item);
        //           _db.SaveChanges();

        //            return item;

        //        }


        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}

        public bool IsCategoryExists(string categoryName)
        {
            var isExists = _db.Categories.Where(cName => cName.CategoryName == categoryName).FirstOrDefault();

            return isExists != null;


        }




    }
}

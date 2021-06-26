using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        public List<Product> Get()
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            List<Product> products = db.Products.ToList();
            foreach (Product item in products)
            {
                item.ProductCategory = null;
            }
            return products;
        }
        [HttpGet]
        public Product Get(int Id)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            Product product = db.Products.SingleOrDefault(x=>x.Id==Id);
            if (product!=null)
            {
                product.ProductCategory = null;
            }
            return product;
        }
        [HttpGet]
        public List<Product> GetByProductCateogryId(int ProductCategoryId)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            List<Product> products = db.Products.Where(x => x.ProductCategoryId == ProductCategoryId).ToList();
            foreach (Product item in products)
            {
                item.ProductCategory = null;
            }
            return products;
        }
        [HttpGet]
        public List<Product> GetFromTo(int from, int to)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            List<Product> products = db.Products.Where(x => x.Price.Value <= to && x.Price.Value >= from).ToList();
            foreach (Product item in products)
            {
                item.ProductCategory = null;
            }
            return products;
        }
        [HttpPost]
        public bool Add(string name, decimal price, int productCategoryId)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            try
            {
                Product product = new Product();
                product.Name = name;
                product.Price = price;
                product.ProductCategoryId = productCategoryId;

                db.Products.Add(product);
                db.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpPut]
        public bool Edit(int Id, string name, decimal price, int productCategoryId)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            try
            {
                Product product = db.Products.Find(Id);
                if (product!=null)
                {
                    product.Name = name;
                    product.Price = price;
                    product.ProductCategoryId = productCategoryId;

                    db.Products.Add(product);
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [HttpDelete]
        public bool Delete(int Id)
        {
            REST_API_DemoEntities db = new REST_API_DemoEntities();
            try
            {
                Product product = db.Products.Find(Id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();

                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}

using Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Demo.Controllers
{
    public class ProductCategoryController : ApiController
    {
        REST_API_DemoEntities db = new REST_API_DemoEntities();
        [HttpGet]
        public List<ProductCategory> Get()
        {
            List<ProductCategory> productCategories = db.ProductCategories.ToList();
            return productCategories;
        }
        [HttpGet]
        public ProductCategory Get(int Id)
        {
            ProductCategory productCategory = db.ProductCategories.SingleOrDefault(x => x.Id == Id);
            return productCategory;
        }
    }
}

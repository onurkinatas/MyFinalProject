using Core.DataAccess.EntityFramework;
using DataAccess.Abstrack;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from product in context.Products
                             join category in context.Categories
                             on product.CategoryId equals category.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductId = product.ProductId,
                                 ProductName = product.ProductName,
                                 CategoryName = category.CategoryName, 
                                 UnitsInStock = product.UnitsInStock,
                             };
                return result.ToList();
            }
        }
    }
}

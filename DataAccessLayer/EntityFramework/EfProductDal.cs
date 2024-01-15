using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public List<Product> GetFilteredProducts(int? categoryId, string? priceOrder, int? minRating)
        {
            using var context = new ApplicationDbContext();
            var bestselledProducts = new List<Product>();
            IQueryable<Comment> query = context.Comments
       .Include(comment => comment.Product) 
           .ThenInclude(product => product.ProductCategory);
         



            if (categoryId != null)
            {
              
                if (categoryId == 0  )
                {
                    IQueryable<Product> productquery = context.Products
                            .Include(product => product.Comment);


                    Console.WriteLine("size:" + productquery.ToList().Count);

                    var productList= new List<Product>();
                    var querylist = productquery.SelectMany(x => x.Comment).GroupBy(p => p.ProductId).Select(g => new
                    {
                        ProductId = g.Key,
                       Price = context.Products.FirstOrDefault(pr => pr.Id == g.Key).ProductPrice,

                        AveragePoint = (decimal)g.Average(p => p.Point),
                    }).Where(pr => pr.AveragePoint >= minRating);
        


                    if (priceOrder == "desc")
                    {
                        querylist = querylist.OrderByDescending(pr =>pr.AveragePoint)
                             .ThenByDescending(pr => pr.Price);
               


                    }
                    else
                    {
                        querylist = querylist.OrderByDescending(pr => pr.AveragePoint)
                            .ThenBy(pr => pr.Price);

                    }
                    foreach (var elem in querylist)
                    {

                        using (var newContext = new ApplicationDbContext())
                        {
                            var product = newContext.Products.FirstOrDefault(o => o.Id == elem.ProductId);
                            if (product != null)
                            {
                                productList.Add(product);
                            }
                        }
                    }

                    


                    return productList;


                   
                }
                else if(categoryId!= 0 )
                {
                    query = query.Where(p => p.Product.ProductCategory.Any(c=>c.CategoryId==categoryId));

                }

                Console.WriteLine("countt:"+ query.ToList().Count);

            }




            if (priceOrder != null )
            {
                if (priceOrder == "desc")
                {
                    
                    query = query.OrderByDescending(p => p.Product.ProductPrice);


                }
                else
                {
                    query = query.OrderBy(p => p.Product.ProductPrice);

                }
                
            }
            if (minRating != null )
            {
                var list = query.GroupBy(p => p.ProductId).Select(g => new
                {
                    ProductId = g.Key,

                    AveragePoint = (decimal)g.Average(p => p.Point),
                    Price = context.Products.FirstOrDefault(pr => pr.Id == g.Key).ProductPrice


                })
                 .Where(pr => pr.AveragePoint >= minRating);
                if (priceOrder != null)
                {
                    if (priceOrder == "desc")
                    {

                    list=list
                  .OrderByDescending(pr => pr.AveragePoint )
                  .ThenByDescending(c => c.Price);
               

                    }
                    else
                    {

                    list=list
               .OrderByDescending(pr => pr.AveragePoint)
               .ThenBy(pr => pr.Price);
             
                    }

                }
                else
                {
                  list=  list
             .OrderByDescending(pr => pr.AveragePoint);
      
                                }




                foreach (var elem in list)
                {
                    using (var newContext = new ApplicationDbContext())
                    {
                        var product = newContext.Products.FirstOrDefault(o => o.Id == elem.ProductId);
                        Console.WriteLine(elem.Price);
                        if (product != null)
                        {
                            bestselledProducts.Add(product);
                        }
                    }
                }

       }


        
            return bestselledProducts.Any()?bestselledProducts: query.Select(p => p.Product).ToList();
        }

        public List<Product> GetMostOrderedItems(string timeCategory)
        {
            using var context = new ApplicationDbContext();
            var popularProducts = new List<Product>();
            if (timeCategory == "month")
            {
                var list = context.OrderItems.Where(o => o.CreatedAt.Year == DateTime.Now.Year
          && o.CreatedAt.Month == DateTime.Now.Month)
              .GroupBy(p => p.ProductId).

              Select(g => new {
                  ProductId = g.Key,
                  TotalQuantity = g.Sum(v => v.Quantity)


              }).
              OrderByDescending(o => o.TotalQuantity).
              Take(5)

              .ToList();

                foreach (var elem in list)
                {
                    popularProducts.Add(context.Products.FirstOrDefault(o => o.Id == elem.ProductId));
                }

                return popularProducts;


            }
            else if(timeCategory == "year")
            {
                var list = context.OrderItems.Where(o => o.CreatedAt.Year == DateTime.Now.Year
                                                                    )
      .GroupBy(p => p.ProductId).

      Select(g => new {
          ProductId = g.Key,
          TotalQuantity = g.Sum(v => v.Quantity)


      }).
      OrderByDescending(o => o.TotalQuantity).
      Take(5)

      .ToList();

                foreach (var elem in list)
                {
                    popularProducts.Add(context.Products.FirstOrDefault(o => o.Id == elem.ProductId));
                }

                return popularProducts;

            }

            else if (timeCategory == "day")
            {
                var list = context.OrderItems.Where(o => o.CreatedAt.Year == DateTime.Now.Year
  && o.CreatedAt.Month == DateTime.Now.Month && o.CreatedAt.Day ==DateTime.Now.Day)
      .GroupBy(p => p.ProductId).

      Select(g => new {
          ProductId = g.Key,
          TotalQuantity = g.Sum(v => v.Quantity)


      }).
      OrderByDescending(o => o.TotalQuantity).
      Take(5)

      .ToList();

                foreach (var elem in list)
                {
                    popularProducts.Add(context.Products.FirstOrDefault(o => o.Id == elem.ProductId));
                }

                return popularProducts;


            }

            else
            {
                return new List<Product>();
            }
           
            
         
                   }

        public float GetProductPoint(int productId)
        {
            using var context = new ApplicationDbContext();

            var cm = context.Comments.Where(p => p.ProductId == productId).ToList();

            if (cm != null && cm.Any())
            {
                float point = (float)cm.Average(p => p.Point); //cm.Sum(p => p.Point) / cm.Count();

                Console.WriteLine(point+"poinnttt");
                return point;


            }
            else
            {
                return 0.0f;
            }
            
   
               
                
        }

        List<Product> IProductDal.GetBestRankedProducts()
        {
            using var context = new ApplicationDbContext();
            var bestselledProducts = new List<Product>();

            var list = context.Comments.GroupBy(p => p.ProductId).Select(g => new {
                ProductId = g.Key,

                AveragePoint = g.Sum(p => p.Point) / g.Count(),


            }).
            OrderByDescending(pr=>pr.AveragePoint)
            .Take(5)
            .ToList();
            foreach (var elem in list)
            {
                bestselledProducts.Add(context.Products.FirstOrDefault(o => o.Id == elem.ProductId));
            }

            return bestselledProducts;
        }

        List<Product> IProductDal.GetBestRankedProductsByCategory(int categoryId)
        {
            using var context = new ApplicationDbContext();
            var bestselledProducts = new List<Product>();

            var list = context.Comments.GroupBy(p => p.ProductId).Select(g => new {
                ProductId = g.Key,

                AveragePoint = g.Sum(p => p.Point) / g.Count(),


            }).
            OrderByDescending(pr => pr.AveragePoint)
            
            .ToList();
            foreach (var elem in list)
            {
                bestselledProducts.Add(context.Products.Include(ct=>ct.ProductCategory).FirstOrDefault(o => o.Id == elem.ProductId));
            }
           var catProducts= bestselledProducts.Where(pr => pr.ProductCategory.Any(c => c.CategoryId==categoryId)).ToList();


            return catProducts;
        }
    }
}

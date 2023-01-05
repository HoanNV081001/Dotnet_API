using Dotnet_API.Data;
using Dotnet_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Dotnet_API.Services
{
    public class ProductResposity : IProductResposity
    {
        private readonly MyDbContext _context;
        public static int PAGE_SIZE { get; set; } = 3;
         public ProductResposity(MyDbContext context)
        {
            _context = context;
        }

        public List<ProductModel> GetAll(string search, double? from, double? to,string sortBy, int page = 1)
        {
            // var allProduct = _context.Products.Where(p=>p.NameProduct.Contains(search));
            var allProduct = _context.Products.Include(p=>p.Category).AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                allProduct = allProduct.Where(p=>p.NameProduct.Contains(search));
            }
            if (from.HasValue)
            {
                allProduct = allProduct.Where(p => p.Price >= from);
            }
            if (to.HasValue)
            {
                allProduct = allProduct.Where(p => p.Price <= to);
            }

            allProduct = allProduct.OrderBy(p=>p.NameProduct);

             if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "namePrduct_desc": allProduct = allProduct.OrderByDescending(p => p.NameProduct); break;
                    case "price_asc": allProduct = allProduct.OrderBy(p => p.Price); break;
                    case "price_desc": allProduct = allProduct.OrderByDescending(p => p.Price); break;
                    case "": allProduct = allProduct.AsQueryable(); break;
                }
            }



            var result = Models.PaginatedList<Data.Product>.Create(allProduct, page, PAGE_SIZE);
            return result.Select(p => new ProductModel{
                        IdProduct = p.Id,
                        NameProduct = p.NameProduct,
                        Price = p.Price,
                        NameCat = p.Category.NameCat
                    }).ToList();
        }
    }
}
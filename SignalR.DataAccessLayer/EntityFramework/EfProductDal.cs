using Microsoft.EntityFrameworkCore;
using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        private readonly SignalRContext _context;

        public EfProductDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public List<Product> GetProductsWithCategory()
        {
            return _context.Products.Include(x => x.Category).ToList();
        }

        public int ProductCount()
        {
            // HATA: Yeni context oluşturmayın, mevcut context'i kullanın
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "İçecek")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            return _context.Products.Count(x => x.CategoryID == categoryId);
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            return _context.Products.Count(x => x.CategoryID == categoryId);
        }

        public string ProductNameByMaxPrice()
        {
            var maxPrice = _context.Products.Max(y => y.Price);

            return _context.Products
                .Where(x => x.Price == maxPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault();
        }

        public string ProductNameByMinPrice()
        {
            var minPrice = _context.Products.Min(y => y.Price);

            return _context.Products
                .Where(x => x.Price == minPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault();
        }



        public decimal ProductPriceAvg()
        {
            return _context.Products.Average(x => x.Price);
        }
    }
}
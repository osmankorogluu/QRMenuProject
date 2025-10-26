using Microsoft.EntityFrameworkCore;
using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _context.Products.Count();
        }

        public int ProductCountByCategoryNameDrink()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "İçecek")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return 0;

            return _context.Products.Count(x => x.CategoryID == categoryId);
        }

        public int ProductCountByCategoryNameHamburger()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return 0;

            return _context.Products.Count(x => x.CategoryID == categoryId);
        }

        // ✅ En Pahalı Ürün İsmi
        public string ProductNameByMaxPrice()
        {
            if (!_context.Products.Any())
                return "Ürün Yok"; // Veya string.Empty, null yerine

            var maxPrice = _context.Products.Max(y => (decimal?)y.Price) ?? 0;

            return _context.Products
                .Where(x => x.Price == maxPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault() ?? "Bilinmiyor";
        }

        // ✅ En Ucuz Ürün İsmi
        public string ProductNameByMinPrice()
        {
            if (!_context.Products.Any())
                return "Ürün Yok";

            var minPrice = _context.Products.Min(y => (decimal?)y.Price) ?? 0;

            return _context.Products
                .Where(x => x.Price == minPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault() ?? "Bilinmiyor";
        }

        // ✅ Ortalama Ürün Fiyatı
        public decimal ProductPriceAvg()
        {
            if (!_context.Products.Any())
                return 0;

            return _context.Products.Average(x => (decimal?)x.Price) ?? 0;
        }

        // ✅ Hamburger Kategorisi Ortalama Fiyatı
        public decimal ProductPriceByCategoryNameAvgHamburger()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return 0;

            var products = _context.Products.Where(x => x.CategoryID == categoryId);

            if (!products.Any())
                return 0;

            return products.Average(x => (decimal?)x.Price) ?? 0;
        }

        // ✅ Hamburger - En Pahalı Ürün
        public string ProductNameByMaxPriceByCategoryNameHamburger()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return "Kategori Bulunamadı";

            var products = _context.Products.Where(x => x.CategoryID == categoryId);

            if (!products.Any())
                return "Ürün Yok";

            var maxPrice = products.Max(y => (decimal?)y.Price) ?? 0;

            return products
                .Where(x => x.Price == maxPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault() ?? "Bilinmiyor";
        }

        // ✅ Hamburger - En Ucuz Ürün
        public string ProductNameByMinPriceByCategoryNameHamburger()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "Hamburger")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return "Kategori Bulunamadı";

            var products = _context.Products.Where(x => x.CategoryID == categoryId);

            if (!products.Any())
                return "Ürün Yok";

            var minPrice = products.Min(y => (decimal?)y.Price) ?? 0;

            return products
                .Where(x => x.Price == minPrice)
                .Select(z => z.ProductName)
                .FirstOrDefault() ?? "Bilinmiyor";
        }

        // ✅ İçecek Kategorisi Ortalama Fiyatı
        public decimal ProductPriceAvgByCategoryNameDrink()
        {
            var categoryId = _context.Categories
                .Where(y => y.Name == "İçecek")
                .Select(z => z.CategoryID)
                .FirstOrDefault();

            if (categoryId == 0)
                return 0;

            var products = _context.Products.Where(x => x.CategoryID == categoryId);

            if (!products.Any())
                return 0;

            return products.Average(x => (decimal?)x.Price) ?? 0;
        }
    }
}
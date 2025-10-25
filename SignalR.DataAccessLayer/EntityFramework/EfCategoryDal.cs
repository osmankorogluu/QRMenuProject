using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using System.Linq;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        private readonly SignalRContext _context;

        public EfCategoryDal(SignalRContext context) : base(context)
        {
            _context = context; // DI'dan gelen context'i kullan
        }

        public int ActiveCategoryCount()
        {
            // Artık yeni context açmıyor, mevcut _context'i kullanıyor
            return _context.Categories.Where(c => c.Status == true).Count();
        }

        public int CategoryCount()
        {
            return _context.Categories.Count();
        }

        public int PassiveCategoryCount()
        {
            // Artık yeni context açmıyor, mevcut _context'i kullanıyor
            return _context.Categories.Where(c => c.Status == false).Count();
        }
    }
}
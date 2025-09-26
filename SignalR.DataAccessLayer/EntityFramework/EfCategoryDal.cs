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
            _context = context; // ✔️ DI'dan gelen context'i kullan
        }

        public int CategoryCount()
        {
            return _context.Categories.Count(); // ✔️ Yeni context açma, DI'dan geleni kullan
        }
    }
}

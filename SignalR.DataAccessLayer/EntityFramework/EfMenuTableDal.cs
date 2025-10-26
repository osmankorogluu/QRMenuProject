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
    public class EfMenuTableDal : GenericRepository<MenuTable>, IMenuTableDal
    {
        private readonly SignalRContext _context;

        public EfMenuTableDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        public int MenuTableCount()
        {
            return _context.MenuTables.Count(); // ✅ Injected context kullan
        }
    }
}
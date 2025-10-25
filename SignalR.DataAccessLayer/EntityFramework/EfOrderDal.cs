using Microsoft.EntityFrameworkCore;
using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;

        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context; // ✅ Bu satır EKSİKTİ!
        }

        public int ActiveOrderCount()
        {
            using var context = new SignalRContext();
            return context.Orders.Where(o => o.Desription == "Müşteri Masada").Count();
        }

        public decimal LasOrderPrice()
        {
            return _context.Orders
        .OrderByDescending(x => x.OrderID)
        .Take(1)
        .Select(y => y.TotalPrice)
        .FirstOrDefault();
        }




        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
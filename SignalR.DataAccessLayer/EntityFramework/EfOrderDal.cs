using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfOrderDal : GenericRepository<Order>, IOrderDal
    {
        private readonly SignalRContext _context;

        public EfOrderDal(SignalRContext context) : base(context)
        {
            _context = context;
        }

        // Aktif Sipariş Sayısı
        public int ActiveOrderCount()
        {
            return _context.Orders.Where(x => x.Desription == "Müşteri Masada").Count();
        }

        public decimal LasOrderPrice()
        {
            throw new NotImplementedException();
        }

        // Son Sipariş Fiyatı
        public decimal LastOrderPrice()
        {
            return _context.Orders.OrderByDescending(x => x.OrderID).Select(y => y.TotalPrice).FirstOrDefault();
        }

        // Bugünkü Toplam Kazanç
        public decimal TodayTotalPrice()
        {
            var today = DateTime.Today;

            return _context.Orders
                .Where(o => o.Date.Date == today)
                .Sum(o => (decimal?)o.TotalPrice) ?? 0;
        }

        // Toplam Sipariş Sayısı
        public int TotalOrderCount()
        {
            return _context.Orders.Count();
        }
    }
}
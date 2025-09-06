using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly DiscountManager _discountManager;

        public DiscountManager(DiscountManager discountManager)
        {
            _discountManager = discountManager;
        }

        public void TAdd(Discount entity)
        {
            _discountManager.TAdd(entity);
        }

        public void TDelete(Discount entity)
        {
            _discountManager.TDelete(entity);
        }

        public Discount TGetByID(int id)
        {
           return _discountManager.TGetByID(id);
        }

        public List<Discount> TGetListAll()
        {
            return _discountManager.TGetListAll();
        }

        public void TUpdate(Discount entity)
        {
           _discountManager.TUpdate(entity);
        }
    }
}

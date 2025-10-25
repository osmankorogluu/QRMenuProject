using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BussinessLayer.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal; // ✅ DOĞRU: Dal katmanını kullan

        public OrderManager(IOrderDal orderDal) // ✅ DOĞRU
        {
            _orderDal = orderDal;
        }

        public int TActiveOrderCount()
        {
           return _orderDal.ActiveOrderCount(); 
        }

        public void TAdd(Order entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Order entity)
        {
            _orderDal.Delete(entity);
        }

        public Order TGetByID(int id)
        {
            return _orderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return _orderDal.GetListAll();
        }

        public int TTotalOrderCount()
        {
            return _orderDal.TotalOrderCount(); // ✅ Dal'dan çağır
        }

        public void TUpdate(Order entity)
        {
            _orderDal.Update(entity);
        }
    }
}
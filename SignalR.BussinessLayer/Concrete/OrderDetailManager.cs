using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;

namespace SignalR.BussinessLayer.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _orderDetailDal; // ✅ Dal kullanın, Service değil!

        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(OrderDetail entity)
        {
            _orderDetailDal.Delete(entity);
        }

        public OrderDetail TGetByID(int id)
        {
            return _orderDetailDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _orderDetailDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            _orderDetailDal.Update(entity);
        }
    }
}
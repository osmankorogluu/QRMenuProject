using QRMenu.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IOrderDal : IGenericDal<Order>
    {
        int ActiveOrderCount();
        decimal LastOrderPrice();
        decimal TodayTotalPrice();
        int TotalOrderCount();
    }
}
using QRMenu.EntityLayer.Entities;

namespace SignalR.BussinessLayer.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        int TActiveOrderCount();
        decimal TLastOrderPrice();
        decimal TTodayTotalPrice();
        int TTotalOrderCount();
    }
}
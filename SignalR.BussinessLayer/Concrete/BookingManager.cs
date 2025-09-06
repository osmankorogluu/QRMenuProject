using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class BookingManager : IBookingService
    {
        private readonly BookingManager _bookingManager;

        public BookingManager(BookingManager bookingManager)
        {
            _bookingManager = bookingManager;
        }

        public void TAdd(Booking entity)
        {
            _bookingManager.TAdd(entity);
        }

        public void TDelete(Booking entity)
        {
            _bookingManager.TDelete(entity);    
        }

        public Booking TGetByID(int id)
        {
            return _bookingManager.TGetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _bookingManager.TGetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _bookingManager.TUpdate(entity);
        }
    }
}

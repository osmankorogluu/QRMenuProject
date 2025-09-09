using SignalR.BussinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System.Collections.Generic;

public class BookingManager : IBookingService
{
    private readonly IBookingDal _bookingDal;

    public BookingManager(IBookingDal bookingDal)
    {
        _bookingDal = bookingDal;
    }

    public void TAdd(Booking entity)
    {
        _bookingDal.Insert(entity);
    }

    public void TDelete(Booking entity)
    {
        _bookingDal.Delete(entity);
    }

    public Booking TGetByID(int id)
    {
        return _bookingDal.GetById(id);
    }

    public List<Booking> TGetListAll()
    {
        return _bookingDal.GetAll();
    }

    public void TUpdate(Booking entity)
    {
        _bookingDal.Update(entity);
    }
}
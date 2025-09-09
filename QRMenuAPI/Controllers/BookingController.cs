using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;

namespace QRMenuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService=bookingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            var result = _bookingService.TGetListAll();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var booking = new Booking
            {
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date
            };
            _bookingService.TAdd(booking);

            return Ok("Booking was successfully created.");
        }
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var result = _bookingService.TGetByID(id);

            _bookingService.TDelete(result);
            return Ok("Hakkımda Alanı Silindi.");
        }
        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var booking = new Booking
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date
            };

            _bookingService.TUpdate(booking);
            return Ok("Booking was successfully updated.");
        }

        [HttpGet("GetAbout")]
        public IActionResult GetBooking(int id)
        {
            var result = _bookingService.TGetByID(id);
            return Ok(result);
        }
    }
}


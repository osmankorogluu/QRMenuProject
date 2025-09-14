using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
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
            _bookingService = bookingService;
        }

      
        [HttpGet]
        public IActionResult GetBookings()
        {
            var result = _bookingService.TGetListAll();
            return Ok(result);
        }

       
        [HttpGet("{id:int}")]
        public IActionResult GetBooking(int id)
        {
            var result = _bookingService.TGetByID(id);
            if (result == null)
                return NotFound("Booking bulunamadı.");

            return Ok(result);
        }

       
        [HttpPost]
        public IActionResult CreateBooking([FromBody] CreateBookingDto createBookingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

           
            var booking = new Booking
            {
                Name        = createBookingDto.Name,
                Phone       = createBookingDto.Phone,
                Mail        = createBookingDto.Mail,  
                PersonCount = createBookingDto.PersonCount,
                Date        = createBookingDto.Date
            };

            _bookingService.TAdd(booking);

            return CreatedAtAction(nameof(GetBooking), new { id = booking.BookingID }, booking);
        }

     
        [HttpPut("{id:int?}")]
        public IActionResult UpdateBooking(int? id, [FromBody] UpdateBookingDto updateBookingDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var bookingId = id ?? updateBookingDto.BookingID;
            if (bookingId <= 0)
                return BadRequest("BookingID zorunludur.");

            var existing = _bookingService.TGetByID(bookingId);
            if (existing == null)
                return NotFound("Güncellenecek booking bulunamadı.");

           
            existing.Name        = updateBookingDto.Name;
            existing.Phone       = updateBookingDto.Phone;
            existing.Mail        = updateBookingDto.Mail;  
            existing.PersonCount = updateBookingDto.PersonCount;
            existing.Date        = updateBookingDto.Date;

            _bookingService.TUpdate(existing);
            return Ok("Booking başarıyla güncellendi.");
        }

        
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBooking(int id)
        {
            var existing = _bookingService.TGetByID(id);
            if (existing == null)
                return NotFound("Silinecek booking bulunamadı.");

            _bookingService.TDelete(existing);
            return Ok("Booking silindi.");
        }
    }
}

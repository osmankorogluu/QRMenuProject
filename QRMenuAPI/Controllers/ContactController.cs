using Microsoft.AspNetCore.Mvc;
using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;

namespace YourProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetContacts()
        {
            var result = _contactService.TGetListAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var result = _contactService.TGetByID(id);
            if (result == null)
                return NotFound("Contact bulunamadı.");
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var contact = new Contact
            {
                Location = createContactDto.Location,
                Phone = createContactDto.Phone,
                Mail = createContactDto.Mail,
                FooterDescription = createContactDto.FooterDescription
            };

            _contactService.TAdd(contact);
            return Ok("Contact başarıyla oluşturuldu.");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, UpdateContactDto updateContactDto)
        {
            var contact = _contactService.TGetByID(id);
            if (contact == null)
                return NotFound("Contact bulunamadı.");

            contact.Location = updateContactDto.Location;
            contact.Phone = updateContactDto.Phone;
            contact.Mail = updateContactDto.Mail;
            contact.FooterDescription = updateContactDto.FooterDescription;

            _contactService.TUpdate(contact);
            return Ok("Contact başarıyla güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var contact = _contactService.TGetByID(id);
            if (contact == null)
                return NotFound("Contact bulunamadı.");

            _contactService.TDelete(contact);
            return Ok("Contact başarıyla silindi.");
        }
    }
}

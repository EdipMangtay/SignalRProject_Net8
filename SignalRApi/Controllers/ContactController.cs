using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using SignalR.BusinnesLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactSercvice, IMapper mapper)
        {
            _contactService = contactSercvice;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var value = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(value);

        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            _contactService.TAdd(new Contact()
            {
                Location = createContactDto.Location,
                FooterDescription = createContactDto.FooterDescription,
                Mail = createContactDto.Mail,
                Phone = createContactDto.Phone

            }); 
           
            return Ok("Contact Eklendi");

            
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok("Contact silindi");

        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);

        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            _contactService.TUpdate(new Contact()
            {
                ContactID = updateContactDto.ContactID,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone.ToString(),
                Mail = updateContactDto.Mail,
                FooterDescription = updateContactDto.FooterDescription
            });
            return Ok("Contact Güncellendi");

        }
    }
}

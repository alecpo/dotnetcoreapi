using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SportsX.API.Models;

namespace SportsX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhoneController : ControllerBase
    {
        public List<Phone> Phones = new List<Phone>()
        {
            
            new Phone
            {
                Id = 1,
                Number = "11111",
                ClientId = 1
            },
            new Phone
            {
                Id = 2,
                Number = "22222",
                ClientId = 1
            },
            new Phone
            {
                Id = 3,
                Number = "33333",
                ClientId = 2
            },
            new Phone
            {
                Id = 4,
                Number = "44444",
                ClientId = 2
            },
            new Phone
            {
                Id = 5,
                Number = "55555",
                ClientId = 3
            },
        };

        public PhoneController(){ }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Phones);
        }

        [HttpGet("{number}")]
        public IActionResult GetByNumber(string number)
        {
            var phone = Phones.FirstOrDefault(phone => phone.Number.Contains(number));

            if (phone == null) return BadRequest("Phone not found.");

            return Ok(phone);
        }

        [HttpGet("{clientId:int}")]
        public IActionResult GetByClientId(int clientId)
        {
            var phone = Phones.FirstOrDefault(phone => phone.ClientId == clientId);

            if (phone == null) return BadRequest("Phone not found.");

            return Ok(phone);
        }
    }
}

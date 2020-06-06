using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportsX.API.Data;
using SportsX.API.Models;

namespace SportsX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {

        public ClientController(SportsXContext context)
        {
            Context = context;
        }

        public SportsXContext Context { get; }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Context.Clients);
        }

        [HttpPost]
        public IActionResult Post(Client client)
        {
            Context.Add(client);
            Context.SaveChanges();
            return Ok("Client successfully created");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Client updatedClient)
        {
            var client = Context.Clients.AsNoTracking().FirstOrDefault(client => client.Id == id);

            if (client == null) return BadRequest("Client not found");

            Context.Update(updatedClient);
            Context.SaveChanges();
            return Ok(client);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var client = Context.Clients.FirstOrDefault(client => client.Id == id);

            if (client == null) return BadRequest("Client not found"); 

            Context.Remove(client);
            Context.SaveChanges();
            return Ok(Context.Clients);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var client = Context.Clients.FirstOrDefault(client => client.Id == id);

            if (client == null) return BadRequest("Client not found.");

            return Ok("Client successfully removed");
        }

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            var client = Context.Clients.Where(client => client.Name.Contains(name));

            if (client == null) return BadRequest("Client not found.");

            return Ok(client);
        }
    }
}

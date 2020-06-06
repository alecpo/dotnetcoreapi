using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportsX.API.Repositories;
using SportsX.API.Models.Data;
using SportsX.API.Models.Requests;

namespace SportsX.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        public readonly IRepository Repo;

        public ClientController(IRepository repo)
        {
            Repo = repo;
        }

        [HttpGet]
        public IActionResult GetAllOrderedByName()
        {
            var result = Repo.GetAllClients();
            return Ok(result);
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByNameOrderedByName(string name)
        {
            var result = Repo.GetClientsByName(name);
            return Ok(result);
        }

        //[HttpPost("phoneList")]
        //public IActionResult PostPhoneList(Phone phone)
        //{
        //    Repo.Add(phone);
        //    if (Repo.SaveChanges())
        //    {
        //        return Ok("Phones successfully saved");
        //    }
        //    return Ok("Fail on save phones");
        //}

        [HttpPost]
        public IActionResult Post(NewClientRequest newClient)
        {
            Repo.Add(newClient.Client);

            if (Repo.SaveChanges())
            {
                int clientId = newClient.Client.Id;

                foreach (var phoneNumber in newClient.PhoneList)
                {
                    Phone tempPhone = new Phone()
                    {
                        ClientId = clientId,
                        Number = phoneNumber
                    };

                    Repo.Add(tempPhone);
                }

                if (Repo.SaveChanges())
                {
                    var createdClient = Repo.GetClientById(clientId);
                    return Ok(createdClient);
                }
                return Ok("Fail on storage client phone list");
            }
            return Ok("Fail on create new client");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Client updatedClient)
        {
            var client = Repo.GetClientById(id);

            if (client == null) return BadRequest("Client not found");

            Repo.Update(updatedClient);
            if (Repo.SaveChanges()) return Ok(client);

            return Ok("Fail on update client");
        }

        [HttpDelete("{id:int}")]
        public IActionResult Remove(int id)
        {
            var client = Repo.GetClientById(id);

            if (client == null) return BadRequest("Client not found");

            Repo.Remove(client);
            if (Repo.SaveChanges()) return Ok(client);

            return Ok("Fail on create new client");
        }
    }
}

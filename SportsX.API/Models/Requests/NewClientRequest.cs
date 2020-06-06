using System.Collections.Generic;
using SportsX.API.Models.Data;

namespace SportsX.API.Models.Requests
{
    public class NewClientRequest
    {
        public NewClientRequest(){ }

        
        public NewClientRequest(Client client, List<string> phoneList)
        {
            Client = client;
            PhoneList = phoneList;
        }

        public Client Client { get; set; }


        public List<string> PhoneList { get; set; }

    }
}

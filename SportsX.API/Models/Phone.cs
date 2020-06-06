namespace SportsX.API.Models
{
    public class Phone
    {
        public Phone(){ }

        public Phone(int id, string number, int clientId)
        {
            Id = id;
            Number = number;
            ClientId = clientId;
        }

        public int Id { get; set; }

        public string Number { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

    }
}

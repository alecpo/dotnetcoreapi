using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsX.API.Models.Data
{
    public class Client
    {
        public Client(){ }

        public Client(int id, string name, string companyName, string cep, string cnpj, string cpf, string email, string status, bool isDeleted)
        {
            Id = id;
            Name = name;
            CompanyName = companyName;
            CEP = cep;
            CNPJ = cnpj;
            CPF = cpf;
            Email = email;
            Status = status;
            IsDeleted = isDeleted;
        }

        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string CompanyName { get; set; }

        public string CEP { get; set; }

        public string CNPJ { get; set; }

        public string CPF { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Status { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<Phone> Phones { get; set; }

    }
}

using SportsX.API.Models.Data;

namespace SportsX.API.Repositories
{
    public interface IRepository
    {
        void Add<Type>(Type entity) where Type : class;
        void Update<Type>(Type entity) where Type : class;
        void Remove<Type>(Type entity) where Type : class;

        Client[] GetAllClients();

        Client[] GetClientsByName(string name);

        Client GetClientById(int id);

        Client[] GetClientsByFederalRegistrationType(string federalRegister);

        Client[] GetClientsByCPF(string cpf);

        Client[] GetClientsByCNPJ(string cnpj);

        bool SaveChanges();

    }
}

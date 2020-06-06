using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SportsX.API.Models.Data;

namespace SportsX.API.Repositories
{
    public class Repository : IRepository
    {
        
        private readonly SportsXContext Context;

        public Repository(SportsXContext context)
        {
            Context = context;
        }

        public void Add<Type>(Type entity) where Type : class
        {
            Context.Add(entity);
        }

        public void Update<Type>(Type entity) where Type : class
        {
            Context.Update(entity);
        }

        public void Remove<Type>(Type entity) where Type : class
        {
            Context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (Context.SaveChanges() > 0);
        }

        public Client[] GetAllClients()
        {
            IQueryable<Client> query = Context.Clients;

            query = query.Include(client => client.Phones);

            query = query.AsNoTracking().OrderBy(aluno => aluno.Name);

            return query.ToArray();
        }

        public Client[] GetClientsByName(string name)
        {
            IQueryable<Client> query = Context.Clients;

            query = query.Include(client => client.Phones);

            query = query.AsNoTracking().Where(client => client.Name.Contains(name)).OrderBy(aluno => aluno.Name);

            return query.ToArray();
        }

        public Client GetClientById(int id)
        {
            IQueryable<Client> query = Context.Clients;

            query = query.Include(client => client.Phones);

            query = query.AsNoTracking().Where(client => client.Id == id);

            return query.FirstOrDefault();
        }

        public Client[] GetClientsByFederalRegistrationType(string federalRegister)
        {
            throw new NotImplementedException();
        }

        public Client[] GetClientsByCPF(string cpf)
        {
            throw new NotImplementedException();
        }

        public Client[] GetClientsByCNPJ(string cnpj)
        {
            throw new NotImplementedException();
        }
    }
}

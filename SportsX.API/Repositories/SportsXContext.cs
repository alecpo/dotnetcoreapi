using Microsoft.EntityFrameworkCore;
using SportsX.API.Models.Data;

namespace SportsX.API.Repositories
{
    public class SportsXContext : DbContext
    {

        public SportsXContext(DbContextOptions<SportsXContext> options) : base(options){ }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }
}

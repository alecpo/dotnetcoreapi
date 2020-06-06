using Microsoft.EntityFrameworkCore;
using SportsX.API.Models;

namespace SportsX.API.Data
{
    public class SportsXContext : DbContext
    {

        public SportsXContext(DbContextOptions<SportsXContext> options) : base(options){ }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Phone> Phones { get; set; }
    }
}

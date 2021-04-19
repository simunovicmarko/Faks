//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace VIZ_Simunovic_Naloga2
{
    public class UserContext : DbContext
    {
        public UserContext() : base("Users")
        {
            Database.SetInitializer<UserContext>(new BazaInitializier());
        }

        public DbSet<User> Users { get; set; }

    }
}

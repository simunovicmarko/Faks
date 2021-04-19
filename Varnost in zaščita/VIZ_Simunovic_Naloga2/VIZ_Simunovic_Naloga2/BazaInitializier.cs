//using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace VIZ_Simunovic_Naloga2
{
    public class BazaInitializier : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext context)
        {
            base.Seed(context);
        }
    }
}

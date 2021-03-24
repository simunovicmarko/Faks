using System.Data.Entity;


namespace ORA_REST_API
{
    //[DataContract]
    public class TriatlonContext : DbContext
    {

        public TriatlonContext() : base("Triatlon")
        {
            //Database.SetInitializer<TriatlonContext>(new BazaInitializier());
        }

        public TriatlonContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<TriatlonContext>(new BazaInitializier());
        }

        public DbSet<Results> Results { get; set; }
        public DbSet<Competition> competitions { get; set; }
        public DbSet<User> users { get; set; }

    }

    public class BazaInitializier : DropCreateDatabaseIfModelChanges<TriatlonContext>
    {
        protected override void Seed(TriatlonContext context)
        {
            base.Seed(context);
        }
    }
}


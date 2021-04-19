using System.Data.Entity;


namespace ORA_REST_API
{
    //[DataContract]
    public sealed class TriatlonContext : DbContext
    {
        private static TriatlonContext instance = null;
        private static readonly object padlock = new object();
        private TriatlonContext() : base("Triatlon")
        {
            //Database.SetInitializer<TriatlonContext>(new BazaInitializier());
        }

        public static TriatlonContext Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new TriatlonContext();
                    }
                    return instance;
                }
            }
        }
        public DbSet<Results> Results { get; set; }
        public DbSet<Competition> Competitions { get; set; }
        public DbSet<User> Users { get; set; }

    }

    public class BazaInitializier : DropCreateDatabaseIfModelChanges<TriatlonContext>
    {
        protected override void Seed(TriatlonContext context)
        {
            base.Seed(context);
        }
    }
}


using DRS_Simunovic.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic
{
    public sealed class AtletikaContext : DbContext
    {
        private static AtletikaContext instance = null;
        private static readonly object padlock = new object();
        private AtletikaContext() : base("Atletika")
        {
            //Database.SetInitializer<TriatlonContext>(new BazaInitializier());
        }

        public static AtletikaContext Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new AtletikaContext();
                    }
                    return instance;
                }
            }
        }
        public DbSet<Uporabnik> uporabniks { get; set; }
        public DbSet<Tekmovanje> tekmovanjes { get; set; }
        public DbSet<Sportnik> Sportniks { get; set; }

    }

    public class BazaInitializier : DropCreateDatabaseIfModelChanges<AtletikaContext>
    {
        protected override void Seed(AtletikaContext context)
        {
            base.Seed(context);
        }
    }
}

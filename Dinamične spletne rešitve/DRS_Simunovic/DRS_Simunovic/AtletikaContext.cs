using DRS_Simunovic.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
//using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;

namespace DRS_Simunovic
{
    public sealed class AtletikaContext : IdentityDbContext<IdentityUser>
    {
        private static AtletikaContext instance = null;
        private static readonly object padlock = new object();
        private AtletikaContext() : base("Atletika", throwIfV1Schema:false)
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

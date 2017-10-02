using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.Persistence.Entities;
using GAP.Persistence.Migrations;

namespace GAP.Persistence.DBContext
{
    public class GAPShoesDbContext : DbContext
    {

        public GAPShoesDbContext() : base("GAPShoesDBConnectionString")
        {
            Database.SetInitializer<GAPShoesDbContext>(new CreateDatabaseIfNotExists<GAPShoesDbContext>());

            //Database.SetInitializer<GAPShoesDbContext>(new DropCreateDatabaseIfModelChanges<GAPShoesDbContext>());
            //Database.SetInitializer<GAPShoesDbContext>(new DropCreateDatabaseAlways<GAPShoesDbContext>());
            Database.SetInitializer<GAPShoesDbContext>(new GAPShoesDbInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }


    }
}

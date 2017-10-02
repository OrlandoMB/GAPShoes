using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GAP.WebApi.Persistence.Entities;
using GAP.WebApi.Persistence.Migrations;

namespace GAP.WebApi.Persistence.DBContext
{
    public class GAPShoesDbContext : DbContext
    {
        public GAPShoesDbContext() : base("GAPShoes")
        {
            Database.SetInitializer<GAPShoesDbContext>(new CreateDatabaseIfNotExists<GAPShoesDbContext>());
            Database.SetInitializer<GAPShoesDbContext>(new GAPShoesDbInitializer());
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }
    }
}

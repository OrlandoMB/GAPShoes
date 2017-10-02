namespace GAP.WebApi.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.WebApi.Persistence.DBContext.GAPShoesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled =true;
        }

    }
}

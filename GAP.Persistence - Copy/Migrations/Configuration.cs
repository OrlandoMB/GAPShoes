namespace GAP.Persistence.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GAP.Persistence.DBContext.GAPShoesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled =true;
        }

    }
}

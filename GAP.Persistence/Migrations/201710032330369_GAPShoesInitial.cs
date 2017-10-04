namespace GAP.Persistence.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GAPShoesInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        TotalInShelf = c.Int(nullable: false),
                        TotalInVault = c.Int(nullable: false),
                        Store_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stores", t => t.Store_Id, cascadeDelete: true)
                .Index(t => t.Store_Id);
            
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articles", "Store_Id", "dbo.Stores");
            DropIndex("dbo.Articles", new[] { "Store_Id" });
            DropTable("dbo.Stores");
            DropTable("dbo.Articles");
        }
    }
}

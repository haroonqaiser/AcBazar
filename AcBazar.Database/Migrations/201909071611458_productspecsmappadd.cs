namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productspecsmappadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSpecMapps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductSpecsID = c.Int(nullable: false),
                        ProductSpecs_SpecKey = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.ProductSpecs", t => t.ProductSpecs_SpecKey)
                .Index(t => t.ProductID)
                .Index(t => t.ProductSpecs_SpecKey);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSpecMapps", "ProductSpecs_SpecKey", "dbo.ProductSpecs");
            DropForeignKey("dbo.ProductSpecMapps", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductSpecMapps", new[] { "ProductSpecs_SpecKey" });
            DropIndex("dbo.ProductSpecMapps", new[] { "ProductID" });
            DropTable("dbo.ProductSpecMapps");
        }
    }
}

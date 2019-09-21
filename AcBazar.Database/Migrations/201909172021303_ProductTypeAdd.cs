namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTypeAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        RowAddUser = c.String(),
                        RowAddDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Products", "ProductTypeID", c => c.Int());
            CreateIndex("dbo.Products", "ProductTypeID");
            AddForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductTypeID", "dbo.ProductTypes");
            DropIndex("dbo.Products", new[] { "ProductTypeID" });
            DropColumn("dbo.Products", "ProductTypeID");
            DropTable("dbo.ProductTypes");
        }
    }
}

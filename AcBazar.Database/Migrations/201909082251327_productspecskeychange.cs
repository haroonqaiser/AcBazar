namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productspecskeychange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductSpecMapps", "ProductSpecs_SpecKey", "dbo.ProductSpecs");
            DropIndex("dbo.ProductSpecMapps", new[] { "ProductSpecs_SpecKey" });
            RenameColumn(table: "dbo.ProductSpecMapps", name: "ProductSpecs_SpecKey", newName: "SpecKey");
            AlterColumn("dbo.ProductSpecMapps", "SpecKey", c => c.Int(nullable: false));
            CreateIndex("dbo.ProductSpecMapps", "SpecKey");
            AddForeignKey("dbo.ProductSpecMapps", "SpecKey", "dbo.ProductSpecs", "SpecKey", cascadeDelete: true);
            DropColumn("dbo.ProductSpecMapps", "ProductSpecsID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSpecMapps", "ProductSpecsID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductSpecMapps", "SpecKey", "dbo.ProductSpecs");
            DropIndex("dbo.ProductSpecMapps", new[] { "SpecKey" });
            AlterColumn("dbo.ProductSpecMapps", "SpecKey", c => c.Int());
            RenameColumn(table: "dbo.ProductSpecMapps", name: "SpecKey", newName: "ProductSpecs_SpecKey");
            CreateIndex("dbo.ProductSpecMapps", "ProductSpecs_SpecKey");
            AddForeignKey("dbo.ProductSpecMapps", "ProductSpecs_SpecKey", "dbo.ProductSpecs", "SpecKey");
        }
    }
}

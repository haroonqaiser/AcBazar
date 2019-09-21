namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountfeatures : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "IsSale", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsNew", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsBest", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "IsCancel", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "AmountDis", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "AmountDisPer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "AmountDisPer");
            DropColumn("dbo.Products", "AmountDis");
            DropColumn("dbo.Products", "IsCancel");
            DropColumn("dbo.Products", "IsBest");
            DropColumn("dbo.Products", "IsNew");
            DropColumn("dbo.Products", "IsSale");
        }
    }
}

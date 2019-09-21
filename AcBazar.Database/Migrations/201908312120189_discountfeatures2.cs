namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountfeatures2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "AmountDis", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "AmountDisPer", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AmountDisPer", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "AmountDis", c => c.Double(nullable: false));
        }
    }
}

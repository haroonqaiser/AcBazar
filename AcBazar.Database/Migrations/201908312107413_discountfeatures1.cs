namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discountfeatures1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "AmountDis", c => c.Double(nullable: false));
            AlterColumn("dbo.Products", "AmountDisPer", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "AmountDisPer", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "AmountDis", c => c.Boolean(nullable: false));
        }
    }
}

namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specdetailsadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecs", "SpecInputValueType", c => c.String());
            AddColumn("dbo.ProductSpecs", "OrderSeq", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSpecs", "OrderSeq");
            DropColumn("dbo.ProductSpecs", "SpecInputValueType");
        }
    }
}

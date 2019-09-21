namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class specdetailsadd2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductSpecs", "SpecInputValueType", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductSpecs", "SpecInputValueType", c => c.String());
        }
    }
}

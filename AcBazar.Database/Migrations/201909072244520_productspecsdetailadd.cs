namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productspecsdetailadd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSpecMapps", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSpecMapps", "Name");
        }
    }
}

namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inatilization_2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "RowAddUser", c => c.String());
            AddColumn("dbo.Categories", "RowAddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "RowAddUser", c => c.String());
            AddColumn("dbo.Products", "RowAddDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "RowAddDate");
            DropColumn("dbo.Products", "RowAddUser");
            DropColumn("dbo.Categories", "RowAddDate");
            DropColumn("dbo.Categories", "RowAddUser");
        }
    }
}

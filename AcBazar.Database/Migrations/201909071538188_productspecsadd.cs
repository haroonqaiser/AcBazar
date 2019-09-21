namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productspecsadd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSpecs",
                c => new
                    {
                        SpecKey = c.Int(nullable: false, identity: true),
                        SpecValue = c.String(maxLength: 75),
                    })
                .PrimaryKey(t => t.SpecKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProductSpecs");
        }
    }
}

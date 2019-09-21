namespace AcBazar.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicconfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BasicConfigurations",
                c => new
                    {
                        ConfigKey = c.String(nullable: false, maxLength: 128),
                        ConfigDescription = c.String(),
                    })
                .PrimaryKey(t => t.ConfigKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BasicConfigurations");
        }
    }
}

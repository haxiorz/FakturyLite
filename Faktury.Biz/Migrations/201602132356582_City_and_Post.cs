namespace Faktury.Biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class City_and_Post : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "City", c => c.String());
            AddColumn("dbo.Clients", "PostCode", c => c.String());
            AddColumn("dbo.Owners", "City", c => c.String());
            AddColumn("dbo.Owners", "PostCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Owners", "PostCode");
            DropColumn("dbo.Owners", "City");
            DropColumn("dbo.Clients", "PostCode");
            DropColumn("dbo.Clients", "City");
        }
    }
}

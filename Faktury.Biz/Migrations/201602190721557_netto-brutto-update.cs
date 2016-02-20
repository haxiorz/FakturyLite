namespace Faktury.Biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nettobruttoupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "BruttoPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "BruttoPrice");
        }
    }
}

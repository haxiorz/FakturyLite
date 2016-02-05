namespace Faktury.Biz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01012016 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Clients", "InvoiceId");
            DropColumn("dbo.Owners", "InvoiceId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Owners", "InvoiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "InvoiceId", c => c.Int(nullable: false));
        }
    }
}

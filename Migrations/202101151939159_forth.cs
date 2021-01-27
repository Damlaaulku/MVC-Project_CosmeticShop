namespace CosmeticShop.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forth : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Description", c => c.String());
            DropColumn("dbo.Products", "Desc");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Desc", c => c.String());
            DropColumn("dbo.Products", "Description");
        }
    }
}

namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsSubbed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "IsSubbed", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubbed");
        }
    }
}

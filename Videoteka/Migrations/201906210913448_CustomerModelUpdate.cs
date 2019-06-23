namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "LastName");
        }
    }
}

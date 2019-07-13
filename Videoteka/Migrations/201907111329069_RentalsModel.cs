namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RentalsViewModels", newName: "Rentals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Rentals", newName: "RentalsViewModels");
        }
    }
}

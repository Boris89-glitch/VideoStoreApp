namespace Videoteka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RentalsViewModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Rentals", newName: "RentalsViewModels");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.RentalsViewModels", newName: "Rentals");
        }
    }
}

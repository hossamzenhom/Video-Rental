namespace VideoRental.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnsToCustomersTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}

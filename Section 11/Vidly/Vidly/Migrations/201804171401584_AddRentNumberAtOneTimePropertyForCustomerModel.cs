namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentNumberAtOneTimePropertyForCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "RentNumberAtOneTime", c => c.Byte(nullable: false));

            Sql("UPDATE Customers SET RentNumberAtOneTime = 2");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "RentNumberAtOneTime");
        }
    }
}

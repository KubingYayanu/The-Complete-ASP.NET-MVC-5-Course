namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDelinquentPropertyToCustomerModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Delinquent", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Delinquent");
        }
    }
}

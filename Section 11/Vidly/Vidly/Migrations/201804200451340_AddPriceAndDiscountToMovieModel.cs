namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceAndDiscountToMovieModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Price", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "Discount", c => c.Decimal(nullable: false, precision: 18, scale: 2));

            Sql("UPDATE Movies SET Price = 50, Discount = 1");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Discount");
            DropColumn("dbo.Movies", "Price");
        }
    }
}

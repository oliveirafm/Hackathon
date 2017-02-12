namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customer_email : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CustomerEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "CustomerEmail");
        }
    }
}

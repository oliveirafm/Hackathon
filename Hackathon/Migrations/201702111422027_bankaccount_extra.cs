namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bankaccount_extra : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BankAccounts", "currentYearPensionRetained", c => c.Double());
            AddColumn("dbo.BankAccounts", "accumulatedPensionSavings", c => c.Double());
            AddColumn("dbo.BankAccounts", "currentYearTaxRetained", c => c.Double());
            AddColumn("dbo.BankAccounts", "currentYearRentingRetained", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BankAccounts", "currentYearRentingRetained");
            DropColumn("dbo.BankAccounts", "currentYearTaxRetained");
            DropColumn("dbo.BankAccounts", "accumulatedPensionSavings");
            DropColumn("dbo.BankAccounts", "currentYearPensionRetained");
        }
    }
}

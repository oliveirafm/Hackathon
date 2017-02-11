namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix_initial_migration_ : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Invoices", "plan_DiversificationPlanId", "dbo.DiversificationPlans");
            DropIndex("dbo.Invoices", new[] { "plan_DiversificationPlanId" });
            AddColumn("dbo.DiversificationPlanItems", "Invoice_InvoiceId", c => c.Int());
            CreateIndex("dbo.DiversificationPlanItems", "Invoice_InvoiceId");
            AddForeignKey("dbo.DiversificationPlanItems", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            DropColumn("dbo.Invoices", "plan_DiversificationPlanId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Invoices", "plan_DiversificationPlanId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DiversificationPlanItems", "Invoice_InvoiceId", "dbo.Invoices");
            DropIndex("dbo.DiversificationPlanItems", new[] { "Invoice_InvoiceId" });
            DropColumn("dbo.DiversificationPlanItems", "Invoice_InvoiceId");
            CreateIndex("dbo.Invoices", "plan_DiversificationPlanId");
            AddForeignKey("dbo.Invoices", "plan_DiversificationPlanId", "dbo.DiversificationPlans", "DiversificationPlanId", cascadeDelete: true);
        }
    }
}

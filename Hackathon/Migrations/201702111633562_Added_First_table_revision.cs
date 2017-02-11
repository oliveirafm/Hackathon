namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Added_First_table_revision : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CompanyDepartments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CustomerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "CustomerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.DiversificationPlanItems", "Invoice_InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ProductCatalogues", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ProductCatalogues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseCatalogues", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.PurchaseCatalogues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "Company_Index", "dbo.Companies");
            DropForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "Company_Index", "dbo.Companies");
            DropForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CompanyDepartments", new[] { "CompanyId" });
            DropIndex("dbo.Customers", new[] { "CustomerCompanyId" });
            DropIndex("dbo.Customers", new[] { "Company_Index" });
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "CustomerCompanyId" });
            DropIndex("dbo.Invoices", new[] { "Company_Index" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "Invoice_InvoiceId" });
            DropIndex("dbo.ProductCatalogues", new[] { "ProductId" });
            DropIndex("dbo.ProductCatalogues", new[] { "CompanyId" });
            DropIndex("dbo.PurchaseCatalogues", new[] { "ProductId" });
            DropIndex("dbo.PurchaseCatalogues", new[] { "CompanyId" });
            DropColumn("dbo.Customers", "CompanyId");
            DropColumn("dbo.Invoices", "IssuerCompanyId");
            RenameColumn(table: "dbo.Customers", name: "Company_Index", newName: "CompanyId");
            RenameColumn(table: "dbo.Invoices", name: "Company_Index", newName: "IssuerCompanyId");
            DropPrimaryKey("dbo.Companies");
            DropPrimaryKey("dbo.SmartContracts");
            CreateTable(
                "dbo.ExchangeAccounts",
                c => new
                    {
                        ExchangeAccountId = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        CompanyName = c.String(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.ExchangeAccountId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.InvoicePaymentDivisions",
                c => new
                    {
                        InvoicePaymentDivisionId = c.Int(nullable: false, identity: true),
                        InvoiceId = c.Int(),
                        Value = c.Double(nullable: false),
                        ContractedServiceConfigurationId = c.Int(),
                    })
                .PrimaryKey(t => t.InvoicePaymentDivisionId)
                .ForeignKey("dbo.ContractedServiceConfigurations", t => t.ContractedServiceConfigurationId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.InvoiceId)
                .Index(t => t.ContractedServiceConfigurationId);
            
            CreateTable(
                "dbo.ContractedServiceConfigurations",
                c => new
                    {
                        ContractedServiceConfigurationId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        ExchangeServiceId = c.Int(),
                        ExchangeServiceParameter1 = c.String(),
                        ExchangeServiceParameter2 = c.String(),
                        ExchangeServiceParameter3 = c.String(),
                        ExchangeServiceParameter4 = c.String(),
                        ExchangeServiceParameter5 = c.String(),
                    })
                .PrimaryKey(t => t.ContractedServiceConfigurationId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .ForeignKey("dbo.ExchangeServices", t => t.ExchangeServiceId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.ExchangeServiceId);
            
            CreateTable(
                "dbo.ExchangeServices",
                c => new
                    {
                        ExchangeServiceId = c.Int(nullable: false, identity: true),
                        ExchangeServiceName = c.String(),
                        AvailableInMarket = c.Boolean(nullable: false),
                        SmartContractId = c.Int(),
                    })
                .PrimaryKey(t => t.ExchangeServiceId)
                .ForeignKey("dbo.SmartContracts", t => t.SmartContractId)
                .Index(t => t.SmartContractId);
            
            CreateTable(
                "dbo.ExchangeAccountMovements",
                c => new
                    {
                        ExchangeAccountMovementId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        InvoiceId = c.Int(),
                        CompanyId = c.Int(),
                        TransactionDate = c.DateTime(nullable: false),
                        AmountDeposit = c.Decimal(precision: 18, scale: 2),
                        SourceDeposit = c.String(),
                        DiversificationPlanItemId = c.Int(),
                        AmountWithdrawal = c.Decimal(precision: 18, scale: 2),
                        DestinationWithdrawal = c.String(),
                        ExchangeServiceId = c.Int(),
                        ContractedServiceConfigurationId = c.Int(),
                    })
                .PrimaryKey(t => t.ExchangeAccountMovementId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ContractedServiceConfigurations", t => t.ContractedServiceConfigurationId)
                .ForeignKey("dbo.DiversificationPlanItems", t => t.DiversificationPlanItemId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .ForeignKey("dbo.ExchangeServices", t => t.ExchangeServiceId)
                .ForeignKey("dbo.Invoices", t => t.InvoiceId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.InvoiceId)
                .Index(t => t.CompanyId)
                .Index(t => t.DiversificationPlanItemId)
                .Index(t => t.ExchangeServiceId)
                .Index(t => t.ContractedServiceConfigurationId);
            
            AddColumn("dbo.BankAccounts", "ExchangeAccountId", c => c.Int());
            AddColumn("dbo.Companies", "CompanyId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BankMovements", "ExchangeAccountId", c => c.Int());
            AddColumn("dbo.BankMovements", "SourceDepositRef", c => c.String());
            AddColumn("dbo.BankMovements", "DestinationWithdrawalRef", c => c.String());
            AddColumn("dbo.Customers", "ExchangeAccountId", c => c.Int());
            AddColumn("dbo.Customers", "CustomerName", c => c.String());
            AddColumn("dbo.Customers", "CustomerVatNumber", c => c.Int());
            AddColumn("dbo.Invoices", "ExchangeAccountId", c => c.Int());
            AddColumn("dbo.Invoices", "PaymentService", c => c.String());
            AddColumn("dbo.Invoices", "PaymentValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "PaymentServiceHours", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "CustomerName", c => c.String());
            AddColumn("dbo.Invoices", "CustomerId", c => c.Int());
            AddColumn("dbo.DiversificationPlanItems", "ExchangeServiceId", c => c.Int());
            AddColumn("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId", c => c.Int());
            AddColumn("dbo.DiversificationPlans", "ExchangeAccountId", c => c.Int());
            AddColumn("dbo.SmartContracts", "SmartContractId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.SmartContracts", "ContractAbi", c => c.String());
            AddColumn("dbo.SmartContracts", "BlockChainAccountId", c => c.Int());
            AlterColumn("dbo.Companies", "IBAN", c => c.String());
            AlterColumn("dbo.BlockChainAccounts", "AccountPassword", c => c.String(nullable: false));
            AddPrimaryKey("dbo.Companies", "CompanyId");
            AddPrimaryKey("dbo.SmartContracts", "SmartContractId");
            CreateIndex("dbo.BankAccounts", "ExchangeAccountId");
            CreateIndex("dbo.BankMovements", "ExchangeAccountId");
            CreateIndex("dbo.Customers", "ExchangeAccountId");
            CreateIndex("dbo.Invoices", "ExchangeAccountId");
            CreateIndex("dbo.Invoices", "CustomerId");
            CreateIndex("dbo.SmartContracts", "BlockChainAccountId");
            CreateIndex("dbo.DiversificationPlans", "ExchangeAccountId");
            CreateIndex("dbo.DiversificationPlanItems", "ExchangeServiceId");
            CreateIndex("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId");
            AddForeignKey("dbo.Customers", "ExchangeAccountId", "dbo.ExchangeAccounts", "ExchangeAccountId");
            AddForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers", "CustomerId");
            AddForeignKey("dbo.Invoices", "ExchangeAccountId", "dbo.ExchangeAccounts", "ExchangeAccountId");
            AddForeignKey("dbo.SmartContracts", "BlockChainAccountId", "dbo.BlockChainAccounts", "BlockChainAccountId");
            AddForeignKey("dbo.DiversificationPlans", "ExchangeAccountId", "dbo.ExchangeAccounts", "ExchangeAccountId");
            AddForeignKey("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations", "ContractedServiceConfigurationId");
            AddForeignKey("dbo.DiversificationPlanItems", "ExchangeServiceId", "dbo.ExchangeServices", "ExchangeServiceId");
            AddForeignKey("dbo.BankMovements", "ExchangeAccountId", "dbo.ExchangeAccounts", "ExchangeAccountId");
            AddForeignKey("dbo.BankAccounts", "ExchangeAccountId", "dbo.ExchangeAccounts", "ExchangeAccountId");
            AddForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Customers", "CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies", "CompanyId");
            AddForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies", "CompanyId");
            DropColumn("dbo.BankAccounts", "OwnerBlockChainAddress");
            DropColumn("dbo.Companies", "Index");
            DropColumn("dbo.BankMovements", "SourceDepositId");
            DropColumn("dbo.BankMovements", "DestinationWithdrawalId");
            DropColumn("dbo.BankMovements", "isTaxationTransaction");
            DropColumn("dbo.Customers", "CustomerCompanyId");
            DropColumn("dbo.Invoices", "IssuerCompanyName");
            DropColumn("dbo.Invoices", "IssuerBlockChainAddress");
            DropColumn("dbo.Invoices", "IssuerCompanyActivityCountry");
            DropColumn("dbo.Invoices", "InvoiceNumber");
            DropColumn("dbo.Invoices", "ProductNumber");
            DropColumn("dbo.Invoices", "ProductName");
            DropColumn("dbo.Invoices", "ProductValue");
            DropColumn("dbo.Invoices", "ProductQuantity");
            DropColumn("dbo.Invoices", "ProductId");
            DropColumn("dbo.Invoices", "CustomerCompanyName");
            DropColumn("dbo.Invoices", "CustomerBlockChainAddress");
            DropColumn("dbo.Invoices", "CustomerCompanyActivityCountry");
            DropColumn("dbo.Invoices", "CustomerCompanyId");
            DropColumn("dbo.DiversificationPlanItems", "Invoice_InvoiceId");
            DropColumn("dbo.BlockChainAccounts", "AccountCompanyId");
            DropColumn("dbo.BlockChainAccounts", "AccountType");
            DropColumn("dbo.SmartContracts", "ContractId");
            DropColumn("dbo.SmartContracts", "ContractFileName");
            DropColumn("dbo.SmartContracts", "ParametersCount");
            DropColumn("dbo.SmartContracts", "ParametersTypes");
            DropColumn("dbo.SmartContracts", "Abi");
            DropTable("dbo.CompanyDepartments");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCatalogues");
            DropTable("dbo.PurchaseCatalogues");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PurchaseCatalogues",
                c => new
                    {
                        PurchaseCatalogueId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseCatalogueId);
            
            CreateTable(
                "dbo.ProductCatalogues",
                c => new
                    {
                        ProductCatalogueId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductCatalogueId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductSerialNumber = c.Int(),
                        ProductName = c.String(),
                        VatPercentage = c.Int(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.CompanyDepartments",
                c => new
                    {
                        CompanyDepartmentId = c.Int(nullable: false, identity: true),
                        CompanyDepartmentName = c.String(),
                        CompanyDepartmentHead = c.String(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyDepartmentId);
            
            AddColumn("dbo.SmartContracts", "Abi", c => c.String());
            AddColumn("dbo.SmartContracts", "ParametersTypes", c => c.String());
            AddColumn("dbo.SmartContracts", "ParametersCount", c => c.Int(nullable: false));
            AddColumn("dbo.SmartContracts", "ContractFileName", c => c.String());
            AddColumn("dbo.SmartContracts", "ContractId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BlockChainAccounts", "AccountType", c => c.String());
            AddColumn("dbo.BlockChainAccounts", "AccountCompanyId", c => c.Int());
            AddColumn("dbo.DiversificationPlanItems", "Invoice_InvoiceId", c => c.Int());
            AddColumn("dbo.Invoices", "CustomerCompanyId", c => c.Int());
            AddColumn("dbo.Invoices", "CustomerCompanyActivityCountry", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "CustomerBlockChainAddress", c => c.String());
            AddColumn("dbo.Invoices", "CustomerCompanyName", c => c.String());
            AddColumn("dbo.Invoices", "ProductId", c => c.Int());
            AddColumn("dbo.Invoices", "ProductQuantity", c => c.Int());
            AddColumn("dbo.Invoices", "ProductValue", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Invoices", "ProductName", c => c.String());
            AddColumn("dbo.Invoices", "ProductNumber", c => c.Int());
            AddColumn("dbo.Invoices", "InvoiceNumber", c => c.Int());
            AddColumn("dbo.Invoices", "IssuerCompanyActivityCountry", c => c.Int(nullable: false));
            AddColumn("dbo.Invoices", "IssuerBlockChainAddress", c => c.String());
            AddColumn("dbo.Invoices", "IssuerCompanyName", c => c.String());
            AddColumn("dbo.Customers", "CustomerCompanyId", c => c.Int());
            AddColumn("dbo.BankMovements", "isTaxationTransaction", c => c.Boolean(nullable: false));
            AddColumn("dbo.BankMovements", "DestinationWithdrawalId", c => c.Int());
            AddColumn("dbo.BankMovements", "SourceDepositId", c => c.Int());
            AddColumn("dbo.Companies", "Index", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.BankAccounts", "OwnerBlockChainAddress", c => c.String());
            DropForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ExchangeAccountMovements", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ExchangeAccountMovements", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.ExchangeAccountMovements", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.ExchangeAccountMovements", "DiversificationPlanItemId", "dbo.DiversificationPlanItems");
            DropForeignKey("dbo.ExchangeAccountMovements", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.ExchangeAccountMovements", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankAccounts", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.BankMovements", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.DiversificationPlanItems", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.DiversificationPlans", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.InvoicePaymentDivisions", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoicePaymentDivisions", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.ContractedServiceConfigurations", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.ExchangeServices", "SmartContractId", "dbo.SmartContracts");
            DropForeignKey("dbo.SmartContracts", "BlockChainAccountId", "dbo.BlockChainAccounts");
            DropForeignKey("dbo.ContractedServiceConfigurations", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.Invoices", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.ExchangeAccounts", "CompanyId", "dbo.Companies");
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ExchangeServiceId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "DiversificationPlanItemId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "CompanyId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "InvoiceId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ExchangeAccountId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "ExchangeServiceId" });
            DropIndex("dbo.DiversificationPlans", new[] { "ExchangeAccountId" });
            DropIndex("dbo.SmartContracts", new[] { "BlockChainAccountId" });
            DropIndex("dbo.ExchangeServices", new[] { "SmartContractId" });
            DropIndex("dbo.ContractedServiceConfigurations", new[] { "ExchangeServiceId" });
            DropIndex("dbo.ContractedServiceConfigurations", new[] { "ExchangeAccountId" });
            DropIndex("dbo.InvoicePaymentDivisions", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.InvoicePaymentDivisions", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "ExchangeAccountId" });
            DropIndex("dbo.Customers", new[] { "ExchangeAccountId" });
            DropIndex("dbo.ExchangeAccounts", new[] { "CompanyId" });
            DropIndex("dbo.BankMovements", new[] { "ExchangeAccountId" });
            DropIndex("dbo.BankAccounts", new[] { "ExchangeAccountId" });
            DropPrimaryKey("dbo.SmartContracts");
            DropPrimaryKey("dbo.Companies");
            AlterColumn("dbo.BlockChainAccounts", "AccountPassword", c => c.String());
            AlterColumn("dbo.Companies", "IBAN", c => c.String(nullable: false));
            DropColumn("dbo.SmartContracts", "BlockChainAccountId");
            DropColumn("dbo.SmartContracts", "ContractAbi");
            DropColumn("dbo.SmartContracts", "SmartContractId");
            DropColumn("dbo.DiversificationPlans", "ExchangeAccountId");
            DropColumn("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId");
            DropColumn("dbo.DiversificationPlanItems", "ExchangeServiceId");
            DropColumn("dbo.Invoices", "CustomerId");
            DropColumn("dbo.Invoices", "CustomerName");
            DropColumn("dbo.Invoices", "PaymentServiceHours");
            DropColumn("dbo.Invoices", "PaymentValue");
            DropColumn("dbo.Invoices", "PaymentService");
            DropColumn("dbo.Invoices", "ExchangeAccountId");
            DropColumn("dbo.Customers", "CustomerVatNumber");
            DropColumn("dbo.Customers", "CustomerName");
            DropColumn("dbo.Customers", "ExchangeAccountId");
            DropColumn("dbo.BankMovements", "DestinationWithdrawalRef");
            DropColumn("dbo.BankMovements", "SourceDepositRef");
            DropColumn("dbo.BankMovements", "ExchangeAccountId");
            DropColumn("dbo.Companies", "CompanyId");
            DropColumn("dbo.BankAccounts", "ExchangeAccountId");
            DropTable("dbo.ExchangeAccountMovements");
            DropTable("dbo.ExchangeServices");
            DropTable("dbo.ContractedServiceConfigurations");
            DropTable("dbo.InvoicePaymentDivisions");
            DropTable("dbo.ExchangeAccounts");
            AddPrimaryKey("dbo.SmartContracts", "ContractId");
            AddPrimaryKey("dbo.Companies", "Index");
            RenameColumn(table: "dbo.Invoices", name: "IssuerCompanyId", newName: "Company_Index");
            RenameColumn(table: "dbo.Customers", name: "CompanyId", newName: "Company_Index");
            AddColumn("dbo.Invoices", "IssuerCompanyId", c => c.Int());
            AddColumn("dbo.Customers", "CompanyId", c => c.Int());
            CreateIndex("dbo.PurchaseCatalogues", "CompanyId");
            CreateIndex("dbo.PurchaseCatalogues", "ProductId");
            CreateIndex("dbo.ProductCatalogues", "CompanyId");
            CreateIndex("dbo.ProductCatalogues", "ProductId");
            CreateIndex("dbo.DiversificationPlanItems", "Invoice_InvoiceId");
            CreateIndex("dbo.Invoices", "Company_Index");
            CreateIndex("dbo.Invoices", "CustomerCompanyId");
            CreateIndex("dbo.Invoices", "ProductId");
            CreateIndex("dbo.Customers", "Company_Index");
            CreateIndex("dbo.Customers", "CustomerCompanyId");
            CreateIndex("dbo.CompanyDepartments", "CompanyId");
            AddForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.Invoices", "Company_Index", "dbo.Companies", "Index");
            AddForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.Customers", "Company_Index", "dbo.Companies", "Index");
            AddForeignKey("dbo.Customers", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.PurchaseCatalogues", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.PurchaseCatalogues", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.Invoices", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.ProductCatalogues", "ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.ProductCatalogues", "CompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.DiversificationPlanItems", "Invoice_InvoiceId", "dbo.Invoices", "InvoiceId");
            AddForeignKey("dbo.Invoices", "CustomerCompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.Customers", "CustomerCompanyId", "dbo.Companies", "Index");
            AddForeignKey("dbo.CompanyDepartments", "CompanyId", "dbo.Companies", "Index");
        }
    }
}

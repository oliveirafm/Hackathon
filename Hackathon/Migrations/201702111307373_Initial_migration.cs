namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlockChainAccounts",
                c => new
                    {
                        BlockChainAccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountAddress = c.String(),
                        AccountPassword = c.String(),
                        AccountCompanyId = c.Int(),
                        AccountType = c.String(),
                    })
                .PrimaryKey(t => t.BlockChainAccountId);
            
            CreateTable(
                "dbo.BlockChainServers",
                c => new
                    {
                        BlockChainServerId = c.Int(nullable: false, identity: true),
                        ServerName = c.String(),
                        serverAddress = c.String(),
                        MinerHashrate = c.String(),
                        MinerSetGasPrice = c.String(),
                        MinerRunningStatus = c.Boolean(nullable: false),
                        SelectedServer = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BlockChainServerId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.SmartContracts",
                c => new
                    {
                        ContractId = c.Int(nullable: false, identity: true),
                        ContractName = c.String(),
                        ContractFileName = c.String(),
                        ParametersCount = c.Int(nullable: false),
                        ParametersTypes = c.String(),
                        ContractByteCode = c.String(),
                        Abi = c.String(),
                        ContractAddress = c.String(),
                        ContractOwnerAddress = c.String(),
                        ContractCode = c.String(),
                    })
                .PrimaryKey(t => t.ContractId);
            
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        OwnerCompanyName = c.String(),
                        AccountBalance = c.Decimal(precision: 18, scale: 2),
                        IssuerCompanyActivityCountry = c.Int(nullable: false),
                        OwnerBlockChainAddress = c.String(),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Index = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        VatNumber = c.Int(),
                        CompanyActivityCountry = c.Int(),
                        CompanyActivity = c.Int(),
                        CompanySector = c.Int(),
                        KvkNumber = c.String(),
                        BranchNumber = c.String(),
                        Rsin = c.String(),
                        BusinessName = c.String(),
                        SbiCode = c.String(),
                        SbiCodeDescription = c.String(),
                        AddressType = c.String(),
                        BagId = c.String(),
                        Street = c.String(),
                        HouseNumber = c.String(),
                        HouseNumberAddition = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        CompanyCountry = c.String(),
                        GPSLatitude = c.Double(nullable: false),
                        GPSLongitude = c.Double(nullable: false),
                        RijksdriehoekX = c.Double(nullable: false),
                        RijksdriehoekY = c.Double(nullable: false),
                        RijksdriehoekZ = c.Double(nullable: false),
                        CompanyBlockChainAddress = c.String(),
                        IBAN = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Index);
            
            CreateTable(
                "dbo.BankMovements",
                c => new
                    {
                        BankMovementId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        TransactionDate = c.DateTime(nullable: false),
                        AmountDeposit = c.Decimal(precision: 18, scale: 2),
                        SourceDeposit = c.String(),
                        SourceDepositId = c.Int(),
                        AmountWithdrawal = c.Decimal(precision: 18, scale: 2),
                        DestinationWithdrawal = c.String(),
                        DestinationWithdrawalId = c.Int(),
                        isTaxationTransaction = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BankMovementId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.CompanyDepartments",
                c => new
                    {
                        CompanyDepartmentId = c.Int(nullable: false, identity: true),
                        CompanyDepartmentName = c.String(),
                        CompanyDepartmentHead = c.String(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.CompanyDepartmentId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        CustomerCompanyId = c.Int(),
                        Company_Index = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Companies", t => t.CustomerCompanyId)
                .ForeignKey("dbo.Companies", t => t.Company_Index)
                .Index(t => t.CompanyId)
                .Index(t => t.CustomerCompanyId)
                .Index(t => t.Company_Index);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        IssuerCompanyName = c.String(),
                        IssuerBlockChainAddress = c.String(),
                        IssuerVatNumber = c.Int(),
                        IssuerCompanyActivityCountry = c.Int(nullable: false),
                        IssuerCompanyId = c.Int(),
                        InvoiceNumber = c.Int(),
                        IssueDateTimestamp = c.Int(),
                        IssueDate = c.DateTime(),
                        DueDateTimestamp = c.Int(),
                        DueDate = c.DateTime(),
                        ProductNumber = c.Int(),
                        ProductName = c.String(),
                        ProductValue = c.Decimal(precision: 18, scale: 2),
                        ProductQuantity = c.Int(),
                        ProductVatPercentage = c.Int(),
                        ProductVatValue = c.Decimal(precision: 18, scale: 2),
                        ProductId = c.Int(),
                        CustomerCompanyName = c.String(),
                        CustomerBlockChainAddress = c.String(),
                        CustomerVatNumber = c.Int(),
                        CustomerCompanyActivityCountry = c.Int(nullable: false),
                        CustomerCompanyId = c.Int(),
                        InvoiceValue = c.Decimal(precision: 18, scale: 2),
                        InvoiceVatValue = c.Decimal(precision: 18, scale: 2),
                        InvoiceVatPercentage = c.Int(),
                        InvoiceStatus = c.Int(nullable: false),
                        plan_DiversificationPlanId = c.Int(nullable: false),
                        Company_Index = c.Int(),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Companies", t => t.CustomerCompanyId)
                .ForeignKey("dbo.Companies", t => t.IssuerCompanyId)
                .ForeignKey("dbo.DiversificationPlans", t => t.plan_DiversificationPlanId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .ForeignKey("dbo.Companies", t => t.Company_Index)
                .Index(t => t.IssuerCompanyId)
                .Index(t => t.ProductId)
                .Index(t => t.CustomerCompanyId)
                .Index(t => t.plan_DiversificationPlanId)
                .Index(t => t.Company_Index);
            
            CreateTable(
                "dbo.DiversificationPlans",
                c => new
                    {
                        DiversificationPlanId = c.Int(nullable: false, identity: true),
                        CompanyId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.DiversificationPlanId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.DiversificationPlanItems",
                c => new
                    {
                        DiversificationPlanItemId = c.Int(nullable: false, identity: true),
                        DiversificationPlanId = c.Int(),
                        Value = c.Double(nullable: false),
                        Type = c.Int(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.DiversificationPlanItemId)
                .ForeignKey("dbo.DiversificationPlans", t => t.DiversificationPlanId)
                .Index(t => t.DiversificationPlanId);
            
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
                "dbo.ProductCatalogues",
                c => new
                    {
                        ProductCatalogueId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.ProductCatalogueId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.PurchaseCatalogues",
                c => new
                    {
                        PurchaseCatalogueId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(),
                        CompanyId = c.Int(),
                    })
                .PrimaryKey(t => t.PurchaseCatalogueId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.TransactionLogs",
                c => new
                    {
                        TransactionLogId = c.Int(nullable: false, identity: true),
                        LogDate = c.DateTime(nullable: false),
                        CalledService = c.String(),
                        CalledFunction = c.String(),
                        CalledParameters = c.String(),
                        ReturnedValue = c.String(),
                    })
                .PrimaryKey(t => t.TransactionLogId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PurchaseCatalogues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.PurchaseCatalogues", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "Company_Index", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCatalogues", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductCatalogues", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "plan_DiversificationPlanId", "dbo.DiversificationPlans");
            DropForeignKey("dbo.DiversificationPlanItems", "DiversificationPlanId", "dbo.DiversificationPlans");
            DropForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "CustomerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "Company_Index", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CustomerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.CompanyDepartments", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.PurchaseCatalogues", new[] { "CompanyId" });
            DropIndex("dbo.PurchaseCatalogues", new[] { "ProductId" });
            DropIndex("dbo.ProductCatalogues", new[] { "CompanyId" });
            DropIndex("dbo.ProductCatalogues", new[] { "ProductId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "DiversificationPlanId" });
            DropIndex("dbo.DiversificationPlans", new[] { "CompanyId" });
            DropIndex("dbo.Invoices", new[] { "Company_Index" });
            DropIndex("dbo.Invoices", new[] { "plan_DiversificationPlanId" });
            DropIndex("dbo.Invoices", new[] { "CustomerCompanyId" });
            DropIndex("dbo.Invoices", new[] { "ProductId" });
            DropIndex("dbo.Invoices", new[] { "IssuerCompanyId" });
            DropIndex("dbo.Customers", new[] { "Company_Index" });
            DropIndex("dbo.Customers", new[] { "CustomerCompanyId" });
            DropIndex("dbo.Customers", new[] { "CompanyId" });
            DropIndex("dbo.CompanyDepartments", new[] { "CompanyId" });
            DropIndex("dbo.BankMovements", new[] { "CompanyId" });
            DropIndex("dbo.BankAccounts", new[] { "CompanyId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TransactionLogs");
            DropTable("dbo.PurchaseCatalogues");
            DropTable("dbo.ProductCatalogues");
            DropTable("dbo.Products");
            DropTable("dbo.DiversificationPlanItems");
            DropTable("dbo.DiversificationPlans");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.CompanyDepartments");
            DropTable("dbo.BankMovements");
            DropTable("dbo.Companies");
            DropTable("dbo.BankAccounts");
            DropTable("dbo.SmartContracts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.BlockChainServers");
            DropTable("dbo.BlockChainAccounts");
        }
    }
}

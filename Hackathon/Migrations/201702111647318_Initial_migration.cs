namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        BankAccountId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        CompanyId = c.Int(),
                        OwnerCompanyName = c.String(),
                        AccountBalance = c.Decimal(precision: 18, scale: 2),
                        IssuerCompanyActivityCountry = c.Int(nullable: false),
                        currentYearPensionRetained = c.Double(),
                        accumulatedPensionSavings = c.Double(),
                        currentYearTaxRetained = c.Double(),
                        currentYearRentingRetained = c.Double(),
                    })
                .PrimaryKey(t => t.BankAccountId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        CompanyId = c.Int(nullable: false, identity: true),
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
                        IBAN = c.String(),
                    })
                .PrimaryKey(t => t.CompanyId);
            
            CreateTable(
                "dbo.BankMovements",
                c => new
                    {
                        BankMovementId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        CompanyId = c.Int(),
                        TransactionDate = c.DateTime(nullable: false),
                        AmountDeposit = c.Decimal(precision: 18, scale: 2),
                        SourceDeposit = c.String(),
                        SourceDepositRef = c.String(),
                        AmountWithdrawal = c.Decimal(precision: 18, scale: 2),
                        DestinationWithdrawal = c.String(),
                        DestinationWithdrawalRef = c.String(),
                    })
                .PrimaryKey(t => t.BankMovementId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.CompanyId);
            
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
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        CompanyId = c.Int(),
                        CustomerName = c.String(),
                        CustomerVatNumber = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.CompanyId);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        InvoiceId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        IssuerVatNumber = c.Int(),
                        IssuerCompanyId = c.Int(),
                        IssueDateTimestamp = c.Int(),
                        IssueDate = c.DateTime(),
                        DueDateTimestamp = c.Int(),
                        DueDate = c.DateTime(),
                        PaymentService = c.String(),
                        PaymentValue = c.Decimal(precision: 18, scale: 2),
                        PaymentServiceHours = c.Decimal(precision: 18, scale: 2),
                        ProductVatPercentage = c.Int(),
                        ProductVatValue = c.Decimal(precision: 18, scale: 2),
                        CustomerName = c.String(),
                        CustomerVatNumber = c.Int(),
                        CustomerId = c.Int(),
                        InvoiceValue = c.Decimal(precision: 18, scale: 2),
                        InvoiceVatValue = c.Decimal(precision: 18, scale: 2),
                        InvoiceVatPercentage = c.Int(),
                        InvoiceStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceId)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .ForeignKey("dbo.Companies", t => t.IssuerCompanyId)
                .Index(t => t.ExchangeAccountId)
                .Index(t => t.IssuerCompanyId)
                .Index(t => t.CustomerId);
            
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
                "dbo.SmartContracts",
                c => new
                    {
                        SmartContractId = c.Int(nullable: false, identity: true),
                        ContractName = c.String(),
                        ContractByteCode = c.String(),
                        ContractAbi = c.String(),
                        ContractCode = c.String(),
                        ContractAddress = c.String(),
                        ContractOwnerAddress = c.String(),
                        BlockChainAccountId = c.Int(),
                    })
                .PrimaryKey(t => t.SmartContractId)
                .ForeignKey("dbo.BlockChainAccounts", t => t.BlockChainAccountId)
                .Index(t => t.BlockChainAccountId);
            
            CreateTable(
                "dbo.BlockChainAccounts",
                c => new
                    {
                        BlockChainAccountId = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        AccountAddress = c.String(),
                        AccountPassword = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BlockChainAccountId);
            
            CreateTable(
                "dbo.DiversificationPlans",
                c => new
                    {
                        DiversificationPlanId = c.Int(nullable: false, identity: true),
                        ExchangeAccountId = c.Int(),
                        CompanyId = c.Int(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Observations = c.String(),
                    })
                .PrimaryKey(t => t.DiversificationPlanId)
                .ForeignKey("dbo.Companies", t => t.CompanyId)
                .ForeignKey("dbo.ExchangeAccounts", t => t.ExchangeAccountId)
                .Index(t => t.ExchangeAccountId)
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
                        ExchangeServiceId = c.Int(),
                        ContractedServiceConfigurationId = c.Int(),
                    })
                .PrimaryKey(t => t.DiversificationPlanItemId)
                .ForeignKey("dbo.ContractedServiceConfigurations", t => t.ContractedServiceConfigurationId)
                .ForeignKey("dbo.DiversificationPlans", t => t.DiversificationPlanId)
                .ForeignKey("dbo.ExchangeServices", t => t.ExchangeServiceId)
                .Index(t => t.DiversificationPlanId)
                .Index(t => t.ExchangeServiceId)
                .Index(t => t.ContractedServiceConfigurationId);
            
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
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ExchangeAccountMovements", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.ExchangeAccountMovements", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.ExchangeAccountMovements", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.ExchangeAccountMovements", "DiversificationPlanItemId", "dbo.DiversificationPlanItems");
            DropForeignKey("dbo.ExchangeAccountMovements", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.ExchangeAccountMovements", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankAccounts", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.BankAccounts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankMovements", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.DiversificationPlanItems", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.DiversificationPlanItems", "DiversificationPlanId", "dbo.DiversificationPlans");
            DropForeignKey("dbo.DiversificationPlanItems", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.DiversificationPlans", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.DiversificationPlans", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.InvoicePaymentDivisions", "InvoiceId", "dbo.Invoices");
            DropForeignKey("dbo.InvoicePaymentDivisions", "ContractedServiceConfigurationId", "dbo.ContractedServiceConfigurations");
            DropForeignKey("dbo.ContractedServiceConfigurations", "ExchangeServiceId", "dbo.ExchangeServices");
            DropForeignKey("dbo.ExchangeServices", "SmartContractId", "dbo.SmartContracts");
            DropForeignKey("dbo.SmartContracts", "BlockChainAccountId", "dbo.BlockChainAccounts");
            DropForeignKey("dbo.ContractedServiceConfigurations", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.Invoices", "IssuerCompanyId", "dbo.Companies");
            DropForeignKey("dbo.Invoices", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.Invoices", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ExchangeAccountId", "dbo.ExchangeAccounts");
            DropForeignKey("dbo.Customers", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.ExchangeAccounts", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.BankMovements", "CompanyId", "dbo.Companies");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ExchangeServiceId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "DiversificationPlanItemId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "CompanyId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "InvoiceId" });
            DropIndex("dbo.ExchangeAccountMovements", new[] { "ExchangeAccountId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "ExchangeServiceId" });
            DropIndex("dbo.DiversificationPlanItems", new[] { "DiversificationPlanId" });
            DropIndex("dbo.DiversificationPlans", new[] { "CompanyId" });
            DropIndex("dbo.DiversificationPlans", new[] { "ExchangeAccountId" });
            DropIndex("dbo.SmartContracts", new[] { "BlockChainAccountId" });
            DropIndex("dbo.ExchangeServices", new[] { "SmartContractId" });
            DropIndex("dbo.ContractedServiceConfigurations", new[] { "ExchangeServiceId" });
            DropIndex("dbo.ContractedServiceConfigurations", new[] { "ExchangeAccountId" });
            DropIndex("dbo.InvoicePaymentDivisions", new[] { "ContractedServiceConfigurationId" });
            DropIndex("dbo.InvoicePaymentDivisions", new[] { "InvoiceId" });
            DropIndex("dbo.Invoices", new[] { "CustomerId" });
            DropIndex("dbo.Invoices", new[] { "IssuerCompanyId" });
            DropIndex("dbo.Invoices", new[] { "ExchangeAccountId" });
            DropIndex("dbo.Customers", new[] { "CompanyId" });
            DropIndex("dbo.Customers", new[] { "ExchangeAccountId" });
            DropIndex("dbo.ExchangeAccounts", new[] { "CompanyId" });
            DropIndex("dbo.BankMovements", new[] { "CompanyId" });
            DropIndex("dbo.BankMovements", new[] { "ExchangeAccountId" });
            DropIndex("dbo.BankAccounts", new[] { "CompanyId" });
            DropIndex("dbo.BankAccounts", new[] { "ExchangeAccountId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TransactionLogs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ExchangeAccountMovements");
            DropTable("dbo.BlockChainServers");
            DropTable("dbo.DiversificationPlanItems");
            DropTable("dbo.DiversificationPlans");
            DropTable("dbo.BlockChainAccounts");
            DropTable("dbo.SmartContracts");
            DropTable("dbo.ExchangeServices");
            DropTable("dbo.ContractedServiceConfigurations");
            DropTable("dbo.InvoicePaymentDivisions");
            DropTable("dbo.Invoices");
            DropTable("dbo.Customers");
            DropTable("dbo.ExchangeAccounts");
            DropTable("dbo.BankMovements");
            DropTable("dbo.Companies");
            DropTable("dbo.BankAccounts");
        }
    }
}

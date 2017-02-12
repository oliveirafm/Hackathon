namespace Hackathon.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Hackathon.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Hackathon.Models.ApplicationDbContext context)
        {
            context.BankAccounts.AddOrUpdate(
                p => p.BankAccountId,
                new Models.BankAccount { AccountBalance = 200, currentYearPensionRetained=100, currentYearTaxRetained=10, currentYearRentingRetained = 5}
                );

            context.ExchangeServices.AddOrUpdate(
                p=> p.ExchangeServiceId,
                new Models.ExchangeService { ExchangeServiceId=1,  ExchangeServiceName = "Pension", AvailableInMarket=true},
                new Models.ExchangeService { ExchangeServiceId = 2, ExchangeServiceName = "Live Insurance", AvailableInMarket = true },
                new Models.ExchangeService { ExchangeServiceId = 3, ExchangeServiceName = "Renting (Auto)", AvailableInMarket = true },
                new Models.ExchangeService { ExchangeServiceId = 4, ExchangeServiceName = "Telecom", AvailableInMarket = true }
                );

            context.ContractedServiceConfigurations.AddOrUpdate(
             p => p.ContractedServiceConfigurationId,
             new Models.ContractedServiceConfiguration {ContractedServiceConfigurationId=1,  ExchangeServiceId = 1},
              new Models.ContractedServiceConfiguration { ContractedServiceConfigurationId = 2, ExchangeServiceId = 2 },
               new Models.ContractedServiceConfiguration { ContractedServiceConfigurationId = 3, ExchangeServiceId = 3 },
                new Models.ContractedServiceConfiguration { ContractedServiceConfigurationId = 4, ExchangeServiceId = 4 }


             );

            context.BlockChainAccounts.AddOrUpdate(
                p=> p.BlockChainAccountId,
                new Models.BlockChainAccount
                {
                    BlockChainAccountId = 1,
                    AccountName = "Origin Account",
                    AccountAddress = "0x7fbe93bc104ac4bcae5d643fd3747e1866f1ece4",
                    AccountPassword = "Admin-si@123456"
                }
                );

            context.SmartContracts.AddOrUpdate(
                p => p.SmartContractId,
                    new Models.SmartContract {
                        SmartContractId = 1,
                        ContractName = "InvoiceControl",
                        BlockChainAccountId = 1,
                        ContractByteCode = "60606040526002600260006101000a81548160ff021916908360ff1602179055503461000057604051610988380380610988833981016040528080519060200190919080518201919060200180519060200190919080518201919060200180518201919050505b33600060006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555042600181905550846003600001819055508360036001019080519060200190828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061010757805160ff1916838001178555610135565b82800160010185558215610135579182015b82811115610134578251825591602001919060010190610119565b5b50905061015a91905b8082111561015657600081600090555060010161013e565b5090565b5050826003600201819055508160036003019080519060200190828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106101b557805160ff19168380011785556101e3565b828001600101855582156101e3579182015b828111156101e25782518255916020019190600101906101c7565b5b50905061020891905b808211156102045760008160009055506001016101ec565b5090565b50508060036004019080519060200190828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061025957805160ff1916838001178555610287565b82800160010185558215610287579182015b8281111561028657825182559160200191906001019061026b565b5b5090506102ac91905b808211156102a8576000816000905550600101610290565b5090565b50505b50505050505b6106c4806102c46000396000f30060606040526000357c0100000000000000000000000000000000000000000000000000000000900463ffffffff16806336f281a91461006a578063b3c3dd471461022f578063c0fc823b146102a1578063cb0fbf3014610337578063e1725c921461035a575b610000565b3461000057610077610383565b604051808681526020018060200185815260200180602001806020018481038452888181546001816001161561010002031660029004815260200191508054600181600116156101000203166002900480156101145780601f106100e957610100808354040283529160200191610114565b820191906000526020600020905b8154815290600101906020018083116100f757829003601f168201915b50508481038352868181546001816001161561010002031660029004815260200191508054600181600116156101000203166002900480156101975780601f1061016c57610100808354040283529160200191610197565b820191906000526020600020905b81548152906001019060200180831161017a57829003601f168201915b505084810382528581815460018160011615610100020316600290048152602001915080546001816001161561010002031660029004801561021a5780601f106101ef5761010080835404028352916020019161021a565b820191906000526020600020905b8154815290600101906020018083116101fd57829003601f168201915b50509850505050505050505060405180910390f35b346100005761029f600480803590602001909190803590602001909190803590602001908201803590602001908080601f016020809104026020016040519081016040528093929190818152602001838380828437820191505050505050919080359060200190919050506103a4565b005b3461000057610335600480803590602001909190803590602001908201803590602001908080601f01602080910402602001604051908101604052809392919081815260200183838082843782019150505050505091908035906020019091908035906020019091908035906020019091908035906020019091908035906020019091908035906020019091905050610501565b005b346100005761034461067a565b6040518082815260200191505060405180910390f35b3461000057610367610685565b604051808260ff1660ff16815260200191505060405180910390f35b60038060000154908060010190806002015490806003019080600401905085565b60006000600060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561040457610000565b600960008781526020019081526020016000209150816009016000836008016000815480929190600101919050558152602001908152602001600020905084816000018190555083816001019080519060200190828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f1061049957805160ff19168380011785556104c7565b828001600101855582156104c7579182015b828111156104c65782518255916020019190600101906104ab565b5b5090506104ec91905b808211156104e85760008160009055506001016104d0565b5090565b50508281600201819055505b5b505050505050565b6000600060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614151561055f57610000565b600960008a81526020019081526020016000209050600860008154809291906001019190505560088190555088816000018190555087816001019080519060200190828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106105e257805160ff1916838001178555610610565b82800160010185558215610610579182015b8281111561060f5782518255916020019190600101906105f4565b5b50905061063591905b80821115610631576000816000905550600101610619565b5090565b50508681600201819055508581600301819055508481600401819055508381600501819055508281600601819055504281600701819055505b5b505050505050505050565b600060085490505b90565b600260009054906101000a900460ff16815600a165627a7a723058204f07e2934c049ce2cd595ba35129440440d4f7dce94639f7ba8969d913cba8560029",
                        ContractAbi = @"[{ ""constant"":true, ""inputs"":[],
                        ""name"":""companyInfo"",
                        ""outputs"":[{ ""name"":""companyId"",""type"":""int256""},
                        { ""name"":""companyName"",""type"":""string""},{ ""name"":""vatNumber"",""type"":""int256""},
                        { ""name"":""kvkNumber"",""type"":""string""},{ ""name"":""iban"",""type"":""string""}],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_invoiceId"",""type"":""uint256""},{""name"":""_serviceId"",""type"":""uint256""},{""name"":""_serviceName"",""type"":""string""},{""name"":""_value"",""type"":""int256""}],""name"":""addPaymentDivision"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[{""name"":""_invoiceId"",""type"":""uint256""},{""name"":""_customerName"",""type"":""string""},{""name"":""_customerVatNumber"",""type"":""int256""},{""name"":""_invoiceValue"",""type"":""int256""},{""name"":""_invoiceVatValue"",""type"":""int256""},{""name"":""_issueDate"",""type"":""uint256""},{""name"":""_dueDate"",""type"":""uint256""},{""name"":""_createdDate"",""type"":""uint256""}],""name"":""addInvoice"",""outputs"":[],""payable"":false,""type"":""function""},{""constant"":false,""inputs"":[],""name"":""numberOfInvoices"",""outputs"":[{""name"":""retVal"",""type"":""uint256""}],""payable"":false,""type"":""function""},{""constant"":true,""inputs"":[],""name"":""decimalPlaces"",""outputs"":[{""name"":"""",""type"":""uint8""}],""payable"":false,""type"":""function""},{""inputs"":[{""name"":""_companyId"",""type"":""int256""},{""name"":""_companyName"",""type"":""string""},{""name"":""_vatNumber"",""type"":""int256""},{""name"":""_kvkNumber"",""type"":""string""},{""name"":""_iban"",""type"":""string""}],""payable"":false,
                        ""type"":""constructor""}]"

                    } 
                );

            context.Customers.AddOrUpdate(
                p => p.CustomerId,
                new Models.Customer { CustomerId=1, CustomerName = "Lab 15", CustomerVatNumber = 11111111, CustomerEmail="filipe@six-factor.com" },
                new Models.Customer { CustomerId=2, CustomerName = "Six Factor", CustomerVatNumber = 513667601, CustomerEmail = "ivo@six-factor.com" }
                );

        }
    }
}

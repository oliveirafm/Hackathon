using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Hackathon.Models;

namespace Hackathon.Services
{
    public class InvoiceControlContractService : BaseService
    {
        private const int smartContractId = 4;
        private ApplicationDbContext db = new ApplicationDbContext();

        private Contract contract;

        private string abi = @"[{""constant"":false,""inputs"":[{""name"":""val"",""type"":""int256""}],""name"":""multiply"",""outputs"":[{""name"":""d"",""type"":""int256""}],""type"":""function""},{""inputs"":[{""name"":""multiplier"",""type"":""int256""}],""type"":""constructor""}]";

        private string contractAddress;

        public InvoiceControlContractService(string senderAddress, string senderPassword)
        {
            this.senderAddress = senderAddress;
            this.senderPassword = senderPassword;
            InitContract();
        }

        public InvoiceControlContractService(string senderAddress, string senderPassword, Web3 web3)
        {
            this.senderAddress = senderAddress;
            this.senderPassword = senderPassword;
            this.web3 = web3;
            InitContract();
        }

        private void InitContract()
        {
            var smartContract = db.SmartContracts.Find(smartContractId);

            contractAddress = smartContract.ContractAddress;
            abi = smartContract.ContractAbi;

            contract = web3.Eth.GetContract(abi, contractAddress);
        }

        public void SetContract(Contract contract)
        {
            this.contract = contract;
        }


        public async Task<int> Multiply(int value)
        {
            var multiplyFunction = contract.GetFunction("multiply");

            var result = await multiplyFunction.CallAsync<int>(value);

            return result;
        }

    }
}
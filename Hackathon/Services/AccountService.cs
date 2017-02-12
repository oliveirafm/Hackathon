using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Hackathon.Services
{
    public class AccountService : BaseService
    {

        //public string passPhrase = "ThE~Bl0ckch@in-P@ssW0rd";


        public AccountService()
        {
        }

        public AccountService(Web3 web3)
        {
            this.web3 = web3;
        }

        public async Task<string> NewAccount()
        {
            var accountAddress = await web3.Personal.NewAccount.SendRequestAsync(this.passPhrase);

            return accountAddress;
        }

        public async Task<string> NewAccount(string passPhrase)
        {
            var accountAddress = await web3.Personal.NewAccount.SendRequestAsync(passPhrase);

            return accountAddress;
        }

        public async Task<List<string>> GetAccountAddressesList()
        {
            var accountAddresses = await web3.Personal.ListAccounts.SendRequestAsync();

            //var accountAddresses = await web3.Eth.Accounts.SendRequestAsync();

            return accountAddresses.ToList();
        }



    }
}
using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Hackathon.Models;

namespace Hackathon.Services
{
    public class BaseService
    {
        private string defaultServerAddress = ConfigurationManager.AppSettings["EthereumServerAddress"].ToString();

        protected ApplicationDbContext db = new ApplicationDbContext();

        protected string serverAddress;
        protected string senderAddress;
        protected string senderPassword;

        protected Web3 web3;

        public BaseService()
        {
            try
            {
                web3 = new Web3(defaultServerAddress);
            }
            catch
            {
            }
        }

        protected static class Assert
        {
            public static void True(bool test)
            {
                if (!test)
                {
                    throw new Exception("Result was False!");
                }
            }

        }

    }
}
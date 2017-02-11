using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon.Models
{
    public class BlockChainServer
    {
        public int BlockChainServerId { get; set; }

        public string ServerName { get; set; }
        public string serverAddress { get; set; }

        public string MinerHashrate { get; private set; }
        public string MinerSetGasPrice { get; private set; }
        public bool MinerRunningStatus { get; private set; }

        public bool SelectedServer { get; private set; }
    }
}
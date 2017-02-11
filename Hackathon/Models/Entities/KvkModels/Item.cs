using System;
using System.Collections.Generic;
using WebApplication1.Models;

namespace Hackathon.Models
{
    public class Item
    {
        public string kvkNumber { get; set; }
        public string branchNumber { get; set; }
        public string rsin { get; set; }
        public TradeNames tradeNames { get; set; }
        public string legalForm { get; set; }
        public List<BusinessActivity> businessActivities { get; set; }
        public bool hasEntryInBusinessRegister { get; set; }
        public bool hasCommercialActivities { get; set; }
        public bool hasNonMailingIndication { get; set; }
        public bool isLegalPerson { get; set; }
        public bool isBranch { get; set; }
        public bool isMainBranch { get; set; }
        public int employees { get; set; }
        public string foundationDate { get; set; }
        public string registrationDate { get; set; }
        public List<Address> addresses { get; set; }
        public string vatNumber
        {
            get
            {
                if (_vatNumber == "")
                {
                    _vatNumber = GenerateNumber().ToString();
                }
                return _vatNumber;
            }
        }

        private string _vatNumber = "";
        private int GenerateNumber()
        {
            Random random = new Random();
            string r = "";
            int i;
            for (i = 1; i < 9; i++)
            {
                r += random.Next(0, 9).ToString();
            }
            return Convert.ToInt32(r);
        }

    }
}
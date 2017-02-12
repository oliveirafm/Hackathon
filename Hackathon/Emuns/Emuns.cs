using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon
{
    public enum valueType { Value, Percentage };


    public enum Country { Austria, Belgium, Bulgaria, Croatia, RepublicOfCyprus, CzechRepublic, Denmark, Estonia, Finland, France, Germany, Greece, Hungary, Ireland, Italy, Latvia, Lithuania, Luxembourg, Malta, Netherlands, Poland, Portugal, Romania, Slovakia, Slovenia, Spain, Sweden, UnitedKingdom }

    public enum CompanyActivityType { VatRefundable, NotVatRefundable }

    public enum CompanySectorType { Undefined, Industry, Consulting, Auditing, Banking, Financial, Retail, Construction, RealEstate, Services, IT }

    public enum InvoiceStatus { Sent, Paid }

}
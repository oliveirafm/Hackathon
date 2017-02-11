using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon
{

    public enum Country { Austria, Belgium, Bulgaria, Croatia, RepublicOfCyprus, CzechRepublic, Denmark, Estonia, Finland, France, Germany, Greece, Hungary, Ireland, Italy, Latvia, Lithuania, Luxembourg, Malta, Netherlands, Poland, Portugal, Romania, Slovakia, Slovenia, Spain, Sweden, UnitedKingdom }

    public enum BankMovementType { Deposit, Withdraw }

    public enum CompanyActivityType { VatRefundable, NotVatRefundable }

    public enum CompanySectorType { Undefined, Industry, Consulting, Auditing, Banking, Financial, Retail, Construction, RealEstate, Services, IT }

    public enum InvoiceDirection { Out, In }

    public enum InvoiceStatus { Dispatched, Paid, Rejected }

    public enum MasterContractStatus { Active, Spent, Revoked }

    public enum TenderStatus { Created, Sent, Answered, Approved, Accepted, Rejected }

    public enum PurchaseOrderStatus { Created, Sent, InProduction, InProductionQualityCheck, InDelivery, InDeliveryQualityCheck, Rejected, Accepted, ApprovedWithFaults }

    public enum ProductColor { White, Black, Red, Blue, Yellow, Green, Purple, Orange }

    public enum CompanyPoc2DepartmentName { Administration, Purchasing, Sales, HumanResources, Warehouse, Production, Accounting }

    public enum CompanyPoc3DepartmentName { Administration, FundManagement, InvestmentServices, Operations, Accounting, Legal }

    public enum PropertySector { Office, Residenctial, Industry }

    public enum UnitUseType { Office, Industry, Mezzanine }

    public enum MemoStatus { Todo, Done }

    public enum MarketAssetRequestStatus { Sent, Accepted, Rejected, Deleted }

}
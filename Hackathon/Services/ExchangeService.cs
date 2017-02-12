using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;
using System.Data.Entity;
using System.Data;
using Microsoft.AspNet.Identity;
using Hackathon.Services;
using System.Threading;

namespace Hackathon.Services
{
    public class ExchangeService
    {
        protected ApplicationDbContext db = new ApplicationDbContext();

        public void processPayment(int invoiceId, double ammountPaid)
        {
            var invoice = db.Invoices.Include(p=>p.PaymentDivisions).Where(p=> p.InvoiceId == invoiceId).FirstOrDefault();
            ExchangeAccountMovement eacSource = new ExchangeAccountMovement()
            {
                ExchangeAccountId = invoice.ExchangeAccountId,
                InvoiceId = invoice.InvoiceId,
                AmountDeposit = (decimal)invoice.InvoiceValue,
                SourceDeposit = invoice.Customer.CustomerName,
                TransactionDate = DateTime.Now,
                CompanyId = invoice.IssuerCompanyId,

            };
            db.ExchangeAccountMovements.Add(eacSource);
            decimal acumullatedOut = (decimal)invoice.InvoiceValue;
            foreach (var item in invoice.PaymentDivisions)
            {
                acumullatedOut -= (decimal)item.Value;
                ExchangeAccountMovement eac = new ExchangeAccountMovement()
                {
                    ExchangeAccountId = invoice.ExchangeAccountId,
                    InvoiceId = invoice.InvoiceId,
                    AmountWithdrawal = (decimal)item.Value,
                    DestinationWithdrawal = item.ContractedServiceConfiguration.ExchangeService.ExchangeServiceName,
                    ExchangeServiceId = item.ContractedServiceConfiguration.ExchangeServiceId,
                    TransactionDate = DateTime.Now,
                    CompanyId = invoice.IssuerCompanyId,
                    ContractedServiceConfigurationId = item.ContractedServiceConfigurationId
                };

                db.ExchangeAccountMovements.Add(eac);
            }
            ExchangeAccountMovement eacTax = new ExchangeAccountMovement();

            eacTax.ExchangeAccountId = invoice.ExchangeAccountId;
                eacTax.InvoiceId = invoice.InvoiceId;
                eacTax.AmountWithdrawal = (decimal)invoice.ProductVatValue;
                eacTax.DestinationWithdrawal = "Taxation Authorities";
                eacTax.TransactionDate = DateTime.Now;
            eacTax.CompanyId = invoice.IssuerCompanyId;
            acumullatedOut -= (decimal)invoice.ProductVatValue;
            db.ExchangeAccountMovements.Add(eacTax);
            ExchangeAccountMovement eacBank = new ExchangeAccountMovement();

            eacBank.ExchangeAccountId = invoice.ExchangeAccountId;
            eacBank.InvoiceId = invoice.InvoiceId;
            eacBank.AmountWithdrawal = acumullatedOut;
            eacBank.DestinationWithdrawal = "Bank Current Account";
            eacBank.TransactionDate = DateTime.Now;
            eacBank.CompanyId = invoice.IssuerCompanyId;
           


            db.ExchangeAccountMovements.Add(eacBank);
            db.SaveChanges();


        }

    }
}
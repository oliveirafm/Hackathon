using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;
using Hackathon.Services;
using System.Threading;

namespace Hackathon.Controllers
{
    public class InvoicesController : BaseController
    {
       

        // GET: Invoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.ExchangeAccount).Include(i => i.IssuerCompany).Where(p => p.IssuerCompanyId == currentExchangeAccount.CompanyId);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // GET: Invoices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            

            var invoice = new Invoice();
            invoice.ExchangeAccountId = currentExchangeAccount.ExchangeAccountId;
            invoice.IssuerVatNumber = currentExchangeAccount.Company.VatNumber;
            invoice.IssuerCompany = currentExchangeAccount.Company;
            invoice.IssuerCompanyId = currentExchangeAccount.CompanyId;
            invoice.IssueDate = DateTime.Now;
            invoice.DueDate = DateTime.Now.AddMonths(1);
            invoice.ProductVatPercentage = 21;


            return View(invoice);
        }

        // POST: Invoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,ExchangeAccountId,IssuerVatNumber,IssuerCompanyId,IssueDateTimestamp,IssueDate,DueDateTimestamp,DueDate,PaymentService,PaymentValue,PaymentServiceHours,ProductVatPercentage,ProductVatValue,CustomerName,CustomerVatNumber,CustomerId,InvoiceValue,InvoiceVatValue,InvoiceVatPercentage,InvoiceStatus")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                AddInvoiceToBlockchain(invoice);

                DiversificationPlan dp = db.DiversificationPlans.Include(dx => dx.Itens).Where(x => x.CompanyId == currentExchangeAccount.CompanyId).FirstOrDefault();
                foreach (DiversificationPlanItem item in dp.Itens)
                {
                    InvoicePaymentDivision invoicePD = new InvoicePaymentDivision();
                    invoicePD.Invoice = invoice;
                    invoicePD.Value = (double)invoice.PaymentValue * item.Value / 100;
                    invoicePD.ContractedServiceConfiguration = db.ContractedServiceConfigurations.Where(p => p.ExchangeServiceId == item.ExchangeServiceId).FirstOrDefault();
                    invoicePD.ContractedServiceConfigurationId = invoicePD.ContractedServiceConfiguration.ContractedServiceConfigurationId;
                    invoice.PaymentDivisions.Add(invoicePD);

                    AddPaymentDivisionToBlockchain(invoicePD);
                } 
                       
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", invoice.ExchangeAccountId);
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", invoice.IssuerCompanyId);
            return View(invoice);
        }

        private void AddInvoiceToBlockchain(Invoice invoice)
        {
            var blockChainContract = db.SmartContracts.Find(1);
            var bcAccount = db.BlockChainAccounts.Find(1);
            var service = new InvoiceControlContractService(bcAccount.AccountAddress, bcAccount.AccountPassword);

            new Thread(async () =>
            {
                await service.addInvoice((uint)invoice.InvoiceId, invoice.Customer.CustomerName, (int)invoice.CustomerVatNumber, (decimal)invoice.PaymentValue,
                                         (decimal)invoice.ProductVatValue, (DateTime)invoice.IssueDate, (DateTime)invoice.DueDate, DateTime.Now);
            }).Start();
        }
        private void AddPaymentDivisionToBlockchain(InvoicePaymentDivision invoicePD)
        {
            var blockChainContract = db.SmartContracts.Find(1);
            var bcAccount = db.BlockChainAccounts.Find(1);
            var service = new InvoiceControlContractService(bcAccount.AccountAddress, bcAccount.AccountPassword);

            new Thread(async () =>
            {
                await service.addPaymentDivision((uint)invoicePD.InvoiceId, (uint)invoicePD.ContractedServiceConfiguration.ExchangeServiceId, 
                                                 invoicePD.ContractedServiceConfiguration.ExchangeService.ExchangeServiceName, (decimal)invoicePD.Value);
            }).Start();
        }

        // GET: Invoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", invoice.ExchangeAccountId);
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", invoice.IssuerCompanyId);
            return View(invoice);
        }

        // POST: Invoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoiceId,ExchangeAccountId,IssuerVatNumber,IssuerCompanyId,IssueDateTimestamp,IssueDate,DueDateTimestamp,DueDate,PaymentService,PaymentValue,PaymentServiceHours,ProductVatPercentage,ProductVatValue,CustomerName,CustomerVatNumber,CustomerId,InvoiceValue,InvoiceVatValue,InvoiceVatPercentage,InvoiceStatus")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", invoice.ExchangeAccountId);
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", invoice.IssuerCompanyId);
            return View(invoice);
        }

        // GET: Invoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Invoice invoice = db.Invoices.Find(id);
            if (invoice == null)
            {
                return HttpNotFound();
            }
            return View(invoice);
        }

        // POST: Invoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Invoice invoice = db.Invoices.Find(id);
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        [HttpGet]
        public ActionResult UpdateCustomerVatNumber(int? id)
        {

            if (HttpContext.Request.IsAjaxRequest())
            {
                var customer = db.Customers.Where(w => w.CustomerId == id).FirstOrDefault();
                return Json(customer, JsonRequestBehavior.AllowGet);
            }
            return View();
        }
    }


}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;

namespace Hackathon.Controllers.CRUDs
{
    public class TblExchangeAccountMovementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblExchangeAccountMovements
        public ActionResult Index()
        {
            var exchangeAccountMovements = db.ExchangeAccountMovements.Include(e => e.Company).Include(e => e.ContractedServiceConfiguration).Include(e => e.DiversificationPlanItem).Include(e => e.ExchangeAccount).Include(e => e.ExchangeService).Include(e => e.SourceInvoice);
            return View(exchangeAccountMovements.ToList());
        }

        // GET: TblExchangeAccountMovements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccountMovement exchangeAccountMovement = db.ExchangeAccountMovements.Find(id);
            if (exchangeAccountMovement == null)
            {
                return HttpNotFound();
            }
            return View(exchangeAccountMovement);
        }

        // GET: TblExchangeAccountMovements/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1");
            ViewBag.DiversificationPlanItemId = new SelectList(db.DiversificationPlanItems, "DiversificationPlanItemId", "Observations");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService");
            return View();
        }

        // POST: TblExchangeAccountMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExchangeAccountMovementId,ExchangeAccountId,InvoiceId,CompanyId,TransactionDate,AmountDeposit,SourceDeposit,DiversificationPlanItemId,AmountWithdrawal,DestinationWithdrawal,ExchangeServiceId,ContractedServiceConfigurationId")] ExchangeAccountMovement exchangeAccountMovement)
        {
            if (ModelState.IsValid)
            {
                db.ExchangeAccountMovements.Add(exchangeAccountMovement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccountMovement.CompanyId);
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", exchangeAccountMovement.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanItemId = new SelectList(db.DiversificationPlanItems, "DiversificationPlanItemId", "Observations", exchangeAccountMovement.DiversificationPlanItemId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", exchangeAccountMovement.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", exchangeAccountMovement.ExchangeServiceId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", exchangeAccountMovement.InvoiceId);
            return View(exchangeAccountMovement);
        }

        // GET: TblExchangeAccountMovements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccountMovement exchangeAccountMovement = db.ExchangeAccountMovements.Find(id);
            if (exchangeAccountMovement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccountMovement.CompanyId);
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", exchangeAccountMovement.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanItemId = new SelectList(db.DiversificationPlanItems, "DiversificationPlanItemId", "Observations", exchangeAccountMovement.DiversificationPlanItemId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", exchangeAccountMovement.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", exchangeAccountMovement.ExchangeServiceId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", exchangeAccountMovement.InvoiceId);
            return View(exchangeAccountMovement);
        }

        // POST: TblExchangeAccountMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExchangeAccountMovementId,ExchangeAccountId,InvoiceId,CompanyId,TransactionDate,AmountDeposit,SourceDeposit,DiversificationPlanItemId,AmountWithdrawal,DestinationWithdrawal,ExchangeServiceId,ContractedServiceConfigurationId")] ExchangeAccountMovement exchangeAccountMovement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangeAccountMovement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccountMovement.CompanyId);
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", exchangeAccountMovement.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanItemId = new SelectList(db.DiversificationPlanItems, "DiversificationPlanItemId", "Observations", exchangeAccountMovement.DiversificationPlanItemId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", exchangeAccountMovement.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", exchangeAccountMovement.ExchangeServiceId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", exchangeAccountMovement.InvoiceId);
            return View(exchangeAccountMovement);
        }

        // GET: TblExchangeAccountMovements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccountMovement exchangeAccountMovement = db.ExchangeAccountMovements.Find(id);
            if (exchangeAccountMovement == null)
            {
                return HttpNotFound();
            }
            return View(exchangeAccountMovement);
        }

        // POST: TblExchangeAccountMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExchangeAccountMovement exchangeAccountMovement = db.ExchangeAccountMovements.Find(id);
            db.ExchangeAccountMovements.Remove(exchangeAccountMovement);
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
    }
}

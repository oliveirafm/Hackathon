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
    public class TblInvoicePaymentDivisionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblInvoicePaymentDivisions
        public ActionResult Index()
        {
            var invoicePaymentDivisions = db.InvoicePaymentDivisions.Include(i => i.ContractedServiceConfiguration).Include(i => i.Invoice);
            return View(invoicePaymentDivisions.ToList());
        }

        // GET: TblInvoicePaymentDivisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoicePaymentDivision invoicePaymentDivision = db.InvoicePaymentDivisions.Find(id);
            if (invoicePaymentDivision == null)
            {
                return HttpNotFound();
            }
            return View(invoicePaymentDivision);
        }

        // GET: TblInvoicePaymentDivisions/Create
        public ActionResult Create()
        {
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1");
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService");
            return View();
        }

        // POST: TblInvoicePaymentDivisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoicePaymentDivisionId,InvoiceId,Value,ContractedServiceConfigurationId")] InvoicePaymentDivision invoicePaymentDivision)
        {
            if (ModelState.IsValid)
            {
                db.InvoicePaymentDivisions.Add(invoicePaymentDivision);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", invoicePaymentDivision.ContractedServiceConfigurationId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", invoicePaymentDivision.InvoiceId);
            return View(invoicePaymentDivision);
        }

        // GET: TblInvoicePaymentDivisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoicePaymentDivision invoicePaymentDivision = db.InvoicePaymentDivisions.Find(id);
            if (invoicePaymentDivision == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", invoicePaymentDivision.ContractedServiceConfigurationId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", invoicePaymentDivision.InvoiceId);
            return View(invoicePaymentDivision);
        }

        // POST: TblInvoicePaymentDivisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InvoicePaymentDivisionId,InvoiceId,Value,ContractedServiceConfigurationId")] InvoicePaymentDivision invoicePaymentDivision)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoicePaymentDivision).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", invoicePaymentDivision.ContractedServiceConfigurationId);
            ViewBag.InvoiceId = new SelectList(db.Invoices, "InvoiceId", "PaymentService", invoicePaymentDivision.InvoiceId);
            return View(invoicePaymentDivision);
        }

        // GET: TblInvoicePaymentDivisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoicePaymentDivision invoicePaymentDivision = db.InvoicePaymentDivisions.Find(id);
            if (invoicePaymentDivision == null)
            {
                return HttpNotFound();
            }
            return View(invoicePaymentDivision);
        }

        // POST: TblInvoicePaymentDivisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoicePaymentDivision invoicePaymentDivision = db.InvoicePaymentDivisions.Find(id);
            db.InvoicePaymentDivisions.Remove(invoicePaymentDivision);
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

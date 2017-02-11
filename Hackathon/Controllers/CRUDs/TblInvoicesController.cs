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
    public class TblInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblInvoices
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.ExchangeAccount).Include(i => i.IssuerCompany);
            return View(invoices.ToList());
        }

        // GET: TblInvoices/Details/5
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

        // GET: TblInvoices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: TblInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InvoiceId,ExchangeAccountId,IssuerVatNumber,IssuerCompanyId,IssueDateTimestamp,IssueDate,DueDateTimestamp,DueDate,PaymentService,PaymentValue,PaymentServiceHours,ProductVatPercentage,ProductVatValue,CustomerName,CustomerVatNumber,CustomerId,InvoiceValue,InvoiceVatValue,InvoiceVatPercentage,InvoiceStatus")] Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                db.Invoices.Add(invoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "CustomerName", invoice.CustomerId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", invoice.ExchangeAccountId);
            ViewBag.IssuerCompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", invoice.IssuerCompanyId);
            return View(invoice);
        }

        // GET: TblInvoices/Edit/5
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

        // POST: TblInvoices/Edit/5
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

        // GET: TblInvoices/Delete/5
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

        // POST: TblInvoices/Delete/5
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
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;

namespace Hackathon.Controllers
{
    public class ToPayController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToPay
        public ActionResult Index()
        {
            var invoices = db.Invoices.Include(i => i.Customer).Include(i => i.ExchangeAccount).Include(i => i.IssuerCompany).Where(i=> i.InvoiceStatus == InvoiceStatus.Sent);
            return View(invoices.ToList());
        }

        // GET: Invoices/Details/5
        public ActionResult Pay(int? id)
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


            invoice.InvoiceStatus = InvoiceStatus.Paid;

            db.SaveChanges();

            Services.ExchangeService ec = new Services.ExchangeService();
            ec.processPayment(invoice.InvoiceId,(double)invoice.InvoiceValue);

            return RedirectToAction("Index");
        }

        /*
        // POST: TblCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IBAN,InvoiceNumber,Ammount")] ToPayViewModel toPay)
        {


            if (ModelState.IsValid)
            {
                Invoice invoice = db.Invoices.Where( k => k.Customer.Company.IBAN == toPay.IBAN 
                                            &&  k.InvoiceId.ToString() == toPay.InvoiceNumber 
                                            && toPay.Ammount == (k.InvoiceValue + k.InvoiceVatValue)).FirstOrDefault();
                if (invoice == null)
                {
                    ModelState.Clear();
                    ModelState.AddModelError(string.Empty, "Invalid data.");
                    return View();
                }

                invoice.InvoiceStatus = InvoiceStatus.Paid;
                

                db.Invoices.Add(invoice);
                db.SaveChanges();

                // TODO EXCGANGE TO SPLIT
                return RedirectToAction("Index");
            }

            return View(toPay);
        }
*/
    }
}
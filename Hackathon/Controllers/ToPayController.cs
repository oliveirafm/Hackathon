using Hackathon.Models;
using Hackathon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Controllers
{
    public class ToPayController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ToPay
        public ActionResult Index()
        {
            return View();
        }

        // POST: TblCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "IBAN,InvoiceNumber,Ammount")] ToPayViewModel toPay)
        {


            if (ModelState.IsValid)
            {
                /*
                Company company = db.Companies.Where(w => w.IBAN == toPay.IBAN).FirstOrDefault();
                if (company==null)
                {
                    return View();
                }
                */

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
    }
}
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
    public class TblCustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblCustomers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Company).Include(c => c.ExchangeAccount);
            return View(customers.ToList());
        }

        // GET: TblCustomers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: TblCustomers/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            return View();
        }

        // POST: TblCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerId,ExchangeAccountId,CompanyId,CustomerName,CustomerVatNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", customer.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", customer.ExchangeAccountId);
            return View(customer);
        }

        // GET: TblCustomers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", customer.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", customer.ExchangeAccountId);
            return View(customer);
        }

        // POST: TblCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerId,ExchangeAccountId,CompanyId,CustomerName,CustomerVatNumber")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", customer.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", customer.ExchangeAccountId);
            return View(customer);
        }

        // GET: TblCustomers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: TblCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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

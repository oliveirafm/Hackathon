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
    public class TblBankAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblBankAccounts
        public ActionResult Index()
        {
            var bankAccounts = db.BankAccounts.Include(b => b.Company).Include(b => b.ExchangeAccount);
            return View(bankAccounts.ToList());
        }

        // GET: TblBankAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // GET: TblBankAccounts/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            return View();
        }

        // POST: TblBankAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankAccountId,ExchangeAccountId,CompanyId,OwnerCompanyName,AccountBalance,IssuerCompanyActivityCountry,currentYearPensionRetained,accumulatedPensionSavings,currentYearTaxRetained,currentYearRentingRetained")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.BankAccounts.Add(bankAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankAccount.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankAccount.ExchangeAccountId);
            return View(bankAccount);
        }

        // GET: TblBankAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankAccount.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankAccount.ExchangeAccountId);
            return View(bankAccount);
        }

        // POST: TblBankAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankAccountId,ExchangeAccountId,CompanyId,OwnerCompanyName,AccountBalance,IssuerCompanyActivityCountry,currentYearPensionRetained,accumulatedPensionSavings,currentYearTaxRetained,currentYearRentingRetained")] BankAccount bankAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankAccount.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankAccount.ExchangeAccountId);
            return View(bankAccount);
        }

        // GET: TblBankAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankAccount bankAccount = db.BankAccounts.Find(id);
            if (bankAccount == null)
            {
                return HttpNotFound();
            }
            return View(bankAccount);
        }

        // POST: TblBankAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankAccount bankAccount = db.BankAccounts.Find(id);
            db.BankAccounts.Remove(bankAccount);
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

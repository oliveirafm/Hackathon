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
    public class TblBankMovementsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblBankMovements
        public ActionResult Index()
        {
            var bankMovements = db.BankMovements.Include(b => b.Company).Include(b => b.ExchangeAccount);
            return View(bankMovements.ToList());
        }

        // GET: TblBankMovements/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankMovement bankMovement = db.BankMovements.Find(id);
            if (bankMovement == null)
            {
                return HttpNotFound();
            }
            return View(bankMovement);
        }

        // GET: TblBankMovements/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            return View();
        }

        // POST: TblBankMovements/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BankMovementId,ExchangeAccountId,CompanyId,TransactionDate,AmountDeposit,SourceDeposit,SourceDepositRef,AmountWithdrawal,DestinationWithdrawal,DestinationWithdrawalRef")] BankMovement bankMovement)
        {
            if (ModelState.IsValid)
            {
                db.BankMovements.Add(bankMovement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankMovement.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankMovement.ExchangeAccountId);
            return View(bankMovement);
        }

        // GET: TblBankMovements/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankMovement bankMovement = db.BankMovements.Find(id);
            if (bankMovement == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankMovement.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankMovement.ExchangeAccountId);
            return View(bankMovement);
        }

        // POST: TblBankMovements/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BankMovementId,ExchangeAccountId,CompanyId,TransactionDate,AmountDeposit,SourceDeposit,SourceDepositRef,AmountWithdrawal,DestinationWithdrawal,DestinationWithdrawalRef")] BankMovement bankMovement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bankMovement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", bankMovement.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", bankMovement.ExchangeAccountId);
            return View(bankMovement);
        }

        // GET: TblBankMovements/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BankMovement bankMovement = db.BankMovements.Find(id);
            if (bankMovement == null)
            {
                return HttpNotFound();
            }
            return View(bankMovement);
        }

        // POST: TblBankMovements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BankMovement bankMovement = db.BankMovements.Find(id);
            db.BankMovements.Remove(bankMovement);
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

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
    public class TblExchangeAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblExchangeAccounts
        public ActionResult Index()
        {
            var exchangeAccounts = db.ExchangeAccounts.Include(e => e.Company);
            return View(exchangeAccounts.ToList());
        }

        // GET: TblExchangeAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccount exchangeAccount = db.ExchangeAccounts.Find(id);
            if (exchangeAccount == null)
            {
                return HttpNotFound();
            }
            return View(exchangeAccount);
        }

        // GET: TblExchangeAccounts/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            return View();
        }

        // POST: TblExchangeAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExchangeAccountId,UserId,CompanyName,CompanyId")] ExchangeAccount exchangeAccount)
        {
            if (ModelState.IsValid)
            {
                db.ExchangeAccounts.Add(exchangeAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccount.CompanyId);
            return View(exchangeAccount);
        }

        // GET: TblExchangeAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccount exchangeAccount = db.ExchangeAccounts.Find(id);
            if (exchangeAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccount.CompanyId);
            return View(exchangeAccount);
        }

        // POST: TblExchangeAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExchangeAccountId,UserId,CompanyName,CompanyId")] ExchangeAccount exchangeAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangeAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", exchangeAccount.CompanyId);
            return View(exchangeAccount);
        }

        // GET: TblExchangeAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeAccount exchangeAccount = db.ExchangeAccounts.Find(id);
            if (exchangeAccount == null)
            {
                return HttpNotFound();
            }
            return View(exchangeAccount);
        }

        // POST: TblExchangeAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExchangeAccount exchangeAccount = db.ExchangeAccounts.Find(id);
            db.ExchangeAccounts.Remove(exchangeAccount);
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

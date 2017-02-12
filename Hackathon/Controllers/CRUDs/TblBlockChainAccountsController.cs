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
    public class TblBlockChainAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblBlockChainAccounts
        public ActionResult Index()
        {
            return View(db.BlockChainAccounts.ToList());
        }

        // GET: TblBlockChainAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockChainAccount blockChainAccount = db.BlockChainAccounts.Find(id);
            if (blockChainAccount == null)
            {
                return HttpNotFound();
            }
            return View(blockChainAccount);
        }

        // GET: TblBlockChainAccounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TblBlockChainAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BlockChainAccountId,AccountName,AccountAddress,AccountPassword")] BlockChainAccount blockChainAccount)
        {
            if (ModelState.IsValid)
            {
                db.BlockChainAccounts.Add(blockChainAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blockChainAccount);
        }

        // GET: TblBlockChainAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockChainAccount blockChainAccount = db.BlockChainAccounts.Find(id);
            if (blockChainAccount == null)
            {
                return HttpNotFound();
            }
            return View(blockChainAccount);
        }

        // POST: TblBlockChainAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BlockChainAccountId,AccountName,AccountAddress,AccountPassword")] BlockChainAccount blockChainAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blockChainAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blockChainAccount);
        }

        // GET: TblBlockChainAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlockChainAccount blockChainAccount = db.BlockChainAccounts.Find(id);
            if (blockChainAccount == null)
            {
                return HttpNotFound();
            }
            return View(blockChainAccount);
        }

        // POST: TblBlockChainAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlockChainAccount blockChainAccount = db.BlockChainAccounts.Find(id);
            db.BlockChainAccounts.Remove(blockChainAccount);
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

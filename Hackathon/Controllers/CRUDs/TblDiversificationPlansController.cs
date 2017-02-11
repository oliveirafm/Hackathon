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
    public class TblDiversificationPlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblDiversificationPlans
        public ActionResult Index()
        {
            var diversificationPlans = db.DiversificationPlans.Include(d => d.Company).Include(d => d.ExchangeAccount);
            return View(diversificationPlans.ToList());
        }

        // GET: TblDiversificationPlans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlan diversificationPlan = db.DiversificationPlans.Find(id);
            if (diversificationPlan == null)
            {
                return HttpNotFound();
            }
            return View(diversificationPlan);
        }

        // GET: TblDiversificationPlans/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName");
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            return View();
        }

        // POST: TblDiversificationPlans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiversificationPlanId,ExchangeAccountId,CompanyId,StartDate,EndDate,Observations")] DiversificationPlan diversificationPlan)
        {
            if (ModelState.IsValid)
            {
                db.DiversificationPlans.Add(diversificationPlan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", diversificationPlan.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", diversificationPlan.ExchangeAccountId);
            return View(diversificationPlan);
        }

        // GET: TblDiversificationPlans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlan diversificationPlan = db.DiversificationPlans.Find(id);
            if (diversificationPlan == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", diversificationPlan.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", diversificationPlan.ExchangeAccountId);
            return View(diversificationPlan);
        }

        // POST: TblDiversificationPlans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiversificationPlanId,ExchangeAccountId,CompanyId,StartDate,EndDate,Observations")] DiversificationPlan diversificationPlan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diversificationPlan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(db.Companies, "CompanyId", "CompanyName", diversificationPlan.CompanyId);
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", diversificationPlan.ExchangeAccountId);
            return View(diversificationPlan);
        }

        // GET: TblDiversificationPlans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlan diversificationPlan = db.DiversificationPlans.Find(id);
            if (diversificationPlan == null)
            {
                return HttpNotFound();
            }
            return View(diversificationPlan);
        }

        // POST: TblDiversificationPlans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiversificationPlan diversificationPlan = db.DiversificationPlans.Find(id);
            db.DiversificationPlans.Remove(diversificationPlan);
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

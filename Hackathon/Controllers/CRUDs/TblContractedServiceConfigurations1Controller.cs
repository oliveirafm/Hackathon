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
    public class TblContractedServiceConfigurations1Controller : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblContractedServiceConfigurations1
        public ActionResult Index()
        {
            var contractedServiceConfigurations = db.ContractedServiceConfigurations.Include(c => c.ExchangeAccount).Include(c => c.ExchangeService);
            return View(contractedServiceConfigurations.ToList());
        }

        // GET: TblContractedServiceConfigurations1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractedServiceConfiguration contractedServiceConfiguration = db.ContractedServiceConfigurations.Find(id);
            if (contractedServiceConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(contractedServiceConfiguration);
        }

        // GET: TblContractedServiceConfigurations1/Create
        public ActionResult Create()
        {
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId");
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName");
            return View();
        }

        // POST: TblContractedServiceConfigurations1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContractedServiceConfigurationId,ExchangeAccountId,ExchangeServiceId,ExchangeServiceParameter1,ExchangeServiceParameter2,ExchangeServiceParameter3,ExchangeServiceParameter4,ExchangeServiceParameter5")] ContractedServiceConfiguration contractedServiceConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.ContractedServiceConfigurations.Add(contractedServiceConfiguration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", contractedServiceConfiguration.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", contractedServiceConfiguration.ExchangeServiceId);
            return View(contractedServiceConfiguration);
        }

        // GET: TblContractedServiceConfigurations1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractedServiceConfiguration contractedServiceConfiguration = db.ContractedServiceConfigurations.Find(id);
            if (contractedServiceConfiguration == null)
            {
                return HttpNotFound();
            }
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", contractedServiceConfiguration.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", contractedServiceConfiguration.ExchangeServiceId);
            return View(contractedServiceConfiguration);
        }

        // POST: TblContractedServiceConfigurations1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContractedServiceConfigurationId,ExchangeAccountId,ExchangeServiceId,ExchangeServiceParameter1,ExchangeServiceParameter2,ExchangeServiceParameter3,ExchangeServiceParameter4,ExchangeServiceParameter5")] ContractedServiceConfiguration contractedServiceConfiguration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contractedServiceConfiguration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ExchangeAccountId = new SelectList(db.ExchangeAccounts, "ExchangeAccountId", "UserId", contractedServiceConfiguration.ExchangeAccountId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", contractedServiceConfiguration.ExchangeServiceId);
            return View(contractedServiceConfiguration);
        }

        // GET: TblContractedServiceConfigurations1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContractedServiceConfiguration contractedServiceConfiguration = db.ContractedServiceConfigurations.Find(id);
            if (contractedServiceConfiguration == null)
            {
                return HttpNotFound();
            }
            return View(contractedServiceConfiguration);
        }

        // POST: TblContractedServiceConfigurations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContractedServiceConfiguration contractedServiceConfiguration = db.ContractedServiceConfigurations.Find(id);
            db.ContractedServiceConfigurations.Remove(contractedServiceConfiguration);
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

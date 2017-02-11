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
    public class TblDiversificationPlanItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblDiversificationPlanItems
        public ActionResult Index()
        {
            var diversificationPlanItems = db.DiversificationPlanItems.Include(d => d.ContractedServiceConfiguration).Include(d => d.DiversificationPlan).Include(d => d.ExchangeService);
            return View(diversificationPlanItems.ToList());
        }

        // GET: TblDiversificationPlanItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlanItem diversificationPlanItem = db.DiversificationPlanItems.Find(id);
            if (diversificationPlanItem == null)
            {
                return HttpNotFound();
            }
            return View(diversificationPlanItem);
        }

        // GET: TblDiversificationPlanItems/Create
        public ActionResult Create()
        {
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1");
            ViewBag.DiversificationPlanId = new SelectList(db.DiversificationPlans, "DiversificationPlanId", "Observations");
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName");
            return View();
        }

        // POST: TblDiversificationPlanItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiversificationPlanItemId,DiversificationPlanId,Value,Type,Observations,ExchangeServiceId,ContractedServiceConfigurationId")] DiversificationPlanItem diversificationPlanItem)
        {
            if (ModelState.IsValid)
            {
                db.DiversificationPlanItems.Add(diversificationPlanItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", diversificationPlanItem.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanId = new SelectList(db.DiversificationPlans, "DiversificationPlanId", "Observations", diversificationPlanItem.DiversificationPlanId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", diversificationPlanItem.ExchangeServiceId);
            return View(diversificationPlanItem);
        }

        // GET: TblDiversificationPlanItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlanItem diversificationPlanItem = db.DiversificationPlanItems.Find(id);
            if (diversificationPlanItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", diversificationPlanItem.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanId = new SelectList(db.DiversificationPlans, "DiversificationPlanId", "Observations", diversificationPlanItem.DiversificationPlanId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", diversificationPlanItem.ExchangeServiceId);
            return View(diversificationPlanItem);
        }

        // POST: TblDiversificationPlanItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiversificationPlanItemId,DiversificationPlanId,Value,Type,Observations,ExchangeServiceId,ContractedServiceConfigurationId")] DiversificationPlanItem diversificationPlanItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diversificationPlanItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1", diversificationPlanItem.ContractedServiceConfigurationId);
            ViewBag.DiversificationPlanId = new SelectList(db.DiversificationPlans, "DiversificationPlanId", "Observations", diversificationPlanItem.DiversificationPlanId);
            ViewBag.ExchangeServiceId = new SelectList(db.ExchangeServices, "ExchangeServiceId", "ExchangeServiceName", diversificationPlanItem.ExchangeServiceId);
            return View(diversificationPlanItem);
        }

        // GET: TblDiversificationPlanItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiversificationPlanItem diversificationPlanItem = db.DiversificationPlanItems.Find(id);
            if (diversificationPlanItem == null)
            {
                return HttpNotFound();
            }
            return View(diversificationPlanItem);
        }

        // POST: TblDiversificationPlanItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DiversificationPlanItem diversificationPlanItem = db.DiversificationPlanItems.Find(id);
            db.DiversificationPlanItems.Remove(diversificationPlanItem);
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

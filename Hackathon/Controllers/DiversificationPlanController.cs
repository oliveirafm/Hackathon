using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;
using System.Net;
using System.Data.Entity;

namespace Hackathon.Controllers
{
    public class DiversificationPlanController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

  
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
            ViewBag.DiversificationPlanId = 1;
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

        

        // GET: TblDiversificationPlanItems
        public ActionResult Index()
        {

            //var diversificationPlanItems = db.DiversificationPlanItems.Include(d => d.ContractedServiceConfiguration).Include(d => d.DiversificationPlan).Include(d => d.ExchangeService).Where(p=> p. );
            DiversificationPlan diversificationPlan = (DiversificationPlan)db.DiversificationPlans.Where(p => p.CompanyId == currentExchangeAccount.CompanyId).FirstOrDefault();
            return View(diversificationPlan.Itens.ToList());
        }


        // GET: TblDiversificationPlanItems/Create
        public ActionResult Create()
        {
            ViewBag.ContractedServiceConfigurationId = new SelectList(db.ContractedServiceConfigurations, "ContractedServiceConfigurationId", "ExchangeServiceParameter1");
            ViewBag.DiversificationPlanId = 1; //new SelectList(db.DiversificationPlans, "DiversificationPlanId", "Observations");
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



    }
}
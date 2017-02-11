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
    public class TblExchangeServicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TblExchangeServices
        public ActionResult Index()
        {
            var exchangeServices = db.ExchangeServices.Include(e => e.ServiceSmartContract);
            return View(exchangeServices.ToList());
        }

        // GET: TblExchangeServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeService exchangeService = db.ExchangeServices.Find(id);
            if (exchangeService == null)
            {
                return HttpNotFound();
            }
            return View(exchangeService);
        }

        // GET: TblExchangeServices/Create
        public ActionResult Create()
        {
            ViewBag.SmartContractId = new SelectList(db.SmartContracts, "SmartContractId", "ContractName");
            return View();
        }

        // POST: TblExchangeServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExchangeServiceId,ExchangeServiceName,AvailableInMarket,SmartContractId")] ExchangeService exchangeService)
        {
            if (ModelState.IsValid)
            {
                db.ExchangeServices.Add(exchangeService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SmartContractId = new SelectList(db.SmartContracts, "SmartContractId", "ContractName", exchangeService.SmartContractId);
            return View(exchangeService);
        }

        // GET: TblExchangeServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeService exchangeService = db.ExchangeServices.Find(id);
            if (exchangeService == null)
            {
                return HttpNotFound();
            }
            ViewBag.SmartContractId = new SelectList(db.SmartContracts, "SmartContractId", "ContractName", exchangeService.SmartContractId);
            return View(exchangeService);
        }

        // POST: TblExchangeServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExchangeServiceId,ExchangeServiceName,AvailableInMarket,SmartContractId")] ExchangeService exchangeService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exchangeService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SmartContractId = new SelectList(db.SmartContracts, "SmartContractId", "ContractName", exchangeService.SmartContractId);
            return View(exchangeService);
        }

        // GET: TblExchangeServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExchangeService exchangeService = db.ExchangeServices.Find(id);
            if (exchangeService == null)
            {
                return HttpNotFound();
            }
            return View(exchangeService);
        }

        // POST: TblExchangeServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExchangeService exchangeService = db.ExchangeServices.Find(id);
            db.ExchangeServices.Remove(exchangeService);
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

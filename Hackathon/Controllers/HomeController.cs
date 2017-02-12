using Hackathon.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Hackathon.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            //var userAccountId = db.UserAccounts.Where(w => w.UserId == userId).FirstOrDefault().UserAccountId;
            var exchangeAccount = db.ExchangeAccounts.Where(w => w.UserId == userId).FirstOrDefault();
            var userAccountId = exchangeAccount.UserId;
            if (exchangeAccount.Company!=null)
            {
                var exchangeAccountMovements = db.ExchangeAccountMovements.Include(e => e.Company).Include(e => e.ContractedServiceConfiguration).Include(e => e.DiversificationPlanItem).Include(e => e.ExchangeAccount).Include(e => e.ExchangeService).Include(e => e.SourceInvoice);
                return View(exchangeAccountMovements.ToList());

                
            }
            else
            {
                return RedirectToAction("", "Enrollment");
                
            }


            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
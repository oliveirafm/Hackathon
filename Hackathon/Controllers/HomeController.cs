using Hackathon.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return View();
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
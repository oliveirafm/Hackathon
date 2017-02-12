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
    public class BaseController: Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        public ExchangeAccount currentExchangeAccount
        {
            get
            {
                var userId = User.Identity.GetUserId();
                var exchangeAccount = db.ExchangeAccounts.Where(w => w.UserId == userId).FirstOrDefault();
                return exchangeAccount;
            }
        }

    }
}
using Hackathon.Models;
using Hackathon.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hackathon.Controllers
{
    public class IosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Ios
        public ActionResult Index()
        {
            var viewlist = db.Database.SqlQuery<CurrentAccountViewModel>("SELECT [AmountWithdrawal] as Amount, [DestinationWithdrawal] as Account, [Companyid]  FROM [dbo].[CurrentAccountView]");

            return View(viewlist);
        }
    }
}
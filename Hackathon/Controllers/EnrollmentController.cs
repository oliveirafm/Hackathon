using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hackathon.Models;
using Microsoft.AspNet.Identity;
using Hackathon.Services;
using System.Threading;

namespace Hackathon.Controllers
{
    public class EnrollmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Enrollment
        public ActionResult Index()
        {
            return View();
        }

        // POST: TblCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Index([Bind(Include = "CompanyId,CompanyName,VatNumber,CompanyActivityCountry,CompanyActivity,CompanySector,KvkNumber,BranchNumber,Rsin,BusinessName,SbiCode,SbiCodeDescription,AddressType,BagId,Street,HouseNumber,HouseNumberAddition,PostalCode,City,CompanyCountry,GPSLatitude,GPSLongitude,RijksdriehoekX,RijksdriehoekY,RijksdriehoekZ,CompanyBlockChainAddress,IBAN")] Company company)
        {


            if (ModelState.IsValid)
            {
                DiversificationPlan diversificationPlan = new DiversificationPlan();
                diversificationPlan.Company = company;
                diversificationPlan.StartDate = DateTime.Now;
                diversificationPlan.EndDate = DateTime.Now.AddYears(1);

                var userId = User.Identity.GetUserId();
                var exchangeAccount = db.ExchangeAccounts.Where(w => w.UserId == userId).FirstOrDefault();
                var userAccountId = exchangeAccount.UserId;

                exchangeAccount.Company = company;


                company.DiversificationPlan.Add(diversificationPlan);

                db.Companies.Add(company);
                db.SaveChanges();

                var blockChainContract = db.SmartContracts.Find(1);
                var bcAccount = db.BlockChainAccounts.Find(1);
                var service = new SmartContractService(bcAccount.AccountAddress, bcAccount.AccountPassword);

                //var contractAddress = "";

                //new Thread(async () =>
                //{

                //}).Start();
                var contractAddress = await service.SendToServer(blockChainContract.ContractByteCode, blockChainContract.ContractAbi,
                InvoiceControlContractService.ConstructorValues(company.CompanyId, company.CompanyName, (int)company.VatNumber, company.KvkNumber, company.IBAN));

                company.CompanyBlockChainAddress = contractAddress.ToString();
                db.SaveChanges();

                return RedirectToAction("", "Home");
            }

            return View(company);
        }




    }
}
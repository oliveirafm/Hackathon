using Hackathon.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Hackathon
{
    public static class HMTLHelperExtensions
    {
        public static string IsSelected(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {

            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ?
                cssClass : String.Empty;
        }

        public static bool IsCurrent(this HtmlHelper html, string controller = null, string action = null, string cssClass = null)
        {
            if (String.IsNullOrEmpty(cssClass))
                cssClass = "active";

            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            string currentController = (string)html.ViewContext.RouteData.Values["controller"];

            if (String.IsNullOrEmpty(controller))
                controller = currentController;

            if (String.IsNullOrEmpty(action))
                action = currentAction;

            return controller == currentController && action == currentAction ? true : false;
        }

        public static string PageClass(this HtmlHelper html)
        {
            string currentAction = (string)html.ViewContext.RouteData.Values["action"];
            return currentAction;
        }
        public static bool IsEnrolled(this HtmlHelper html)
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            if (!string.IsNullOrEmpty(userId))
            {
                ApplicationDbContext db = new ApplicationDbContext();
                var exchangeAccount = db.ExchangeAccounts.Where(w => w.UserId == userId).FirstOrDefault();
                var userAccountId = exchangeAccount.UserId;
                if (exchangeAccount.Company != null)
                { 
                    return true;
                }
            }
            return false;
        }

    }
}
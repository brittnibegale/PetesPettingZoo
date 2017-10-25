//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;
//using Microsoft.AspNet.Identity;
//using Microsoft.Owin.Security;
//using System.Web.UI.WebControls;
//using System.Web.Mvc;
//using Stripe;

//namespace PetesPettingZoo.Views.Home
//{
//    public class Stripe
//    {
//        public ActionResult Charge(string stripeEmail, string stripeToken)
//        {
//            var customers = new StripeCustomerService();
//            var charges = new StripeChargeService();

//            var customer = customers.Create(new StripeCustomerCreateOptions
//            {
//                Email = stripeEmail,
//                SourceToken = stripeToken
//            });

//            var charge = charges.Create(new StripeChargeCreateOptions
//            {
//                Amount = /*TICKET COST IN $ */
//                Description = "Ticket Charge",
//                Currency = "Dollars",
//                CustomerId = customer.Id
//            });

//            return View();
//        }
//    }
//}
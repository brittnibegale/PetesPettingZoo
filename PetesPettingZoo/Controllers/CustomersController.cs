using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetesPettingZoo.Models;
using Stripe;

namespace PetesPettingZoo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.OpenDay).Include(c => c.Ticket);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.OpenDaysId = new SelectList(db.Days, "Id", "Day");
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Id");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "Id,FirstName,LastName,Email,OpenDaysId,TicketId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                customers.Cost = customers.TicketId * 7;
                customers.Paid = false;
                db.Customers.Add(customers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OpenDaysId = new SelectList(db.Days, "Id", "Id", customers.OpenDaysId);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Id", customers.TicketId);
            return View(customers);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpenDaysId = new SelectList(db.Days, "Id", "Id", customers.OpenDaysId);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Id", customers.TicketId);
            return View(customers);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(
            [Bind(Include = "Id,Cost,Paid,FirstName,LastName,Email,OpenDaysId,TicketId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpenDaysId = new SelectList(db.Days, "Id", "Id", customers.OpenDaysId);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Id", customers.TicketId);
            return View(customers);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View(customers);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult Charge(string stripeEmail, string stripeToken)
        //{
        //    var customers = new StripeCustomerService();
        //    var charges = new StripeChargeService();

        //    var customer = customers.Create(new StripeCustomerCreateOptions
        //    {
        //        Email = stripeEmail,
        //        SourceToken = stripeToken
        //    });

        //    var charge = charges.Create(new StripeChargeCreateOptions
        //    {
        //        Amount = /*TICKET COST IN $ */
        //            System.Web.Services.Description = "Ticket Charge",
        //        Currency = "Dollars",
        //        CustomerId = customer.Id
        //    });

        //    return View();
        //}


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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetesPettingZoo.API_calls;
using PetesPettingZoo.Models;
using Stripe;
using PetesPettingZoo.Models.ViewModels;

namespace PetesPettingZoo.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        //GET: Customers
        public ActionResult Index()
        {
            var day = db.Days.Where(m => m.Day == DateTime.Today).Select(m => m.Id);           
            var potenitalCustomers = db.Customers.Where(m => day.Contains(m.OpenDaysId)).ToList();
            return View(potenitalCustomers);
    }

   // GET: Customers/Details
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
                return
                    RedirectToAction("Pay", customers); 
            }

            ViewBag.OpenDaysId = new SelectList(db.Days, "Id", "Id", customers.OpenDaysId);
            ViewBag.TicketId = new SelectList(db.Tickets, "Id", "Id", customers.TicketId);
            return View(customers);
        }

    
        public ActionResult Pay(Customers customers)
        {
            var viewModel = new TicketAmountViewModel();
               {
                   viewModel.Cost = customers.Cost;
                   viewModel.FirstName = customers.FirstName;
               }
            return View(viewModel);
        }
    
           [HttpPost]
           public ActionResult Pay(TicketAmountViewModel viewModel)
           {
               var customers = db.Customers.Where(m => m.FirstName == viewModel.FirstName).First();
                customers.Paid = true;
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Confirmation");
           }       
        public void getStaticMethod()
        {
            mailgunAPIcall.SendSimpleMessage();
        }

       
        public ActionResult Confirmation()
        {
            getStaticMethod();
            return View();
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

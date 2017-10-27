using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using Newtonsoft.Json;
using PetesPettingZoo.API_calls;
using PetesPettingZoo.Models;
using PetesPettingZoo.Models.ViewModels;
using RestSharp;

namespace PetesPettingZoo.Controllers
{
    public class OpenDaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OpenDays
        public ActionResult Index()
        {
            List<string> weather = weatherapi.ApiCall();
            List<OpenDays> days = db.Days.ToList();

            var viewModel = new SchduleViewModel();
            {
                viewModel.Days = days;
                viewModel.Weather = weather;
            }

            return View(viewModel);
            
        }

        // GET: OpenDays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenDays openDays = db.Days.Find(id);
            if (openDays == null)
            {
                return HttpNotFound();
            }
            return View(openDays);
        }

        // GET: OpenDays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpenDays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Day")] OpenDays openDays)
        {
            if (ModelState.IsValid)
            {
                db.Days.Add(openDays);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(openDays);
        }

        // GET: OpenDays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenDays openDays = db.Days.Find(id);
            if (openDays == null)
            {
                return HttpNotFound();
            }
            return View(openDays);
        }

        // POST: OpenDays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Day")] OpenDays openDays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openDays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openDays);
        }

        // GET: OpenDays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenDays openDays = db.Days.Find(id);
            if (openDays == null)
            {
                return HttpNotFound();
            }
            return View(openDays);
        }

        // POST: OpenDays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenDays openDays = db.Days.Find(id);
            db.Days.Remove(openDays);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SSL_API.Models;

namespace SSL_API.Controllers
{
    [Authorize]
    public class AssignedController : Controller
    {
        private Entities db = new Entities();

        // GET: Assigned
        public ActionResult Index()
        {

            var userId = User.Identity.GetUserId();
            List<Assigned> Devices = new List<Assigned>(db.Assigneds.Where(u => u.Id == userId));

            ViewBag.Devices = Devices;

            return View();

            //return View(db.Assigneds.ToList());
        }

        // GET: Assigned/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assigned assigned = db.Assigneds.Find(id);
            if (assigned == null)
            {
                return HttpNotFound();
            }
            return View(assigned);
        }

        // GET: Assigned/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assigned/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MacAddress,Issued")] Assigned assigned)
        {
            if (ModelState.IsValid)
            {
                db.Assigneds.Add(assigned);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assigned);
        }

        // GET: Assigned/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assigned assigned = db.Assigneds.Find(id);
            if (assigned == null)
            {
                return HttpNotFound();
            }
            return View(assigned);
        }

        // POST: Assigned/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MacAddress,Issued")] Assigned assigned)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assigned).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assigned);
        }

        // GET: Assigned/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assigned assigned = db.Assigneds.Find(id);
            if (assigned == null)
            {
                return HttpNotFound();
            }
            return View(assigned);
        }

        // POST: Assigned/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Assigned assigned = db.Assigneds.Find(id);
            db.Assigneds.Remove(assigned);
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

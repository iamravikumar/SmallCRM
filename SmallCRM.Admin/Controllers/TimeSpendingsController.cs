﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmallCRM.Data;
using SmallCRM.Model;

namespace SmallCRM.Admin.Controllers
{
    public class TimeSpendingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TimeSpendings
        public ActionResult Index()
        {
            var timeSpendings = db.TimeSpendings.Include(t => t.Project).Include(t => t.WorkItem);
            return View(timeSpendings.ToList());
        }

        // GET: TimeSpendings/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpending timeSpending = db.TimeSpendings.Find(id);
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            return View(timeSpending);
        }

        // GET: TimeSpendings/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name");
            return View();
        }

        // POST: TimeSpendings/Create
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ProjectId,WorkItemId,Worker,TimeSpent,WorkItemStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] TimeSpending timeSpending)
        {
            if (ModelState.IsValid)
            {
                timeSpending.Id = Guid.NewGuid();
                db.TimeSpendings.Add(timeSpending);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpending timeSpending = db.TimeSpendings.Find(id);
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // POST: TimeSpendings/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, lütfen bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=317598 sayfasına bakın.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ProjectId,WorkItemId,Worker,TimeSpent,WorkItemStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] TimeSpending timeSpending)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeSpending).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", timeSpending.ProjectId);
            ViewBag.WorkItemId = new SelectList(db.WorkItems, "Id", "Name", timeSpending.WorkItemId);
            return View(timeSpending);
        }

        // GET: TimeSpendings/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeSpending timeSpending = db.TimeSpendings.Find(id);
            if (timeSpending == null)
            {
                return HttpNotFound();
            }
            return View(timeSpending);
        }

        // POST: TimeSpendings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            TimeSpending timeSpending = db.TimeSpendings.Find(id);
            db.TimeSpendings.Remove(timeSpending);
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
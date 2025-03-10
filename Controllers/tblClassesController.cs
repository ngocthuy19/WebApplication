﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class tblClassesController : Controller
    {
        private Model1 db = new Model1();

        // GET: tblClasses
        public ActionResult Index()
        {
            return View(db.tblClasses.ToList());
        }

        // GET: tblClasses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClass tblClass = db.tblClasses.Find(id);
            if (tblClass == null)
            {
                return HttpNotFound();
            }
            return View(tblClass);
        }

        // GET: tblClasses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblClasses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLop,TenLop,Siso")] tblClass tblClass)
        {
            if (ModelState.IsValid)
            {
                db.tblClasses.Add(tblClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblClass);
        }

        // GET: tblClasses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClass tblClass = db.tblClasses.Find(id);
            if (tblClass == null)
            {
                return HttpNotFound();
            }
            return View(tblClass);
        }

        // POST: tblClasses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLop,TenLop,Siso")] tblClass tblClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblClass);
        }

        // GET: tblClasses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClass tblClass = db.tblClasses.Find(id);
            if (tblClass == null)
            {
                return HttpNotFound();
            }
            return View(tblClass);
        }

        // POST: tblClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClass tblClass = db.tblClasses.Find(id);
            db.tblClasses.Remove(tblClass);
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

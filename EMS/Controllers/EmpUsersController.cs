using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EMS.Models;

namespace EMS.Controllers
{
    public class EmpUsersController : Controller
    {
        private EMSEntities db = new EMSEntities();

        // GET: EmpUsers
        public ActionResult Index()
        {
            return View(db.EmpUsers.ToList());
        }

        // GET: EmpUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = db.EmpUsers.Find(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // GET: EmpUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,Name,EmailID,Password")] EmpUser empUser)
        {
            if (ModelState.IsValid)
            {
                db.EmpUsers.Add(empUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empUser);
        }

        // GET: EmpUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = db.EmpUsers.Find(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // POST: EmpUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,Name,EmailID,Password")] EmpUser empUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empUser);
        }

        // GET: EmpUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpUser empUser = db.EmpUsers.Find(id);
            if (empUser == null)
            {
                return HttpNotFound();
            }
            return View(empUser);
        }

        // POST: EmpUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpUser empUser = db.EmpUsers.Find(id);
            db.EmpUsers.Remove(empUser);
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

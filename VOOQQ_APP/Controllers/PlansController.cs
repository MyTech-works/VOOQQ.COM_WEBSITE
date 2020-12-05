using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VOOQQ_APP.Models;

namespace VOOQQ_APP.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plans
        public ActionResult Index()
        {
            ViewBag.Category = db.vooqCategories.ToList();
            return View(db.Plans.Where(a => a.VooqCategoryId == 1 && a.IsPrime == true).ToList());
        }

        [HttpGet]
        public ActionResult getDataBySelectedID(string selectedId)
        {
            ViewBag.Category = db.vooqCategories.ToList();
            long PlanType = Convert.ToInt64(selectedId == "" || selectedId == null ? "1" : selectedId);
            return View("Index", db.Plans.Where(a => a.VooqCategoryId == PlanType && a.IsPrime == true).ToList());
        }

        // GET: Plans/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // GET: Plans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlanId,VooqCategoryId,PlanTypeId,PlanTypeName,Duration,Amount,IsPrime")] Plans plans)
        {
            if (ModelState.IsValid)
            {
                plans.CreatedDate = DateTime.Now;
                db.Plans.Add(plans);
                db.SaveChanges();
              return RedirectToAction("Index", "MyAccount");
            }

            return View(plans);
        }

        // GET: Plans/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlanId,VooqCategoryId,PlanTypeId,PlanTypeName,Duration,Amount,IsPrime")] Plans plans)
        {
            if (ModelState.IsValid)
            {
                plans.CreatedDate = DateTime.Now;
                db.Entry(plans).State = EntityState.Modified;
                db.SaveChanges();
              return RedirectToAction("Index", "MyAccount");
            }
            return View(plans);
        }

        // GET: Plans/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plans plans = db.Plans.Find(id);
            if (plans == null)
            {
                return HttpNotFound();
            }
            return View(plans);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Plans plans = db.Plans.Find(id);
            db.Plans.Remove(plans);
            db.SaveChanges();
          return RedirectToAction("Index", "MyAccount");
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

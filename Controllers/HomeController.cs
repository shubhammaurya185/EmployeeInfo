using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDetailsProj.Models;

namespace EmployeeDetailsProj.Controllers
{
    public class HomeController : Controller
    {
        private EmployeeEntities db = new EmployeeEntities();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.tblUserInfoes.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserInfo tblUserInfo = await db.tblUserInfoes.FindAsync(id);
            if (tblUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblUserInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Emp_ID,Emp_Name,Emp_Mobile,Emp_Address,Emp_Dept")] tblUserInfo tblUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblUserInfoes.Add(tblUserInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblUserInfo);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserInfo tblUserInfo = await db.tblUserInfoes.FindAsync(id);
            if (tblUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblUserInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Emp_ID,Emp_Name,Emp_Mobile,Emp_Address,Emp_Dept")] tblUserInfo tblUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblUserInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblUserInfo);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblUserInfo tblUserInfo = await db.tblUserInfoes.FindAsync(id);
            if (tblUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblUserInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblUserInfo tblUserInfo = await db.tblUserInfoes.FindAsync(id);
            db.tblUserInfoes.Remove(tblUserInfo);
            await db.SaveChangesAsync();
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

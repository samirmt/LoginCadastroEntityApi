using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CadastroUrlBackendMobile.Models;
using UrlBackendMobile.Models;

namespace CadastroUrlBackendMobile.Controllers
{
    public class UrlBackendMobileTablesController : Controller
    {
        private _Database db = new _Database();

        // GET: UrlBackendMobileTables
        [SessionCheck]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        // GET: UrlBackendMobileTables/Details/5
        [SessionCheck]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlBackendMobileTable urlBackendMobileTable = db.urlBackendMobilesTable.Find(id);
            if (urlBackendMobileTable == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobileTable);
        }

        // GET: UrlBackendMobileTables/Create
        [SessionCheck]
        public ActionResult Create()
        {
            return View();
        }

        // POST: UrlBackendMobileTables/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Create([Bind(Include = "id,CNPJ,URL")] UrlBackendMobileTable urlBackendMobileTable)
        {
            if (ModelState.IsValid)
            {
                db.urlBackendMobilesTable.Add(urlBackendMobileTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urlBackendMobileTable);
        }

        // GET: UrlBackendMobileTables/Edit/5
        [SessionCheck]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlBackendMobileTable urlBackendMobileTable = db.urlBackendMobilesTable.Find(id);
            if (urlBackendMobileTable == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobileTable);
        }

        // POST: UrlBackendMobileTables/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult Edit([Bind(Include = "id,CNPJ,URL")] UrlBackendMobileTable urlBackendMobileTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urlBackendMobileTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urlBackendMobileTable);
        }

        // GET: UrlBackendMobileTables/Delete/5
        [SessionCheck]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UrlBackendMobileTable urlBackendMobileTable = db.urlBackendMobilesTable.Find(id);
            if (urlBackendMobileTable == null)
            {
                return HttpNotFound();
            }
            return View(urlBackendMobileTable);
        }

        // POST: UrlBackendMobileTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [SessionCheck]
        public ActionResult DeleteConfirmed(int id)
        {
            UrlBackendMobileTable urlBackendMobileTable = db.urlBackendMobilesTable.Find(id);
            db.urlBackendMobilesTable.Remove(urlBackendMobileTable);
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

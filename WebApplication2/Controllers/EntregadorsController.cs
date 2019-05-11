using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class EntregadorsController : Controller
    {
        private Packed_Lunch_4Entities2 db = new Packed_Lunch_4Entities2();

        // GET: Entregadors
        public ActionResult Index()
        {
            return View(db.Entregador.ToList());
        }

        // GET: Entregadors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entregador entregador = db.Entregador.Find(id);
            if (entregador == null)
            {
                return HttpNotFound();
            }
            return View(entregador);
        }

        // GET: Entregadors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entregadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Entregador,Cpf,Nome,Login,Senha")] Entregador entregador)
        {
            if (ModelState.IsValid)
            {
                db.Entregador.Add(entregador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entregador);
        }

        // GET: Entregadors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entregador entregador = db.Entregador.Find(id);
            if (entregador == null)
            {
                return HttpNotFound();
            }
            return View(entregador);
        }

        // POST: Entregadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Entregador,Cpf,Nome,Login,Senha")] Entregador entregador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entregador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entregador);
        }

        // GET: Entregadors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entregador entregador = db.Entregador.Find(id);
            if (entregador == null)
            {
                return HttpNotFound();
            }
            return View(entregador);
        }

        // POST: Entregadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entregador entregador = db.Entregador.Find(id);
            db.Entregador.Remove(entregador);
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

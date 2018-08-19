using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PuntoVentaMVC.Models;

namespace PuntoVentaMVC.Controllers
{
    public class ProductosCategoriasController : Controller
    {
        private PuntoVentaEntities db = new PuntoVentaEntities();

        // GET: ProductosCategorias
        public ActionResult Index()
        {
            var productosCategorias = db.ProductosCategorias.Include(p => p.Categorias).Include(p => p.Productos);
            return View(productosCategorias.ToList());
        }

        // GET: ProductosCategorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosCategorias productosCategorias = db.ProductosCategorias.Find(id);
            if (productosCategorias == null)
            {
                return HttpNotFound();
            }
            return View(productosCategorias);
        }

        // GET: ProductosCategorias/Create
        public ActionResult Create()
        {
            ViewBag.Categoria = new SelectList(db.Categorias, "ID_Categoria", "C_Nombre");
            ViewBag.Producto = new SelectList(db.Productos, "ID_Producto", "P_Nombre");
            return View();
        }

        // POST: ProductosCategorias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Folio,Producto,Categoria")] ProductosCategorias productosCategorias)
        {
            if (ModelState.IsValid)
            {
                db.ProductosCategorias.Add(productosCategorias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categoria = new SelectList(db.Categorias, "ID_Categoria", "C_Nombre", productosCategorias.Categoria);
            ViewBag.Producto = new SelectList(db.Productos, "ID_Producto", "P_Nombre", productosCategorias.Producto);
            return View(productosCategorias);
        }

        // GET: ProductosCategorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosCategorias productosCategorias = db.ProductosCategorias.Find(id);
            if (productosCategorias == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "ID_Categoria", "C_Nombre", productosCategorias.Categoria);
            ViewBag.Producto = new SelectList(db.Productos, "ID_Producto", "P_Nombre", productosCategorias.Producto);
            return View(productosCategorias);
        }

        // POST: ProductosCategorias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Folio,Producto,Categoria")] ProductosCategorias productosCategorias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productosCategorias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categoria = new SelectList(db.Categorias, "ID_Categoria", "C_Nombre", productosCategorias.Categoria);
            ViewBag.Producto = new SelectList(db.Productos, "ID_Producto", "P_Nombre", productosCategorias.Producto);
            return View(productosCategorias);
        }

        // GET: ProductosCategorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductosCategorias productosCategorias = db.ProductosCategorias.Find(id);
            if (productosCategorias == null)
            {
                return HttpNotFound();
            }
            return View(productosCategorias);
        }

        // POST: ProductosCategorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductosCategorias productosCategorias = db.ProductosCategorias.Find(id);
            db.ProductosCategorias.Remove(productosCategorias);
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

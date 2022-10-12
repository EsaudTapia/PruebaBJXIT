using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaBJXIT.Models;

namespace PruebaBJXIT.Controllers
{
    public class ProveedoresApiController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ProveedoresApi
        public IQueryable<Proveedores> GetProveedores()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Proveedores;
        }

        // GET: api/ProveedoresApi/5
        [ResponseType(typeof(Proveedores))]
        public IHttpActionResult GetProveedores(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            return Ok(proveedores);
        }

        // PUT: api/ProveedoresApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProveedores(int id, Proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proveedores.Id)
            {
                return BadRequest();
            }

            db.Entry(proveedores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProveedoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ProveedoresApi
        [ResponseType(typeof(Proveedores))]
        public IHttpActionResult PostProveedores(Proveedores proveedores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proveedores.Add(proveedores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proveedores.Id }, proveedores);
        }

        // DELETE: api/ProveedoresApi/5
        [ResponseType(typeof(Proveedores))]
        public IHttpActionResult DeleteProveedores(int id)
        {
            Proveedores proveedores = db.Proveedores.Find(id);
            if (proveedores == null)
            {
                return NotFound();
            }

            db.Proveedores.Remove(proveedores);
            db.SaveChanges();

            return Ok(proveedores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProveedoresExists(int id)
        {
            return db.Proveedores.Count(e => e.Id == id) > 0;
        }
    }
}
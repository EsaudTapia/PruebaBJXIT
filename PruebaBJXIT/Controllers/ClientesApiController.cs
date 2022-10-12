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
    public class ClientesApiController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/ClientesApi
        public IQueryable<Clientes> GetClientes()
        {
            db.Configuration.LazyLoadingEnabled = false;
            return db.Clientes;
        }

        // GET: api/ClientesApi/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult GetClientes(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return NotFound();
            }

            return Ok(clientes);
        }

        // PUT: api/ClientesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClientes(int id, Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != clientes.Id)
            {
                return BadRequest();
            }

            db.Entry(clientes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExists(id))
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

        // POST: api/ClientesApi
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult PostClientes(Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Clientes.Add(clientes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = clientes.Id }, clientes);
        }

        // DELETE: api/ClientesApi/5
        [ResponseType(typeof(Clientes))]
        public IHttpActionResult DeleteClientes(int id)
        {
            Clientes clientes = db.Clientes.Find(id);
            if (clientes == null)
            {
                return NotFound();
            }

            db.Clientes.Remove(clientes);
            db.SaveChanges();

            return Ok(clientes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ClientesExists(int id)
        {
            return db.Clientes.Count(e => e.Id == id) > 0;
        }
    }
}
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
    public class RolesApiController : ApiController
    {
        private DBContext db = new DBContext();

        // GET: api/RolesApi
        public IQueryable<Roles> GetRoles()
        {
            db.Configuration.LazyLoadingEnabled = false;
            
            return db.Roles;
        }

        // GET: api/RolesApi/5
        [ResponseType(typeof(Roles))]
        public IHttpActionResult GetRoles(int id)
        {
            db.Configuration.LazyLoadingEnabled = false;
            Roles roles = db.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            return Ok(roles);
        }

        // PUT: api/RolesApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRoles(int id, Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != roles.Id_matricula)
            {
                return BadRequest();
            }

            db.Entry(roles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolesExists(id))
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

        // POST: api/RolesApi
        [ResponseType(typeof(Roles))]
        public IHttpActionResult PostRoles(Roles roles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Roles.Add(roles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = roles.Id_matricula }, roles);
        }

        // DELETE: api/RolesApi/5
        [ResponseType(typeof(Roles))]
        public IHttpActionResult DeleteRoles(int id)
        {
            Roles roles = db.Roles.Find(id);
            if (roles == null)
            {
                return NotFound();
            }

            db.Roles.Remove(roles);
            db.SaveChanges();

            return Ok(roles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RolesExists(int id)
        {
            return db.Roles.Count(e => e.Id_matricula == id) > 0;
        }
    }
}
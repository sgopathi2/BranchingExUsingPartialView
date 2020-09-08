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
using MVC.Models;

namespace MVC.Controllers
{
    public class Emps1Controller : ApiController
    {
        private EmpContext db = new EmpContext();

        // GET: api/Emps1
        public IQueryable<Emp> GetEmps()
        {
            return db.Emps;
        }

        // GET: api/Emps1/5
        [ResponseType(typeof(Emp))]
        public IHttpActionResult GetEmp(int id)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            return Ok(emp);
        }

        // PUT: api/Emps1/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmp(int id, Emp emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != emp.EId)
            {
                return BadRequest();
            }

            db.Entry(emp).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(id))
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

        // POST: api/Emps1
        [ResponseType(typeof(Emp))]
        public IHttpActionResult PostEmp(Emp emp)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Emps.Add(emp);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = emp.EId }, emp);
        }

        // DELETE: api/Emps1/5
        [ResponseType(typeof(Emp))]
        public IHttpActionResult DeleteEmp(int id)
        {
            Emp emp = db.Emps.Find(id);
            if (emp == null)
            {
                return NotFound();
            }

            db.Emps.Remove(emp);
            db.SaveChanges();

            return Ok(emp);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpExists(int id)
        {
            return db.Emps.Count(e => e.EId == id) > 0;
        }
    }
}
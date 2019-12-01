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
using TesteAPI.Models;

namespace TesteAPI.Controllers
{
    public class AgendaCrudController : ApiController
    {
        private AgendaDBContext db = new AgendaDBContext();

        // GET: api/AgendaCrud
        public IQueryable<Agenda> GetAgendas()
        {
            return db.Agendas;
        }

        // GET: api/AgendaCrud/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult GetAgenda(int id)
        {
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            return Ok(agenda);
        }

        // PUT: api/AgendaCrud/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgenda(int id, Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agenda.Id)
            {
                return BadRequest();
            }

            db.Entry(agenda).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaExists(id))
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

        // POST: api/AgendaCrud
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult PostAgenda(Agenda agenda)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agendas.Add(agenda);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agenda.Id }, agenda);
        }

        // DELETE: api/AgendaCrud/5
        [ResponseType(typeof(Agenda))]
        public IHttpActionResult DeleteAgenda(int id)
        {
            Agenda agenda = db.Agendas.Find(id);
            if (agenda == null)
            {
                return NotFound();
            }

            db.Agendas.Remove(agenda);
            db.SaveChanges();

            return Ok(agenda);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendaExists(int id)
        {
            return db.Agendas.Count(e => e.Id == id) > 0;
        }
    }
}
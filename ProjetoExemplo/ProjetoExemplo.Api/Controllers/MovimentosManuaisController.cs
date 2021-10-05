using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ProjetoExemplo.Api.Data;
using ProjetoExemplo.Modelo;

namespace ProjetoExemplo.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MovimentosManuaisController : ApiController
    {
        private SqlDbContext db = new SqlDbContext();

        // GET: api/MovimentosManuais
        public IQueryable<MovimentoManual> GetMovimentosManuais()
        {
            return db.MovimentosManuais;
        }

        // GET: api/MovimentosManuais/5
        [ResponseType(typeof(MovimentoManual))]
        public IHttpActionResult GetMovimentoManual(short id)
        {
            MovimentoManual movimentoManual = db.MovimentosManuais.Find(id);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            return Ok(movimentoManual);
        }

        // PUT: api/MovimentosManuais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMovimentoManual(short id, MovimentoManual movimentoManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movimentoManual.Mes)
            {
                return BadRequest();
            }

            db.Entry(movimentoManual).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentoManualExists(id))
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

        // POST: api/MovimentosManuais
        [ResponseType(typeof(MovimentoManual))]
        public IHttpActionResult PostMovimentoManual(MovimentoManual movimentoManual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            movimentoManual.DataMovimento = DateTime.Now;

            db.MovimentosManuais.Add(movimentoManual);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MovimentoManualExists(movimentoManual.Mes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = movimentoManual.Mes }, movimentoManual);
        }

        // DELETE: api/MovimentosManuais/5
        [ResponseType(typeof(MovimentoManual))]
        public IHttpActionResult DeleteMovimentoManual(short id)
        {
            MovimentoManual movimentoManual = db.MovimentosManuais.Find(id);
            if (movimentoManual == null)
            {
                return NotFound();
            }

            db.MovimentosManuais.Remove(movimentoManual);
            db.SaveChanges();

            return Ok(movimentoManual);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovimentoManualExists(short id)
        {
            return db.MovimentosManuais.Count(e => e.Mes == id) > 0;
        }
    }
}
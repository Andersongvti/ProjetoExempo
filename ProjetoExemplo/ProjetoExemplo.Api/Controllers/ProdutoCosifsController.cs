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
    public class ProdutoCosifsController : ApiController
    {
        private SqlDbContext db = new SqlDbContext();

        // GET: api/ProdutoCosifs
        public IQueryable<ProdutoCosif> GetProdutosCosif()
        {
            return db.ProdutosCosif;
        }

        // GET: api/ProdutoCosifs/5
        [ResponseType(typeof(ProdutoCosif))]
        public IHttpActionResult GetProdutoCosif(string id)
        {
            ProdutoCosif produtoCosif = db.ProdutosCosif.Find(id);
            if (produtoCosif == null)
            {
                return NotFound();
            }

            return Ok(produtoCosif);
        }

        // PUT: api/ProdutoCosifs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProdutoCosif(string id, ProdutoCosif produtoCosif)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != produtoCosif.CodigoCosif)
            {
                return BadRequest();
            }

            db.Entry(produtoCosif).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoCosifExists(id))
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

        // POST: api/ProdutoCosifs
        [ResponseType(typeof(ProdutoCosif))]
        public IHttpActionResult PostProdutoCosif(ProdutoCosif produtoCosif)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProdutosCosif.Add(produtoCosif);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ProdutoCosifExists(produtoCosif.CodigoCosif))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = produtoCosif.CodigoCosif }, produtoCosif);
        }

        // DELETE: api/ProdutoCosifs/5
        [ResponseType(typeof(ProdutoCosif))]
        public IHttpActionResult DeleteProdutoCosif(string id)
        {
            ProdutoCosif produtoCosif = db.ProdutosCosif.Find(id);
            if (produtoCosif == null)
            {
                return NotFound();
            }

            db.ProdutosCosif.Remove(produtoCosif);
            db.SaveChanges();

            return Ok(produtoCosif);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProdutoCosifExists(string id)
        {
            return db.ProdutosCosif.Count(e => e.CodigoCosif == id) > 0;
        }
    }
}
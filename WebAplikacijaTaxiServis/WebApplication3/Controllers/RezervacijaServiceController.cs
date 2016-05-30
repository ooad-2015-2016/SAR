using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class RezervacijaServiceController : ApiController
    {
        private RezervacijaDbContext db = new RezervacijaDbContext();

        // GET: api/RezervacijaService
        public IQueryable<Rezervacija> GetRezervacije()
        {
            return db.Rezervacije;
        }

        // GET: api/RezervacijaService/5
        [ResponseType(typeof(Rezervacija))]
        public async Task<IHttpActionResult> GetRezervacija(int id)
        {
            Rezervacija rezervacija = await db.Rezervacije.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return Ok(rezervacija);
        }

        // PUT: api/RezervacijaService/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRezervacija(int id, Rezervacija rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rezervacija.Id)
            {
                return BadRequest();
            }

            db.Entry(rezervacija).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RezervacijaExists(id))
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

        // POST: api/RezervacijaService
        [ResponseType(typeof(Rezervacija))]
        public async Task<IHttpActionResult> PostRezervacija(Rezervacija rezervacija)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Rezervacije.Add(rezervacija);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = rezervacija.Id }, rezervacija);
        }

        // DELETE: api/RezervacijaService/5
        [ResponseType(typeof(Rezervacija))]
        public async Task<IHttpActionResult> DeleteRezervacija(int id)
        {
            Rezervacija rezervacija = await db.Rezervacije.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            db.Rezervacije.Remove(rezervacija);
            await db.SaveChangesAsync();

            return Ok(rezervacija);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RezervacijaExists(int id)
        {
            return db.Rezervacije.Count(e => e.Id == id) > 0;
        }
    }
}
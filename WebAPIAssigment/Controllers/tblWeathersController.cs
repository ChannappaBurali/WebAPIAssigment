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
using WebAPIAssigment;

namespace WebAPIAssigment.Controllers
{
    public class tblWeathersController : ApiController
    {
        private WeatherEntities1 db = new WeatherEntities1();

        // GET: api/tblWeathers
        public IQueryable<tblWeather> GettblWeathers()
        {
            return db.tblWeathers;
        }

        // GET: api/tblWeathers/5
        [ResponseType(typeof(tblWeather))]
        public IHttpActionResult GettblWeather(int id)
        {
            tblWeather tblWeather = db.tblWeathers.Find(id);
            if (tblWeather == null)
            {
                return NotFound();
            }

            return Ok(tblWeather);
        }

        // PUT: api/tblWeathers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblWeather(int id, tblWeather tblWeather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblWeather.Id)
            {
                return BadRequest();
            }

            db.Entry(tblWeather).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblWeatherExists(id))
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

        // POST: api/tblWeathers
        [ResponseType(typeof(tblWeather))]
        public IHttpActionResult PosttblWeather(tblWeather tblWeather)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblWeathers.Add(tblWeather);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblWeather.Id }, tblWeather);
        }

        // DELETE: api/tblWeathers/5
        [ResponseType(typeof(tblWeather))]
        public IHttpActionResult DeletetblWeather(int id)
        {
            tblWeather tblWeather = db.tblWeathers.Find(id);
            if (tblWeather == null)
            {
                return NotFound();
            }

            db.tblWeathers.Remove(tblWeather);
            db.SaveChanges();

            return Ok(tblWeather);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblWeatherExists(int id)
        {
            return db.tblWeathers.Count(e => e.Id == id) > 0;
        }
    }
}
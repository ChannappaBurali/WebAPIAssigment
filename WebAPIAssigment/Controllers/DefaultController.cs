using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIAssigment.Models;

namespace WebAPIAssigment.Controllers
{
   
    public class DefaultController : ApiController
    {
        WeatherEntities1 wr = new WeatherEntities1();
        public IHttpActionResult GetWeather()
        {
            List<tblWeather> WeatherList = wr.tblWeathers.ToList();
            if (WeatherList.Count == 0)
            {
                return NotFound();
            }

            return Ok(WeatherList);
        }

        [Route("CountryDetails")]
        [HttpGet]
        public List<Country> BindCountry()
        {
            IEnumerable<Country> lstCountry = new List<Country>();
            try
            {               
                    lstCountry = wr.Countries.ToList();               
            }
            catch (Exception)
            {
                throw;
            }
            return lstCountry.ToList();
        }

        [Route("StateDetails/{counryId}")]
        [HttpGet]
        public List<State> BindState(string countryId)
        {
            IEnumerable<State> lstState = new List<State>();
            try
            {                
                    lstState = wr.States.Where(a => a.CountryId == Convert.ToInt32(countryId)).ToList();                
            }
            catch (Exception)
            {
                throw;
            }
            return lstState.ToList();
        }

        [Route("CityDetails/{cityId}")]
        [HttpGet]
        public List<City> BindCity(string SateId)
        {
            IEnumerable<City> lstDistrict = new List<City>();
            try
            {             
                    lstDistrict = wr.Cities.Where(a => a.StateId == Convert.ToInt32(SateId)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return lstDistrict.ToList();
        }

    }
}

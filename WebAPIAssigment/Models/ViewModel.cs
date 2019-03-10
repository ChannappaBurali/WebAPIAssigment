using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAPIAssigment.Models
{
    public class ViewModel
    {
        public List<SelectListItem> Country { get; set; }
        public List<SelectListItem> States { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public tblWeather GetWeather { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
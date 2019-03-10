using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIMVC.Models
{
    public class MVCModel
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Nullable<decimal> Temperature { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
    
}
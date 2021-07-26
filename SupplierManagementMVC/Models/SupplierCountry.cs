using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplierManagementMVC.Models
{
    public class SupplierCountry
    {
        public int ID { get; set; }
        [Display(Name = "Counrty")]
        public string CountryName { get; set; }
    }
}
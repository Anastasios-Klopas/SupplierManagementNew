using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierManagementAPI.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public int Afm { get; set; }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public bool ActiveSupplier { get; set; }
        public int SupplierCategoryID { get; set; }
        public SupplierCategory SupplierCategory { get; set; }
        public int SupplierCountryID { get; set; }
        public SupplierCountry SupplierCountry { get; set; }
    }
}
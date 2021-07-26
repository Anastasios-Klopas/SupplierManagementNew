using SupplierManagementMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierManagementMVC.ViewModels
{
    public class SupplierCategoryCountryViewModel
    {
        public Supplier Supplier { get; set; }
        //public IEnumerable<SupplierCategory> SupplierCategories { get; set; }
        public IEnumerable<SupplierCategory> SupplierCategories { get; set; }
        public IEnumerable<SupplierCountry> SupplierCountries { get; set; }
    }
}
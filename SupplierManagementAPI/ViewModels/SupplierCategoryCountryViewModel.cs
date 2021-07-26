using SupplierManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SupplierManagementAPI.ViewModels
{
    public class SupplierCategoryCountryViewModel
    {
        public Supplier Supplier { get; set; }
        public List<SupplierCategory> SupplierCategories { get; set; }
        public List<SupplierCountry> SupplierCountries { get; set; }
    }
}
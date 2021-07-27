using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplierManagementMVC.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "The Name should be between 3 to 80 characters.")]
        [Display(Name = "Name")]
        public string SupplierName { get; set; }
        [Required]
        [AfmValidation]
        [Display(Name = "A.F.M.")]
        public int? Afm { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The Address should be between 5 to 100 characters.")]
        public string Address { get; set; }
        [Required]
        [TelephoneValidation]
        public string Telephone { get; set; }
        [Required]
        [EmailValidation]
        public string Email { get; set; }
        [Display(Name = "Active Supplier")]
        public bool ActiveSupplier { get; set; }
        [Required]
        [Display(Name = "Supplier Category")]
        public int SupplierCategoryID { get; set; }
        public SupplierCategory SupplierCategory { get; set; }
        [Required]
        [Display(Name = "Country")]
        public int SupplierCountryID { get; set; }
        public SupplierCountry SupplierCountry { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplierManagementMVC.Models
{
    public class SupplierCategory
    {
        public int ID { get; set; }
        [Display(Name = "Supplier Category")]
        public string CategoryName { get; set; }
    }
}
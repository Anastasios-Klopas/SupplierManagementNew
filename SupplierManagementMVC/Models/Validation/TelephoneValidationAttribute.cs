using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SupplierManagementMVC.Models
{
    public class TelephoneValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object telephone, ValidationContext validationContext)
        {

            if (telephone != null)
            {
                string telephoneNew = telephone.ToString();
                if (Regex.IsMatch(telephoneNew, @"^[0-9]*$", RegexOptions.IgnoreCase) && telephoneNew.Length == 10)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please Enter a Valid Telephone (10 digits).");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}
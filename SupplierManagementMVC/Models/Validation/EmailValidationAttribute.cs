using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SupplierManagementMVC.Models
{
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object email, ValidationContext validationContext)
        {
            if (email != null)
            {
                string emailNew = email.ToString();

                if (Regex.IsMatch(emailNew, @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", RegexOptions.IgnoreCase) && emailNew.Length >= 5 && emailNew.Length <= 50)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Please Enter a Valid Email.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SupplierManagementMVC.Models
{
    public class AfmValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object afm, ValidationContext validationContext)
        {

            if (afm != null)
            {
                int numAFM = 0;
                //string afmNew = afm.ToString(); // kanei trim ta arxika 0
                string afmNew = string.Format("{0:000000000}", afm);
                if (afmNew.Length != 9 || !int.TryParse(afmNew, out numAFM))
                    return new ValidationResult("Please Enter a Valid A.F.M.");
                else
                {
                    double sum = 0;
                    int iter = afmNew.Length - 1;
                    afmNew.ToCharArray().Take(iter).ToList().ForEach(c =>
                    {
                        sum += double.Parse(c.ToString()) * Math.Pow(2, iter);
                        iter--;
                    });
                    if (sum % 11 == double.Parse(afmNew.Substring(8)) || double.Parse(afmNew.Substring(8)) == 0)
                        return ValidationResult.Success;
                    else
                        return new ValidationResult("Please Enter a Valid A.F.M.");
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}
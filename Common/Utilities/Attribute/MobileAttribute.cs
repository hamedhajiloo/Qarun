using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common.Utilities.Attributes
{
    public class MobileAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string strErrorMessage;
           
            try
            {

                if (!Regex.IsMatch(value.ToString().TrimEnd().TrimStart(), @"(0|\+98)?([ ]|,|-|[()]){0,2}9[1|2|3|4]([ ]|,|-|[()]){0,2}(?:[0-9]([ ]|,|-|[()]){0,2}){8}"))
                {
                    strErrorMessage = "شماره موبایل را صحیح وارد کنید";
                    return new ValidationResult(strErrorMessage);
                }

                else return ValidationResult.Success;
            }
            catch (Exception)
            {
                strErrorMessage = "کد ملی را درست وارد نمایید";
                return new ValidationResult(strErrorMessage);
            }

        }
    }
}

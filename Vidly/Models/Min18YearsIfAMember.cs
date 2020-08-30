using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var Customer = (Customer)validationContext.ObjectInstance;
            if (Customer.MembershipTypeId == MembershipType.UnKnown || Customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (Customer.Birthdate == null)
                return new ValidationResult("BirthDate Is Required");
            var age = DateTime.Today.Year - Customer.Birthdate.Value.Year;
            return (age > 18) ? ValidationResult.Success : new ValidationResult("Age should be 18 years old at least");

        }
    }
}
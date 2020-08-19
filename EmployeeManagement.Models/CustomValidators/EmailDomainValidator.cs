using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator : ValidationAttribute
    {
        public string AllowedDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string[] strings = value.ToString().Split('@');
            if(strings.Length>1 && strings[1].ToUpper() == AllowedDomain.ToUpper())
            {
                return null;
            }
           // return new ValidationResult($"Domain mustbe {AllowedDomain}", new[] { validationContext.MemberName });
            return new ValidationResult(ErrorMessage, new[] { validationContext.MemberName });
            //return base.IsValid(value, validationContext);
        }
    }
}

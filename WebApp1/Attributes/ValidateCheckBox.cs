using System;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp1.Attributes
{
    public class ValidateCheckBox : ValidationAttribute, IClientModelValidator
    {
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val-checkbox", ErrorMessage);
        }
        public override bool IsValid(object? value)
        {
            if (value != null && (bool)value == true)
                return true;
            else
                return false;
        }
    }
}

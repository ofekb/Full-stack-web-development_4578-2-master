using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace _02_BOL.Validations
{
    public class RangeAgeAttribute : ValidationAttribute
    {
        override protected ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            object instance = validationContext.ObjectInstance;
            Type type = instance.GetType();
            PropertyInfo property = type.GetProperty("IsMale");
            object propertyValue = property.GetValue(instance);
            Boolean.TryParse(propertyValue.ToString(), out bool isMale);

            return ((isMale && (int)value >= 18 || (int)value >= 20) && (int)value <= 120) ? null :
                new ValidationResult("Min age:" + (isMale ? 18 : 20) + ", Max age: 120");
        }
    }
}

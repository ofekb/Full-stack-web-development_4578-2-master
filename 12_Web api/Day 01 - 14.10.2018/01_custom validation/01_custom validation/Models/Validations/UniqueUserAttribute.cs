using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace _01_custom_validation.Models.Validations
{
    public class UniqueUserAttribute: ValidationAttribute
    {
        public UniqueUserAttribute()
        {
            ErrorMessage = "Name is allready taken, please choose another name";
        }
        override public bool IsValid(object value)
        {
            return !(GlobalData.Users.Any(user => user.UserName == value.ToString()));
        }
    }
}
using _01_custom_validation.Models.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _01_custom_validation.Models
{
    public class User
    {
        //UserName must be unique
        //4- 12 chars
        //requierd
        [Required]
        [MinLength(4),MaxLength(12)]
        [UniqueUser]
        public string UserName { get; set; }

        //default is true
        [DefaultValue(true)]
        public bool IsMale { get; set; }

        //If user is male - min value is 18
        //If user is women - min value is 20
        //For both - max is 120
        [RangeAge]
        public int Age { get; set; }

    }
}
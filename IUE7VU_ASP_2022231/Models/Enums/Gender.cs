using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IUE7VU_ASP_2022231.Models.Enums
{
    public enum Gender
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1,
    };
}

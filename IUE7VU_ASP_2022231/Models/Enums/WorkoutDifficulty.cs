using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IUE7VU_ASP_2022231.Models.Enums
{
    public enum WorkoutDifficulty
    {
        [Display(Name = "Easy")]
        Easy = 0,
        [Display(Name = "Medium")]
        Medium = 1,
        [Display(Name = "Hard")]
        Hard = 2,
        [Display(Name = "Extreme")]
        Extreme = 3,
    }
}

using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace IUE7VU_ASP_2022231.Models.Enums
{
    public enum MuscleTypes
    {
        [Display(Name = "Chest")]
        Chest = 0,
        [Display(Name = "Back")]
        Back = 1,
        [Display(Name = "Shoulders")]
        Shoulders = 2,
        [Display(Name = "Legs")]
        Legs = 3,
        [Display(Name = "Biceps")]
        Biceps = 4,
        [Display(Name = "Triceps")]
        Triceps = 5,
    }
}
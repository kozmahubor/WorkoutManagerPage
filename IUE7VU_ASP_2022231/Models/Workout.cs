using IUE7VU_ASP_2022231.Models.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using static IUE7VU_ASP_2022231.Models.Enums.MuscleTypes;
using static IUE7VU_ASP_2022231.Models.Enums.WorkoutDifficulty;


namespace IUE7VU_ASP_2022231.Models
{
    public class Workout
    {
        [Key]
        [Required]
        public string? WorkoutId { get; set; }
        [Required]
        public MuscleTypes MuscleTypes { get; set; }
        [Required]
        public double WorkoutTime_Weights { get; set; }
        [Required]
        public double WorkoutTime_Cardio { get; set; }
        [Required]
        public WorkoutDifficulty WorkoutDifficulty { get; set; }
        [Required]
        public DateTime WorkoutDay { get; set; }
        public string? PersonId { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public virtual Person Person { get; set; }
        
        [StringLength(200)]
        public string? ImageFileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }

        public Workout()
        {
            WorkoutId = Guid.NewGuid().ToString();
        }

    }
}

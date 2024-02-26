using static IUE7VU_ASP_2022231.Models.Enums.Gender;
using System.ComponentModel.DataAnnotations;
using IUE7VU_ASP_2022231.Models.Enums;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace IUE7VU_ASP_2022231.Models
{
    public class Person
    {
        [Key]
        [Required]
        public string PersonId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string PersonName { get; set; }
        [Required]
        [Range(6, 99)]
        public int? PersonAge { get; set; }
        [Required]
        public Gender PersonGender { get; set; }
        public virtual ICollection<Workout>? Workouts { get; set; }
        [StringLength(200)]
        public string? ImageFileName { get; set; }
        public string? ContentType { get; set; }
        public byte[]? Data { get; set; }
        public string? PersonIdentity { get; set; }
      

        public Person()
        {
            PersonId = Guid.NewGuid().ToString();
        }
    }
}

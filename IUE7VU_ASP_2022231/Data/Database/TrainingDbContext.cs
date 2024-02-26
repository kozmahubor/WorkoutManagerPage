using IUE7VU_ASP_2022231.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IUE7VU_ASP_2022231.Data.Database
{
    public class TrainingDbContext : IdentityDbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workout>()
                .HasOne(w => w.Person)
                .WithMany(p => p.Workouts)
                .HasForeignKey(w => w.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>().HasData(new Person[]
           {
                new Person()
                {
                    PersonId = "1",
                    PersonName = "Hunor",
                    PersonAge = 22,
                    PersonGender = Models.Enums.Gender.Male,
                    PersonIdentity = "kozmahunor@freemail.hu"
                    //Workouts = new Workout[]
                    //{
                    //    new Workout
                    //    {
                    //        WorkoutId = "1",
                    //        MuscleTypes = Models.Enums.MuscleTypes.Chest,
                    //        WorkoutTime_Weights = 2,
                    //        WorkoutTime_Cardio = 1,
                    //        WorkoutDay = new DateTime(2023,01,01),
                    //    },
                    //    new Workout
                    //    {
                    //        WorkoutId = "2",
                    //        MuscleTypes = Models.Enums.MuscleTypes.Biceps,
                    //        WorkoutTime_Weights = 1,
                    //        WorkoutTime_Cardio = 0,
                    //        WorkoutDay = new DateTime(2023,01,02),
                    //    },
                    //}
                },
                new Person()
                {
                    PersonId = "2",
                    PersonName = "Reni",
                    PersonAge = 23,
                    PersonGender = Models.Enums.Gender.Female,
                    PersonIdentity = "renata@gmail.com"
                    //Workouts = new Workout[]
                    //{
                    //    new Workout
                    //    {
                    //        WorkoutId = "3",
                    //        MuscleTypes = Models.Enums.MuscleTypes.Legs,
                    //        WorkoutTime_Weights = 3,
                    //        WorkoutTime_Cardio = 2,
                    //        WorkoutDay = new DateTime(2023,01,01),
                    //    },
                    //    new Workout
                    //    {
                    //        WorkoutId = "4",
                    //        MuscleTypes = Models.Enums.MuscleTypes.Shoulders,
                    //        WorkoutTime_Weights = 1,
                    //        WorkoutTime_Cardio = 1,
                    //        WorkoutDay = new DateTime(2023,01,03),
                    //    },
                    //}
                },
                new Person()
                {
                    PersonId = "3",
                    PersonName = "Márk",
                    PersonAge = 33,
                    PersonGender = Models.Enums.Gender.Female,
                    PersonIdentity = "markopolo@gmail.com"
                },
                 new Person()
                {
                    PersonId = "4",
                    PersonName = "Laci",
                    PersonAge = 93,
                    PersonGender = Models.Enums.Gender.Female,
                    PersonIdentity = "laszlo@gmail.com"
                },
                 new Person()
                {
                    PersonId = "5",
                    PersonName = "Sanyi",
                    PersonAge = 7,
                    PersonGender = Models.Enums.Gender.Female,
                    PersonIdentity = "sanyi@gmail.com"
                },

           });

            modelBuilder.Entity<Workout>().HasData(new Workout[]
            {
                    new Workout()
                    {
                        WorkoutId = "3",
                        MuscleTypes = Models.Enums.MuscleTypes.Chest,
                        WorkoutTime_Weights = 3,
                        WorkoutTime_Cardio = 2,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Extreme,
                        WorkoutDay = new DateTime(2022,11,01),
                        PersonId = "1",
                    },
                    new Workout()
                    {
                        WorkoutId = "4",
                        MuscleTypes = Models.Enums.MuscleTypes.Legs,
                        WorkoutTime_Weights = 1,
                        WorkoutTime_Cardio = 1,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Easy,
                        WorkoutDay = new DateTime(2022,11,01),
                        PersonId = "2",
                    },
                     new Workout()
                    {
                        WorkoutId = "5",
                        MuscleTypes = Models.Enums.MuscleTypes.Biceps,
                        WorkoutTime_Weights = 2,
                        WorkoutTime_Cardio = 5,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Medium,
                        WorkoutDay = new DateTime(2022,12,02),
                        PersonId = "1",
                    },
                     new Workout()
                    {
                        WorkoutId = "6",
                        MuscleTypes = Models.Enums.MuscleTypes.Triceps,
                        WorkoutTime_Weights = 10,
                        WorkoutTime_Cardio = 12,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Medium,
                        WorkoutDay = new DateTime(2023,01,03),
                        PersonId = "3",
                    },
                     new Workout()
                    {
                        WorkoutId = "7",
                        MuscleTypes = Models.Enums.MuscleTypes.Shoulders,
                        WorkoutTime_Weights = 23,
                        WorkoutTime_Cardio = 1,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Easy,
                        WorkoutDay = new DateTime(2023,01,01),
                        PersonId = "4",
                    },
                     new Workout()
                    {
                        WorkoutId = "8",
                        MuscleTypes = Models.Enums.MuscleTypes.Back,
                        WorkoutTime_Weights = 6,
                        WorkoutTime_Cardio = 17,
                        WorkoutDifficulty = Models.Enums.WorkoutDifficulty.Hard,
                        WorkoutDay = new DateTime(2023,01,10),
                        PersonId = "1",
                    },

            });;

            base.OnModelCreating(modelBuilder);

        }
        public TrainingDbContext(DbContextOptions<TrainingDbContext> opt) : base(opt)
        {
        }
    }

}

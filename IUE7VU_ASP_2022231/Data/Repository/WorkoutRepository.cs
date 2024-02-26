using IUE7VU_ASP_2022231.Data.Database;
using IUE7VU_ASP_2022231.Data.IRepository;
using IUE7VU_ASP_2022231.Logic;
using IUE7VU_ASP_2022231.Models;

namespace IUE7VU_ASP_2022231.Data.Repository
{
    public class WorkoutRepository : IWorkoutRepository
    {
        TrainingDbContext context;
        ImageLogic imageLogic;

        public WorkoutRepository(TrainingDbContext context, ImageLogic imageLogic)
        {
            this.context = context;
            this.imageLogic = imageLogic;
        }

        public void Create(Workout workout)
        {
            context.Workouts.Add(workout);
            context.SaveChanges();
        }

        public IEnumerable<Workout> ReadAll()
        {
            return context.Workouts;
        }

        public Workout? Read(string name)
        {
            return context.Workouts.FirstOrDefault(w => w.PersonId == name);
        }

        public Workout? ReadFromId(string workoutId)
        {
            return context.Workouts.FirstOrDefault(w => w.WorkoutId == workoutId);
        }

        public void Delete(string workoutId)
        {
            var workout = ReadFromId(workoutId);
            context.Workouts.Remove(workout);
            context.SaveChanges();
        }

        public void Update(Workout workout)
        {
            var old = ReadFromId(workout?.WorkoutId);
            old.MuscleTypes = workout.MuscleTypes;
            old.WorkoutTime_Weights = workout.WorkoutTime_Weights;
            old.WorkoutTime_Cardio = workout.WorkoutTime_Cardio;
            old.WorkoutDifficulty = workout.WorkoutDifficulty;
            (string, byte[], string) imageData = imageLogic.SetImageByMuscleType(workout);
            old.ImageFileName = imageData.Item1;
            old.Data = imageData.Item2;
            old.ContentType = imageData.Item3;
            context.SaveChanges();
        }
    }
}

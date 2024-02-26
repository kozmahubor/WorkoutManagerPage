using IUE7VU_ASP_2022231.Models;

namespace IUE7VU_ASP_2022231.Data.IRepository
{
    public interface IWorkoutRepository
    {
        void Create(Workout workout);
        void Delete(string workoutId);
        IEnumerable<Workout> ReadAll();
        Workout? ReadFromId(string workoutId);
        void Update(Workout workout);
    }
}
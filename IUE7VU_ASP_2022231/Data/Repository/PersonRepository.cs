using IUE7VU_ASP_2022231.Data.Database;
using IUE7VU_ASP_2022231.Data.IRepository;
using IUE7VU_ASP_2022231.Models;
using IUE7VU_ASP_2022231.Models.Enums;

namespace IUE7VU_ASP_2022231.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        TrainingDbContext context;

        public PersonRepository(TrainingDbContext context)
        {
            this.context = context;
        }

        public void Create(Person person)
        {
            context.People.Add(person);
            context.SaveChanges();
        }

        public IEnumerable<Person> Read()
        {
            return context.People;
        }

        public Person? Read(string name)
        {
            return context.People.FirstOrDefault(p => p.PersonName == name);
        }

        public Person? ReadFromId(string id)
        {
            return context.People.FirstOrDefault(p => p.PersonId == id);
        }

        public void Delete(string name)
        {
            var person = Read(name);
            context.People.Remove(person);
            context.SaveChanges();
        }

        public void Update(Person person)
        {
            var old = Read(person.PersonName);
            old.PersonAge = person.PersonAge;
            old.PersonGender = person.PersonGender;
            context.SaveChanges();
            //old.Workouts = person.Workouts;
        }



    }
}

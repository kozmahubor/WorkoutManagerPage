using IUE7VU_ASP_2022231.Models;

namespace IUE7VU_ASP_2022231.Data.IRepository
{
    public interface IPersonRepository
    {
        void Create(Person person);
        void Delete(string name);
        IEnumerable<Person> Read();
        Person? Read(string name);
        Person? ReadFromId(string id);
        void Update(Person person);
    }
}
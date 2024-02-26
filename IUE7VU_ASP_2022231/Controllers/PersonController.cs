using IUE7VU_ASP_2022231.Data.IRepository;
using IUE7VU_ASP_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using IUE7VU_ASP_2022231.Logic;
using Newtonsoft.Json;

namespace IUE7VU_ASP_2022231.Controllers
{
    public class PersonController : Controller
    {
        IPersonRepository personRepo;
        ImageLogic imageLogic;
        Admin admin = new Admin();
        static List<Person> people = new List<Person>();
        public PersonController(IPersonRepository repository, ImageLogic imageLogic) 
        {
            this.personRepo = repository;
            this.imageLogic = imageLogic;
        }
        public IActionResult Index()
        {


            //var person = personRepo.Read();
            //ld.AmountMale = person.Where(p => p.PersonGender == Models.Enums.Gender.Male).Count();
            //ld.AmountFemale = person.Where(p => p.PersonGender == Models.Enums.Gender.Female).Count();
            //ld.AvgMaleAge = person.Where(p => p.PersonGender == Models.Enums.Gender.Male).Select(p => p.PersonAge).Average();
            //ld.AvgFemaleAge = person.Where(p => p.PersonGender == Models.Enums.Gender.Female).Select(p => p.PersonAge).Average();
            //ld.AmountWorkouts = person.Where(p => p.Workouts != null).Count(p => p.Workouts.Count() > 0);



            return View(this.personRepo.Read());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Person person, IFormFile pictureData)
        {
            person.PersonIdentity = User.Identity?.Name;
            if (pictureData != null)
            {
                using (var stream = pictureData.OpenReadStream())
                {
                    byte[] buffer = new byte[pictureData.Length];
                    stream.Read(buffer, 0, (int)pictureData.Length);
                    string filename = person.PersonId + "." + pictureData.FileName.Split('.')[1];
                    person.ImageFileName = filename;

                    System.IO.File.WriteAllBytes(Path.Combine("wwwroot", "images", filename), buffer);

                    person.Data = buffer;
                    person.ContentType = pictureData.ContentType;
                }
            }
            if (!ModelState.IsValid)
            {
                if (pictureData == null)
                {
                    personRepo.Create(person);
                    return RedirectToAction(nameof(Index));
                }
                return View(person);
            }
            HttpContext.Session.SetString("person", JsonConvert.SerializeObject(person));
            personRepo.Create(person);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            Person? person = personRepo.Read(name);
            if (admin.Identity != User?.Identity?.Name && person?.PersonIdentity != User.Identity?.Name)
            {
                throw new UnauthorizedAccessException();
            }
            personRepo.Delete(name);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Update(string name)
        {
            var person = personRepo.Read(name);
            if (admin.Identity != User?.Identity?.Name && person?.PersonIdentity != User.Identity?.Name)
            {
                throw new UnauthorizedAccessException();
            }
            return View(person);
        }

        [HttpPost]
        public IActionResult Update(Person person)
        {
            if (!ModelState.IsValid)
            {
                return View(person);
            }
            personRepo.Update(person);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(string id)
        {
            var person = personRepo.ReadFromId(id);
            if (person?.ContentType == null)
            {
                FileInfo fileInfo = imageLogic.GetFileInfoOfImage("default.png");
                byte[] buffer = System.IO.File.ReadAllBytes(fileInfo.FullName);
                return new FileContentResult(buffer, "image/png");
            }
            if (person.ContentType.Length > 3)
            {
                return new FileContentResult(person.Data, person.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

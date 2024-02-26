using IUE7VU_ASP_2022231.Data;
using IUE7VU_ASP_2022231.Data.IRepository;
using IUE7VU_ASP_2022231.Data.Repository;
using IUE7VU_ASP_2022231.Logic;
using IUE7VU_ASP_2022231.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.Extensions.FileProviders;
using System;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;

namespace IUE7VU_ASP_2022231.Controllers
{
    public class WorkoutController : Controller
    {
        ImageLogic imageLogic;
        Admin admin = new Admin();
        IWorkoutRepository workoutRepository;
        IPersonRepository personRepo;
        public WorkoutController(IWorkoutRepository repository, ImageLogic imageLogic, IPersonRepository personRepository)
        {
            this.workoutRepository = repository;
            this.imageLogic = imageLogic;
            this.personRepo = personRepository;
        }
        
        public IActionResult Index(string id)
        {
            //workout kapcsolás azonos kulcsal rendelkező personökhöz
            if (id != null)
            {
                ViewBag.PersonId = id;
            }
            return View(this.workoutRepository.ReadAll());
        }

        [HttpGet]
        public IActionResult Create(string personId)
        {
            //personId beállítása workoutnak
            ViewBag.Person = personRepo.ReadFromId(personId);
            ViewBag.PersonId = personId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Workout workout)
        {

            (string, byte[], string) imageData = imageLogic.SetImageByMuscleType(workout);
            workout.ImageFileName = imageData.Item1;
            workout.Data = imageData.Item2;
            workout.ContentType = imageData.Item3;

            ViewBag.Person = personRepo.ReadFromId(workout.PersonId);
            workout.Person = ViewBag.Person;
            TempData["PersonId"] = workout.PersonId;
            if (!ModelState.IsValid)
            {
                return View(workout);
            }
            workoutRepository.Create(workout);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string personId, string workoutId)
        {
            var person = personRepo.ReadFromId(personId);
            if (admin.Identity != User?.Identity?.Name && person?.PersonIdentity != User.Identity?.Name)
            {
                throw new UnauthorizedAccessException();
            }
            workoutRepository.Delete(workoutId);
            TempData["PersonId"] = personId;
            return RedirectToAction(nameof(Index));
        }
        
        [HttpGet]
        public IActionResult Update(string personId, string workoutId)
        {
            var workout = workoutRepository.ReadFromId(workoutId);
            var person = personRepo.ReadFromId(personId);
            if (admin.Identity != User?.Identity?.Name && workout?.Person.PersonIdentity != User.Identity?.Name)
            {
                throw new UnauthorizedAccessException();
            }
            TempData["PersonId"] = workout.PersonId;
            return View(workout);
        }
        [HttpPost]
        public IActionResult Update(Workout workout)
        {
            if (!ModelState.IsValid)
            {
                return View(workout);
            }
            workoutRepository.Update(workout);
            //var person = personRepo.ReadFromId(workout.PersonId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult GetImage(string Id)
        {
            var workout = workoutRepository.ReadFromId(Id);
            if (workout?.ContentType == null)
            {   
                FileInfo fileInfo = imageLogic.GetFileInfoOfImage("default.png");
                byte[] buffer = System.IO.File.ReadAllBytes(fileInfo.FullName);
                return new FileContentResult(buffer, "image/png");
            }
            if (workout.ContentType.Length > 3)
            {
                return new FileContentResult(workout.Data, workout.ContentType);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}

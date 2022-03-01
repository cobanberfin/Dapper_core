using Dapper_core.Models;
using Dapper_Example.Models;
using Dapper_Example.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dapper_Example.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository rep;
        StudentModel sm = new StudentModel();
        public StudentController(IStudentRepository _rep)
        {
            rep = _rep;
        }
        public IActionResult Index(string name, string surname, string email)
        {
            return View(rep.GetAll(name,surname,email));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var student= rep.Find(id.GetValueOrDefault());
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student )
        {

          
            if (ModelState.IsValid)
            {
                rep.Add(student);
                return RedirectToAction(nameof(Index));

            }
            return View(student);
        }

        public IActionResult Edit(int? id)
        {

            var student = rep.Find(id.GetValueOrDefault());
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        public IActionResult Edit(int? id,Student student)
        {

            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                rep.Update(student); 
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            rep.Remove(id.GetValueOrDefault());
            return RedirectToAction("Index");

        }
    }
}

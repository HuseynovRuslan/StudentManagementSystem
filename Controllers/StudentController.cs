using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;

namespace StudentManagementSystem.Controllers
{



    public class StudentController : Controller
    {



        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult AddStudent()
        {


            var groups = _context.Groups.ToList();
            ViewBag.GroupsForDropdown = new SelectList(groups, "Id", "Name");

            return View(new StudentCreateViewModel());
        }
        [HttpPost]

        public IActionResult AddStudent(StudentCreateViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Age = viewModel.Age,
                    Email = viewModel.Email,
                    GroupId = viewModel.GroupId
                };



                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("AllStudents");
            }

            ViewBag.GroupsForDropdown = new SelectList(_context.Groups.ToList(), "Id", "Name");

            return View(viewModel);
        }

        public IActionResult AllStudents()
        {
            var students = _context.Students
                .Include(s => s.Group)
                .ToList();



            return View(students);
        }

        [HttpGet]
        public IActionResult Search(string query, string searchBy)
        {



            if (string.IsNullOrEmpty(query))
            {
                return RedirectToAction("AllStudents");
            }

            IQueryable<Student> studentsQuery = _context.Students;

            if (searchBy == "id")
            {

                if (int.TryParse(query, out int id))
                {
                    studentsQuery = studentsQuery.Where(s => s.Id == id);
                }

            }
            else
            {
                studentsQuery = studentsQuery.Where(s => s.Name.ToLower().Contains(query.ToLower()));
            }
            var results = studentsQuery.ToList();
            return View("SearchResult", results);
        }
    }
}

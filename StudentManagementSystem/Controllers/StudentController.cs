using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain;
using StudentManagementSystem.Persistence.Data;
using StudentManagementSystem.ViewModels;
namespace StudentManagementSystem.Controllers
{

    public class StudentController : Controller
    {



        private readonly IStudentRepository _studentRepository;
        private readonly IGroupRepository _groupRepository; 

        public StudentController(IStudentRepository studentRepository, IGroupRepository groupRepository)
        {
            _studentRepository = studentRepository;
            _groupRepository = groupRepository;
        }


        [HttpGet]
        public async Task<IActionResult> AddStudent()
        {
            var groups = await _groupRepository.GetAllAsync();
            var viewModel = new StudentCreateViewModel
            {
                Groups = groups
            };
            return View(viewModel);
        }


        [HttpPost]

        public async Task <IActionResult> AddStudent(StudentCreateViewModel viewModel)
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
                await _studentRepository.AddAsync(student);
                return RedirectToAction("AllStudents");
            }



            viewModel.Groups = await _groupRepository.GetAllAsync();
            return View(viewModel);
        }

        public async Task <IActionResult> AllStudents()
        {
            var students = await _studentRepository.GetAllAsync();
             
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> SearchResult(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(new List<Student>());
            }
            var students = await _studentRepository.SearchAsync(query);
            return View(students);
        }
    }
}

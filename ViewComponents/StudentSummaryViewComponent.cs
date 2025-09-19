using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Controllers;
using StudentManagementSystem.Persistence.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.ViewComponents
{
    public class StudentSummaryViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public StudentSummaryViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
           int totalStudents = _context.Students.Count();

            return View(totalStudents);
        }
    }
}

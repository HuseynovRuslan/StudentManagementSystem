using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using StudentManagementSystem.ViewModels;


namespace StudentManagementSystem.Controllers
{
    public class GroupsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GroupsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {

            var groups = _context.Groups.ToList();
            return View(groups);
        }


        [HttpGet]
        public IActionResult Create() {


            return View(new GroupCreateViewModel());


        }


        [HttpPost]
        public IActionResult Create(GroupCreateViewModel viewModel) {

            if (ModelState.IsValid)


            {
                var group = new Group
                {
                    Name = viewModel.Name
                };

                _context.Groups.Add(group);
                _context.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var group = _context.Groups.FirstOrDefault(g => g.Id == id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id) {
         
            bool hasStudents = _context.Students.Any(s => s.GroupId == id);
            if (hasStudents) {
                TempData["ErrorMessage"] = $"Cannot delete group with ID {id} because it has students assigned to it.";
                return RedirectToAction("Index");


            }

            var group = _context.Groups.Find(id);
            if (group != null) {
           
                _context.Groups.Remove(group);
                    _context.SaveChanges();
              
            }
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Edit(int id) {


            if (id == null)
            {
                return NotFound();
            }

            var group = _context.Groups.Find(id);
            if (group == null)
            {
                return NotFound();
            }

            var viewModel = new GroupEditViewModel
            {
                Id = group.Id,
                Name = group.Name
            };





            return View(viewModel);
        }

        [HttpPost]

       public IActionResult Edit(int id,GroupEditViewModel viewModel)
        {
            if(id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var groupFromDb = _context.Groups.Find(viewModel.Id);
                if (groupFromDb == null)
                {

                    return NotFound();
                }
                groupFromDb.Name=viewModel.Name;
                _context.SaveChanges();
                return RedirectToAction("Index");




            }


            return View(viewModel);

        }








    }
}

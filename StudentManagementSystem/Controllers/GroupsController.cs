using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Application.Interfaces; 
using StudentManagementSystem.Domain;                 

namespace StudentManagementSystem.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupRepository _groupRepository;

        public GroupsController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IActionResult> Index()
        {
            var groups = await _groupRepository.GetAllAsync();
            return View(groups);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                await _groupRepository.AddAsync(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _groupRepository.GetByIdAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Group group)
        {
            if (id != group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _groupRepository.UpdateAsync(group);
                return RedirectToAction(nameof(Index));
            }
            return View(group);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _groupRepository.GetByIdAsync(id.Value);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _groupRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
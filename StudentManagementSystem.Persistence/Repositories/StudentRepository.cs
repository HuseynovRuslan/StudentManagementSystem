using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Application.Interfaces;
using StudentManagementSystem.Domain;
using StudentManagementSystem.Persistence.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Persistence.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Student>> SearchAsync(string query)
        {
            return await _context.Students
                .Include(s => s.Group)
                .Where(s => s.Name.Contains(query))
                .ToListAsync();
        }
    }
}